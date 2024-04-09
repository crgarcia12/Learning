using Npgsql;
using QandA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QandA.DbServices
{
    internal class QuestionDbService
    {
        private string _databaseConnectionString;

        public QuestionDbService(string databaseConnectionString)
        {
            this._databaseConnectionString = databaseConnectionString;
        }

        internal async Task StoreNewQuestion(Question newQuestion)
        {
            // Convert the Area object into a SQL query
            string query = $"INSERT INTO questions (id, question_text, option_correct, option_incorrect_1, option_incorrect_2, option_incorrect_3) VALUES (@QuestionId, @QuestionText, @OptionCorrect, @OptionIncorrect1, @OptionIncorrect2, @OptionIncorrect3);";

            using (var dbconn = new NpgsqlConnection(_databaseConnectionString))
            {
                await dbconn.OpenAsync();
                using (var cmd = new NpgsqlCommand(query, dbconn))
                {
                    cmd.Parameters.AddWithValue("QuestionId", newQuestion.Id);
                    cmd.Parameters.AddWithValue("QuestionText", newQuestion.QuestionText);
                    cmd.Parameters.AddWithValue("OptionCorrect", newQuestion.OptionCorrect);
                    cmd.Parameters.AddWithValue("OptionIncorrect1", newQuestion.OptionIncorrect1);
                    cmd.Parameters.AddWithValue("OptionIncorrect2", newQuestion.OptionIncorrect2);
                    cmd.Parameters.AddWithValue("OptionIncorrect3", newQuestion.OptionIncorrect3);
                    await cmd.ExecuteNonQueryAsync();
                }

            }
        }

        public async Task<List<Question>> GetAllQuestionsByTopic(Topic topic)
        {
            // Construct the SQL query to retrieve all areas
            string query = $"SELECT id, question_text, option_correct, option_incorrect_1, option_incorrect_2, option_incorrect_3 FROM public.questions WHERE topic_id = '{topic.Id}';";

            List<Question> questions = new List<Question>();

            // Use the PostgreSqlService to run the query and get the result
            using (var dbconn = new NpgsqlConnection(_databaseConnectionString))
            {
                await dbconn.OpenAsync();
                using (var command = new NpgsqlCommand(query, dbconn))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var question = new Question
                            {
                                Id = reader.GetGuid(0),
                                QuestionText = reader.GetString(1),
                                OptionCorrect = reader.GetString(2),
                                OptionIncorrect1 = reader.GetString(3),
                                OptionIncorrect2 = reader.GetString(4),
                                OptionIncorrect3 = reader.GetString(5)
                            };
                            question.Topic = topic;
                            questions.Add(question);
                        }
                    }
                }
            }

            return questions;
        }
    }
}
