namespace QandA
{
    partial class fmrMain
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
            lstAreas = new ListView();
            lstTopic = new ListView();
            lstConcepts = new ListView();
            txtContent = new TextBox();
            lstReferences = new ListView();
            txtReference = new TextBox();
            btnReferenceAdd = new Button();
            txtConceptAdd = new TextBox();
            btnConceptAdd = new Button();
            SuspendLayout();
            // 
            // lstAreas
            // 
            lstAreas.Location = new Point(12, 12);
            lstAreas.Name = "lstAreas";
            lstAreas.Size = new Size(340, 196);
            lstAreas.TabIndex = 0;
            lstAreas.UseCompatibleStateImageBehavior = false;
            // 
            // lstTopic
            // 
            lstTopic.Location = new Point(12, 214);
            lstTopic.Name = "lstTopic";
            lstTopic.Size = new Size(340, 295);
            lstTopic.TabIndex = 1;
            lstTopic.UseCompatibleStateImageBehavior = false;
            // 
            // lstConcepts
            // 
            lstConcepts.Location = new Point(12, 515);
            lstConcepts.Name = "lstConcepts";
            lstConcepts.Size = new Size(340, 396);
            lstConcepts.TabIndex = 2;
            lstConcepts.UseCompatibleStateImageBehavior = false;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(358, 12);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(1051, 691);
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
            // fmrMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1436, 966);
            Controls.Add(btnConceptAdd);
            Controls.Add(txtConceptAdd);
            Controls.Add(btnReferenceAdd);
            Controls.Add(txtReference);
            Controls.Add(lstReferences);
            Controls.Add(txtContent);
            Controls.Add(lstConcepts);
            Controls.Add(lstTopic);
            Controls.Add(lstAreas);
            Name = "fmrMain";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lstAreas;
        private ListView lstTopic;
        private ListView lstConcepts;
        private TextBox txtContent;
        private ListView lstReferences;
        private TextBox txtReference;
        private Button btnReferenceAdd;
        private TextBox txtConceptAdd;
        private Button btnConceptAdd;
    }
}
