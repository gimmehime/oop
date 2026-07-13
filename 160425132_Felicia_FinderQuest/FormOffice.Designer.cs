namespace _160425132_Felicia_FinderQuest
{
	partial class FormOffice
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
			this.buttonMechanism = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttonMechanism
			// 
			this.buttonMechanism.Location = new System.Drawing.Point(958, 50);
			this.buttonMechanism.Name = "buttonMechanism";
			this.buttonMechanism.Size = new System.Drawing.Size(72, 116);
			this.buttonMechanism.TabIndex = 0;
			this.buttonMechanism.Text = "-- --- -----";
			this.buttonMechanism.UseVisualStyleBackColor = true;
			this.buttonMechanism.Click += new System.EventHandler(this.buttonMechanism_Click);
			// 
			// FormOffice
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1100, 563);
			this.Controls.Add(this.buttonMechanism);
			this.Name = "FormOffice";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "The Office";
			this.Load += new System.EventHandler(this.FormOffice_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonMechanism;
	}
}