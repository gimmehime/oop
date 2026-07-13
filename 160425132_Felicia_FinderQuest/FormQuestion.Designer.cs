namespace _160425132_Felicia_FinderQuest
{
    partial class FormQuestion
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
			this.labelQuestion = new System.Windows.Forms.Label();
			this.textBoxAnswer = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonSubmit = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelQuestion
			// 
			this.labelQuestion.BackColor = System.Drawing.Color.Cornsilk;
			this.labelQuestion.Font = new System.Drawing.Font("Cooper Black", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelQuestion.Location = new System.Drawing.Point(69, 42);
			this.labelQuestion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelQuestion.Name = "labelQuestion";
			this.labelQuestion.Size = new System.Drawing.Size(964, 299);
			this.labelQuestion.TabIndex = 0;
			this.labelQuestion.Text = "Question";
			this.labelQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBoxAnswer
			// 
			this.textBoxAnswer.Font = new System.Drawing.Font("Segoe Print", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxAnswer.Location = new System.Drawing.Point(311, 382);
			this.textBoxAnswer.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxAnswer.Name = "textBoxAnswer";
			this.textBoxAnswer.Size = new System.Drawing.Size(657, 48);
			this.textBoxAnswer.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(143, 380);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(147, 39);
			this.label1.TabIndex = 2;
			this.label1.Text = "Answer:";
			// 
			// buttonSubmit
			// 
			this.buttonSubmit.AutoSize = true;
			this.buttonSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.buttonSubmit.Font = new System.Drawing.Font("Modern No. 20", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonSubmit.ForeColor = System.Drawing.Color.Snow;
			this.buttonSubmit.Location = new System.Drawing.Point(743, 442);
			this.buttonSubmit.Margin = new System.Windows.Forms.Padding(4);
			this.buttonSubmit.Name = "buttonSubmit";
			this.buttonSubmit.Size = new System.Drawing.Size(225, 66);
			this.buttonSubmit.TabIndex = 3;
			this.buttonSubmit.Text = "SUBMIT";
			this.buttonSubmit.UseVisualStyleBackColor = false;
			this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
			// 
			// FormQuestion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::_160425132_Felicia_FinderQuest.Properties.Resources.backgroundQuestion;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1100, 563);
			this.Controls.Add(this.buttonSubmit);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxAnswer);
			this.Controls.Add(this.labelQuestion);
			this.DoubleBuffered = true;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FormQuestion";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Solve the Question";
			this.Load += new System.EventHandler(this.FormQuestion_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.TextBox textBoxAnswer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSubmit;
    }
}