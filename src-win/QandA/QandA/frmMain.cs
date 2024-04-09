using QandA.DbServices;
using QandA.Models;
using QandA.ViewModels;

namespace QandA
{
    public partial class frmMain : Form
    {
        public static string PostgreSqlConnectionString = "Host=localhost;Port=5432;Username=postgres;Password=P@ssword123123;Database=FlightLearning";

        // All Context Menues
        public static TreeView MainTreeView { get; set; }


        public frmMain()
        {
            InitializeComponent();
            MainTreeView = this.treeViewStudy;
        }

        private void txtArea_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAreaAdd_Click(object sender, EventArgs e)
        {
            var newArea = new Area
            {
                Id = Guid.NewGuid(),
                Name = txtArea.Text
            };

            AreaDbService areaDbService = new AreaDbService(PostgreSqlConnectionString);
            Task.Run(() => areaDbService.StoreNewArea(newArea));
            treeViewStudy.Nodes.Add(AreaViewModel.GetTreeNode(newArea));
        }

        private void fmrMain_Load(object sender, EventArgs e)
        {
            AreaDbService areaDbService = new AreaDbService(PostgreSqlConnectionString);
            List<Area> areas = Task.Run(() => areaDbService.GetAllAreas()).Result;

            treeViewStudy.Nodes.AddRange(AreaViewModel.GetTreeNodes(areas));
        }

        private void treeViewStudy_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            treeViewStudy.SelectedNode.EndEdit(false);

            if (treeViewStudy.SelectedNode.Tag is Area area)
            {
                area.Name = e.Label;
                AreaDbService areaDbService = new AreaDbService(PostgreSqlConnectionString);
                Task.Run(() => areaDbService.UpdateArea(area)).Wait();
            }

            if (treeViewStudy.SelectedNode.Tag is Topic topic)
            {
                topic.Name = e.Label;
                TopicDbService topicDbService = new TopicDbService(PostgreSqlConnectionString);
                Task.Run(() => topicDbService.UpdateTopic(topic)).Wait();
            }

        }

        private void treeViewStudy_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (sender as TreeView != null)
            {
                if (e.Node.Tag is Concept concept)
                {
                    txtConceptName.Text = concept.Name;
                    txtContent.Text = concept.ConceptText;
                    btnConceptAdd.Enabled = true;
                }
                else
                {
                    txtConceptName.Text = String.Empty;
                    txtContent.Text = String.Empty;
                    btnConceptAdd.Enabled = false;
                }
            }
        }

        private void txtConceptName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSaveConcept_Click(object sender, EventArgs e)
        {
            // Get the selected node
            TreeNode selectedNode = treeViewStudy.SelectedNode;
            if (selectedNode != null)
            {
                if (selectedNode.Tag is Concept concept)
                {
                    concept.Name = txtConceptName.Text;
                    concept.ConceptText = txtContent.Text;

                    ConceptDbService conceptDbService = new ConceptDbService(PostgreSqlConnectionString);
                    Task.Run(() => conceptDbService.UpdateConcept(concept)).Wait();

                    selectedNode.Text = concept.Name;
                }

            }
        }
    }
}
