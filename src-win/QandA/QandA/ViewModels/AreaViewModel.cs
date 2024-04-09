using QandA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QandA;
using QandA.DbServices;

namespace QandA.ViewModels
{
    internal static class AreaViewModel
    {
        private static ContextMenuStrip AreaContextMenu { get; set; } = new ContextMenuStrip();

        static AreaViewModel()
        {
            ToolStripMenuItem newTopicMenu = new ToolStripMenuItem();
            newTopicMenu.Text = "New Topic";
            newTopicMenu.Click += NewTopic_Click;

            ToolStripMenuItem editAreaName = new ToolStripMenuItem();
            editAreaName.Text = "Edit";
            editAreaName.Click += EditAreaName_Click;

            AreaContextMenu.Items.AddRange(new ToolStripMenuItem[] { newTopicMenu, editAreaName });
        }

        private static void NewTopic_Click(object? sender, EventArgs e)
        {
            TreeNode selectedNode = frmMain.MainTreeView.SelectedNode;
            if (selectedNode != null)
            {
                Area area = (Area)selectedNode.Tag;
                var newTopic = new Topic
                {
                    Id = Guid.NewGuid(),
                    Name = "New Topic",
                    Area = area
                };
                area.Topics.Add(newTopic);

                var topicDbService = new TopicDbService(frmMain.PostgreSqlConnectionString);
                Task.Run(() => topicDbService.StoreNewTopic(newTopic)).Wait();

                TreeNode topicTreeNode = TopicViewModel.GetTreeNode(newTopic);
                selectedNode.Nodes.Add(topicTreeNode);

                frmMain.MainTreeView.LabelEdit = true;
                topicTreeNode.BeginEdit();
            }
        }

        internal static TreeNode GetTreeNode(Area area)
        {
            var treeNode = new TreeNode
            {
                Text = area.Name,
                Tag = area,
                ContextMenuStrip = AreaContextMenu,
            };

            foreach (Topic topic in area.Topics)
            {
                treeNode.Nodes.Add(TopicViewModel.GetTreeNode(topic));
            }

            return treeNode;
        }

        internal static TreeNode[] GetTreeNodes(List<Area> areas)
        {
            List<TreeNode> treeNodes = new List<TreeNode>(areas.Count);
            foreach (Area area in areas)
            {
                treeNodes.Add(GetTreeNode(area));
            }

            return treeNodes.ToArray();
        }

        private static void EditAreaName_Click(object? sender, EventArgs e)
        {
            if (frmMain.MainTreeView.SelectedNode != null)
            {
                frmMain.MainTreeView.LabelEdit = true;
                frmMain.MainTreeView.SelectedNode.BeginEdit();
            }
        }

    }
}
