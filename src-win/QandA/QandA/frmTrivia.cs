using QandA.DbServices;
using QandA.Models;
using QandA.Services;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QandA
{
    public partial class frmTrivia : Form
    {
        private Topic _topic { get; set; }
        private List<Question> _questions { get; set; }
        private int _currentQuestionIndex { get; set; } = 0;

        private Trivia _trivia { get; set; }


        private System.Windows.Forms.RadioButton[] radioOptions;

        public frmTrivia(Topic topic)
        {
            InitializeComponent();
            _topic = topic;

            radioOptions = new System.Windows.Forms.RadioButton[] { radioOption1, radioOption2, radioOption3, radioOption4 };
        }

        public async Task GenerateQuestions()
        {
            _trivia = new Trivia();
            _trivia.CompletionDate = DateTime.UtcNow;
            _trivia.Topic = _topic;

            string allConcepts = _trivia.Topic.Concepts.Select(c => c.ConceptText).Aggregate((a, b) => a + ";" + b);

            Task.Run(async Task<List<Question>> () =>
            {
                OpenAIService openAIService = new OpenAIService();
                return await openAIService.GenerateQuestionsFromText(allConcepts);

            }).ContinueWith(async t =>
            {
                List<Question> questions = await t;
                QuestionDbService questionDbService = new QuestionDbService(frmMain.PostgreSqlConnectionString);
                questions.ForEach(async question =>
                {
                    question.Topic = _trivia.Topic;
                    _trivia.Topic.Questions.Add(question);
                    await questionDbService.StoreNewQuestion(question);
                    lstQuestions.Items.Add(question.QuestionText);
                });

                _questions = questions;
                SetCurrentQuestion();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void SetCurrentQuestion()
        {
            if (_currentQuestionIndex >= _questions.Count)
            {
                MessageBox.Show("All questions answered");
                return;
            }
            var question = _questions.ElementAt(_currentQuestionIndex);
            txtQuestion.Text = question.QuestionText;

            var options = new List<(string Option, int Index)>
            {
                (Option: question.OptionCorrect, Index: 0),
                (Option: question.OptionIncorrect1, Index: 1),
                (Option: question.OptionIncorrect2, Index: 2),
                (Option: question.OptionIncorrect3, Index: 3),
            };

            Random random = new Random();
            options = options.OrderBy(x => random.Next()).ToList();

            for (int i = 0; i < options.Count; i++)
            {
                radioOptions[i].Text = options[i].Option;
                radioOptions[i].Tag = options[i].Index;
            }

        }

        private void radioOption_Clicked(object sender, EventArgs e)
        {
            var radioOption = (System.Windows.Forms.RadioButton)sender;

            // This even might be triggered when I am changing question to clean up the previous question
            if(!radioOption.Focused)
            {
                return;
            }


            var selectedQuestionIndex = (int)radioOption.Tag;

            radioOption.ForeColor = Color.Red;

            foreach (var ro in radioOptions)
            {
                if ((int)ro.Tag == 0)
                {
                    ro.ForeColor = Color.Green;
                }
            }

            _trivia.Answers.Add(new TriviaAnswer
            {
                Question = _questions.ElementAt(selectedQuestionIndex),
                SelectedAnswer = selectedQuestionIndex
            });
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            foreach (var ro in radioOptions)
            {
                ro.ForeColor = Color.Black;
                ro.Checked = false;
            }
            _currentQuestionIndex++;
            SetCurrentQuestion();
        }
    }
}
