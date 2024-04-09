namespace QandA
{
    partial class frmTrivia
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtQuestion = new TextBox();
            radioOption1 = new RadioButton();
            radioOption2 = new RadioButton();
            radioOption3 = new RadioButton();
            radioOption4 = new RadioButton();
            lstQuestions = new ListBox();
            btnNext = new Button();
            SuspendLayout();
            // 
            // txtQuestion
            // 
            txtQuestion.Location = new Point(240, 17);
            txtQuestion.Multiline = true;
            txtQuestion.Name = "txtQuestion";
            txtQuestion.Size = new Size(809, 69);
            txtQuestion.TabIndex = 0;
            // 
            // radioOption1
            // 
            radioOption1.AutoSize = true;
            radioOption1.Location = new Point(275, 92);
            radioOption1.Name = "radioOption1";
            radioOption1.Size = new Size(94, 19);
            radioOption1.TabIndex = 2;
            radioOption1.TabStop = true;
            radioOption1.Text = "radioButton1";
            radioOption1.UseVisualStyleBackColor = true;
            radioOption1.CheckedChanged += radioOption_Clicked;
            // 
            // radioOption2
            // 
            radioOption2.AutoSize = true;
            radioOption2.Location = new Point(275, 117);
            radioOption2.Name = "radioOption2";
            radioOption2.Size = new Size(94, 19);
            radioOption2.TabIndex = 3;
            radioOption2.TabStop = true;
            radioOption2.Text = "radioButton1";
            radioOption2.UseVisualStyleBackColor = true;
            radioOption2.CheckedChanged += radioOption_Clicked;
            // 
            // radioOption3
            // 
            radioOption3.AutoSize = true;
            radioOption3.Location = new Point(275, 142);
            radioOption3.Name = "radioOption3";
            radioOption3.Size = new Size(94, 19);
            radioOption3.TabIndex = 4;
            radioOption3.TabStop = true;
            radioOption3.Text = "radioButton1";
            radioOption3.UseVisualStyleBackColor = true;
            radioOption3.CheckedChanged += radioOption_Clicked;
            // 
            // radioOption4
            // 
            radioOption4.AutoSize = true;
            radioOption4.Location = new Point(275, 167);
            radioOption4.Name = "radioOption4";
            radioOption4.Size = new Size(94, 19);
            radioOption4.TabIndex = 5;
            radioOption4.TabStop = true;
            radioOption4.Text = "radioButton1";
            radioOption4.UseVisualStyleBackColor = true;
            radioOption4.CheckedChanged += radioOption_Clicked;
            // 
            // lstQuestions
            // 
            lstQuestions.FormattingEnabled = true;
            lstQuestions.ItemHeight = 15;
            lstQuestions.Location = new Point(12, 17);
            lstQuestions.Name = "lstQuestions";
            lstQuestions.Size = new Size(222, 379);
            lstQuestions.TabIndex = 6;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(953, 206);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(62, 26);
            btnNext.TabIndex = 7;
            btnNext.Text = "Next";
            btnNext.TextAlign = ContentAlignment.BottomLeft;
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // frmTrivia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1056, 410);
            Controls.Add(btnNext);
            Controls.Add(lstQuestions);
            Controls.Add(radioOption4);
            Controls.Add(radioOption3);
            Controls.Add(radioOption2);
            Controls.Add(radioOption1);
            Controls.Add(txtQuestion);
            Name = "frmTrivia";
            Text = "frmTrivia";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtQuestion;
        private RadioButton radioOption1;
        private RadioButton radioOption2;
        private RadioButton radioOption3;
        private RadioButton radioOption4;
        private ListBox lstQuestions;
        private Button btnNext;
    }
}