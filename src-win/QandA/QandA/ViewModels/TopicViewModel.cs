using QandA.DbServices;
using QandA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QandA.ViewModels
{
    internal static class TopicViewModel
    {
        private static ContextMenuStrip TopicContextMenu { get; set; } = new ContextMenuStrip();

        static TopicViewModel()
        {
            ToolStripMenuItem editTopic = new ToolStripMenuItem();
            editTopic.Text = "Edit Topic";
            editTopic.Click += EditTopicName_Click;

            ToolStripMenuItem newConcept = new ToolStripMenuItem();
            newConcept.Text = "New Concept";
            newConcept.Click += NewConcept_Click;

            ToolStripMenuItem newQuestion = new ToolStripMenuItem();
            newQuestion.Text = "New Question";

            ToolStripMenuItem newTrivia = new ToolStripMenuItem();
            newTrivia.Text = "New Trivia";
            newTrivia.Click += NewTrivia_Click;

            TopicContextMenu.Items.AddRange(new ToolStripMenuItem[] { editTopic, newConcept, newQuestion, newTrivia });
        }

        private static async void NewTrivia_Click(object? sender, EventArgs e)
        {
            if(frmMain.MainTreeView.SelectedNode == null)
            {
                MessageBox.Show("Please select a topic to generate trivia for.");
                return;
            }

            if(frmMain.MainTreeView.SelectedNode.Tag is not Topic topic)
            {
                MessageBox.Show("Only on trivias!");
                return;
            }

            frmTrivia triviaForm = new frmTrivia(topic);
            triviaForm.Show();          
            await triviaForm.GenerateQuestions();
        }

        private static void NewConcept_Click(object? sender, EventArgs e)
        {
            TreeNode selectedNode = frmMain.MainTreeView.SelectedNode;
            if (selectedNode != null)
            {
                Topic topic = (Topic)selectedNode.Tag;
                var newConcept = new Concept
                {
                    Id = Guid.NewGuid(),
                    Name = "New Concept",
                    Topic = topic
                };
                topic.Concepts.Add(newConcept);

                var conceptDbService  = new ConceptDbService(frmMain.PostgreSqlConnectionString);
                Task.Run(() => conceptDbService.StoreNewConcept(newConcept));
                selectedNode.Nodes.Add(ConceptViewModel.GetTreeNode(newConcept));
            }
        }

        internal static TreeNode GetTreeNode(Topic topic)
        {
            var treeNode = new TreeNode
            {
                Text = topic.Name,
                Tag = topic,
                ContextMenuStrip = TopicContextMenu,
            };

            foreach(var concept in topic.Concepts)
            {
                treeNode.Nodes.Add(ConceptViewModel.GetTreeNode(concept));
            }

            return treeNode;
        }


        private static void EditTopicName_Click(object? sender, EventArgs e)
        {
            if (frmMain.MainTreeView.SelectedNode != null)
            {
                frmMain.MainTreeView.LabelEdit = true;
                frmMain.MainTreeView.SelectedNode.BeginEdit();
            }
        }

    }
}
