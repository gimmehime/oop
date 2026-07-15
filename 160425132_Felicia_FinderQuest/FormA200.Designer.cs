namespace _160425132_Felicia_FinderQuest
{
	partial class FormA200
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormA200));
			this.buttonCoverEyes = new System.Windows.Forms.Button();
			this.buttonViewMonitor = new System.Windows.Forms.Button();
			this.pictureBoxTangan = new System.Windows.Forms.PictureBox();
			this.buttonMechanism = new System.Windows.Forms.Button();
			this.timerA200 = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTangan)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonCoverEyes
			// 
			this.buttonCoverEyes.Font = new System.Drawing.Font("Perpetua Titling MT", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonCoverEyes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.buttonCoverEyes.Location = new System.Drawing.Point(111, 475);
			this.buttonCoverEyes.Name = "buttonCoverEyes";
			this.buttonCoverEyes.Size = new System.Drawing.Size(363, 67);
			this.buttonCoverEyes.TabIndex = 1;
			this.buttonCoverEyes.Text = "Cover Eyes";
			this.buttonCoverEyes.UseVisualStyleBackColor = true;
			this.buttonCoverEyes.Click += new System.EventHandler(this.buttonCoverEyes_Click);
			// 
			// buttonViewMonitor
			// 
			this.buttonViewMonitor.Font = new System.Drawing.Font("Perpetua Titling MT", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonViewMonitor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.buttonViewMonitor.Location = new System.Drawing.Point(513, 475);
			this.buttonViewMonitor.Name = "buttonViewMonitor";
			this.buttonViewMonitor.Size = new System.Drawing.Size(477, 67);
			this.buttonViewMonitor.TabIndex = 2;
			this.buttonViewMonitor.Text = "View Monitor➡";
			this.buttonViewMonitor.UseVisualStyleBackColor = true;
			this.buttonViewMonitor.Click += new System.EventHandler(this.buttonViewMonitor_Click);
			// 
			// pictureBoxTangan
			// 
			this.pictureBoxTangan.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxTangan.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxTangan.Image")));
			this.pictureBoxTangan.Location = new System.Drawing.Point(-228, -170);
			this.pictureBoxTangan.Name = "pictureBoxTangan";
			this.pictureBoxTangan.Size = new System.Drawing.Size(1557, 866);
			this.pictureBoxTangan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxTangan.TabIndex = 3;
			this.pictureBoxTangan.TabStop = false;
			this.pictureBoxTangan.Visible = false;
			// 
			// buttonMechanism
			// 
			this.buttonMechanism.Image = ((System.Drawing.Image)(resources.GetObject("buttonMechanism.Image")));
			this.buttonMechanism.Location = new System.Drawing.Point(959, 57);
			this.buttonMechanism.Name = "buttonMechanism";
			this.buttonMechanism.Size = new System.Drawing.Size(103, 138);
			this.buttonMechanism.TabIndex = 0;
			this.buttonMechanism.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.buttonMechanism.UseVisualStyleBackColor = true;
			this.buttonMechanism.Click += new System.EventHandler(this.buttonMechanism_Click);
			// 
			// timerA200
			// 
			this.timerA200.Interval = 1000;
			this.timerA200.Tick += new System.EventHandler(this.timerA200_Tick);
			// 
			// FormA200
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::_160425132_Felicia_FinderQuest.Properties.Resources.BgA200;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1100, 563);
			this.Controls.Add(this.buttonViewMonitor);
			this.Controls.Add(this.buttonCoverEyes);
			this.Controls.Add(this.buttonMechanism);
			this.Controls.Add(this.pictureBoxTangan);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormA200";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(this.FormOffice_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTangan)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonMechanism;
		private System.Windows.Forms.Button buttonCoverEyes;
		private System.Windows.Forms.Button buttonViewMonitor;
		private System.Windows.Forms.PictureBox pictureBoxTangan;
		private System.Windows.Forms.Timer timerA200;
	}
}