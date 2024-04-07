using QandA.DbServices;
using QandA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QandA.ViewModels
{
    internal class ConceptViewModel
    {
        internal static TreeNode GetTreeNode(Concept concept)
        {
            var treeNode = new TreeNode
            {
                Text = concept.Name,
                Tag = concept,
            };

            return treeNode;
        }
    }
}
