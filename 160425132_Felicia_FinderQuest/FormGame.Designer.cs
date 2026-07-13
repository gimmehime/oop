namespace _160425132_Felicia_FinderQuest
{
    partial class FormGame
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startNewGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.playPauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.timerTime = new System.Windows.Forms.Timer(this.components);
			this.panelGame = new System.Windows.Forms.Panel();
			this.panelTalkArea = new System.Windows.Forms.Panel();
			this.labelPlayer = new System.Windows.Forms.Label();
			this.labelTime = new System.Windows.Forms.Label();
			this.labelArea = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.panelGame.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1100, 28);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// gameToolStripMenuItem
			// 
			this.gameToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startNewGameToolStripMenuItem,
            this.playPauseToolStripMenuItem});
			this.gameToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
			this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
			this.gameToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
			this.gameToolStripMenuItem.Text = "Game";
			// 
			// startNewGameToolStripMenuItem
			// 
			this.startNewGameToolStripMenuItem.Name = "startNewGameToolStripMenuItem";
			this.startNewGameToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
			this.startNewGameToolStripMenuItem.Text = "Start New Game";
			this.startNewGameToolStripMenuItem.Click += new System.EventHandler(this.StartNewGameToolStripMenuItem_Click);
			// 
			// playPauseToolStripMenuItem
			// 
			this.playPauseToolStripMenuItem.Name = "playPauseToolStripMenuItem";
			this.playPauseToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
			this.playPauseToolStripMenuItem.Text = "Play/Pause";
			this.playPauseToolStripMenuItem.Click += new System.EventHandler(this.PlayPauseToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
			this.helpToolStripMenuItem.Text = "Help";
			this.helpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
			// 
			// timerTime
			// 
			this.timerTime.Tick += new System.EventHandler(this.TimerTime_Tick);
			// 
			// panelGame
			// 
			this.panelGame.BackColor = System.Drawing.Color.Transparent;
			this.panelGame.Controls.Add(this.labelPlayer);
			this.panelGame.Controls.Add(this.labelTime);
			this.panelGame.Controls.Add(this.labelArea);
			this.panelGame.Location = new System.Drawing.Point(0, 33);
			this.panelGame.Margin = new System.Windows.Forms.Padding(4);
			this.panelGame.Name = "panelGame";
			this.panelGame.Size = new System.Drawing.Size(1100, 90);
			this.panelGame.TabIndex = 1;
			// 
			// panelTalkArea
			// 
			this.panelTalkArea.BackColor = System.Drawing.Color.Transparent;
			this.panelTalkArea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panelTalkArea.Location = new System.Drawing.Point(0, 125);
			this.panelTalkArea.Margin = new System.Windows.Forms.Padding(4);
			this.panelTalkArea.Name = "panelTalkArea";
			this.panelTalkArea.Size = new System.Drawing.Size(1100, 441);
			this.panelTalkArea.TabIndex = 2;
			this.panelTalkArea.Visible = false;
			// 
			// labelPlayer
			// 
			this.labelPlayer.AutoSize = true;
			this.labelPlayer.Font = new System.Drawing.Font("Myanmar Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPlayer.ForeColor = System.Drawing.Color.Snow;
			this.labelPlayer.Location = new System.Drawing.Point(924, 10);
			this.labelPlayer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelPlayer.Name = "labelPlayer";
			this.labelPlayer.Size = new System.Drawing.Size(105, 30);
			this.labelPlayer.TabIndex = 2;
			this.labelPlayer.Text = "labeLPlayer";
			// 
			// labelTime
			// 
			this.labelTime.AutoSize = true;
			this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTime.ForeColor = System.Drawing.Color.Tomato;
			this.labelTime.Location = new System.Drawing.Point(418, 10);
			this.labelTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelTime.Name = "labelTime";
			this.labelTime.Size = new System.Drawing.Size(265, 54);
			this.labelTime.TabIndex = 1;
			this.labelTime.Text = "00 : 00 : 00";
			// 
			// labelArea
			// 
			this.labelArea.AutoSize = true;
			this.labelArea.Font = new System.Drawing.Font("Myanmar Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelArea.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.labelArea.Location = new System.Drawing.Point(31, 10);
			this.labelArea.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelArea.Name = "labelArea";
			this.labelArea.Size = new System.Drawing.Size(89, 30);
			this.labelArea.TabIndex = 0;
			this.labelArea.Text = "labelArea";
			// 
			// FormGame
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::_160425132_Felicia_FinderQuest.Properties.Resources.background;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1100, 563);
			this.Controls.Add(this.panelTalkArea);
			this.Controls.Add(this.panelGame);
			this.Controls.Add(this.menuStrip1);
			this.DoubleBuffered = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FormGame";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Finder Quest Game";
			this.Load += new System.EventHandler(this.FormGame_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormGame_KeyDown);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panelGame.ResumeLayout(false);
			this.panelGame.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Timer timerTime;
        private System.Windows.Forms.Panel panelGame;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelArea;
        private System.Windows.Forms.Panel panelTalkArea;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startNewGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playPauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		public System.Windows.Forms.Label labelPlayer;
	}
}

