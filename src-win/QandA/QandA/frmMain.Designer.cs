namespace QandA
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtContent = new TextBox();
            lstReferences = new ListView();
            txtReference = new TextBox();
            btnReferenceAdd = new Button();
            txtConceptAdd = new TextBox();
            btnConceptAdd = new Button();
            btnAreaAdd = new Button();
            txtArea = new TextBox();
            treeViewStudy = new TreeView();
            txtConceptName = new TextBox();
            btnSaveConcept = new Button();
            SuspendLayout();
            // 
            // txtContent
            // 
            txtContent.Location = new Point(358, 41);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(1051, 662);
            txtContent.TabIndex = 3;
            // 
            // lstReferences
            // 
            lstReferences.Location = new Point(358, 709);
            lstReferences.Name = "lstReferences";
            lstReferences.Size = new Size(1051, 202);
            lstReferences.TabIndex = 4;
            lstReferences.UseCompatibleStateImageBehavior = false;
            // 
            // txtReference
            // 
            txtReference.Location = new Point(358, 917);
            txtReference.Name = "txtReference";
            txtReference.Size = new Size(970, 23);
            txtReference.TabIndex = 5;
            // 
            // btnReferenceAdd
            // 
            btnReferenceAdd.Location = new Point(1334, 922);
            btnReferenceAdd.Name = "btnReferenceAdd";
            btnReferenceAdd.Size = new Size(75, 23);
            btnReferenceAdd.TabIndex = 6;
            btnReferenceAdd.Text = "Add";
            btnReferenceAdd.UseVisualStyleBackColor = true;
            // 
            // txtConceptAdd
            // 
            txtConceptAdd.Location = new Point(12, 917);
            txtConceptAdd.Name = "txtConceptAdd";
            txtConceptAdd.Size = new Size(252, 23);
            txtConceptAdd.TabIndex = 7;
            // 
            // btnConceptAdd
            // 
            btnConceptAdd.Location = new Point(277, 916);
            btnConceptAdd.Name = "btnConceptAdd";
            btnConceptAdd.Size = new Size(75, 23);
            btnConceptAdd.TabIndex = 8;
            btnConceptAdd.Text = "Add";
            btnConceptAdd.UseVisualStyleBackColor = true;
            // 
            // btnAreaAdd
            // 
            btnAreaAdd.Location = new Point(322, 12);
            btnAreaAdd.Name = "btnAreaAdd";
            btnAreaAdd.Size = new Size(30, 23);
            btnAreaAdd.TabIndex = 10;
            btnAreaAdd.Text = "+";
            btnAreaAdd.UseVisualStyleBackColor = true;
            btnAreaAdd.Click += btnAreaAdd_Click;
            // 
            // txtArea
            // 
            txtArea.Location = new Point(12, 12);
            txtArea.Name = "txtArea";
            txtArea.Size = new Size(304, 23);
            txtArea.TabIndex = 9;
            txtArea.TextChanged += txtArea_TextChanged;
            // 
            // treeViewStudy
            // 
            treeViewStudy.Location = new Point(12, 41);
            treeViewStudy.Name = "treeViewStudy";
            treeViewStudy.Size = new Size(340, 869);
            treeViewStudy.TabIndex = 11;
            treeViewStudy.AfterLabelEdit += treeViewStudy_AfterLabelEdit;
            treeViewStudy.AfterSelect += treeViewStudy_AfterSelect;
            // 
            // txtConceptName
            // 
            txtConceptName.Location = new Point(358, 12);
            txtConceptName.Name = "txtConceptName";
            txtConceptName.Size = new Size(1008, 23);
            txtConceptName.TabIndex = 12;
            txtConceptName.TextChanged += txtConceptName_TextChanged;
            // 
            // btnSaveConcept
            // 
            btnSaveConcept.Location = new Point(1379, 11);
            btnSaveConcept.Name = "btnSaveConcept";
            btnSaveConcept.Size = new Size(30, 23);
            btnSaveConcept.TabIndex = 13;
            btnSaveConcept.Text = "+";
            btnSaveConcept.UseVisualStyleBackColor = true;
            btnSaveConcept.Click += btnSaveConcept_Click;
            // 
            // fmrMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1436, 966);
            Controls.Add(btnSaveConcept);
            Controls.Add(txtConceptName);
            Controls.Add(treeViewStudy);
            Controls.Add(btnAreaAdd);
            Controls.Add(txtArea);
            Controls.Add(btnConceptAdd);
            Controls.Add(txtConceptAdd);
            Controls.Add(btnReferenceAdd);
            Controls.Add(txtReference);
            Controls.Add(lstReferences);
            Controls.Add(txtContent);
            Name = "fmrMain";
            Text = "Form1";
            Load += fmrMain_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtContent;
        private ListView lstReferences;
        private TextBox txtReference;
        private Button btnReferenceAdd;
        private TextBox txtConceptAdd;
        private Button btnConceptAdd;
        private Button btnAreaAdd;
        private TextBox txtArea;
        private TreeView treeViewStudy;
        private TextBox txtConceptName;
        private Button btnSaveConcept;
    }
}
