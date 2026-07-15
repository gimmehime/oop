using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace _160425132_Felicia_FinderQuest
{
	public partial class FormA200 : Form
	{
		public FormA200()
		{
			InitializeComponent();
		}


		Random rnd = new Random();
		public WindowsMediaPlayer bgm = new WindowsMediaPlayer();
		int entityTimer;
		Entity entity = new Entity("\\sound\\ApproachindAudio.wav", "\\sound\\NearbyAudio.wav", "\\sound\\JumpscareAudio.wav", "\\sound\\DepanPlayer.flac", Properties.Resources.Idle, new Size(650, 500), new Point(234, 0), Properties.Resources.Jumpscare, new Size(650, 500), new Point(234, 0));

		private void FormOffice_Load(object sender, EventArgs e)
		{
			entityTimer = 0;
			bgm.URL = Application.StartupPath + "\\sound\\OfficeBGM.flac";
			bgm.settings.setMode("loop", true);
		}

		private void buttonMechanism_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Hide your eyes when IT is present.");
		}

		bool tanganAda = false;
		private void buttonCoverEyes_Click(object sender, EventArgs e)
		{
			if (tanganAda)
			{
				buttonViewMonitor.Enabled = true;
				pictureBoxTangan.Visible = false;
				tanganAda = false;
			}
			else
			{
				buttonViewMonitor.Enabled = false;
				pictureBoxTangan.Visible = true;
				tanganAda = true;
			}
		}

		FormGame formGame = new FormGame();
		//FormQuestion formQuestion = new FormQuestion();
		//public string currentForm;
		private void buttonViewMonitor_Click(object sender, EventArgs e)
		{
			bgm.controls.pause();
			if (formGame.otherSoundPlayer != null)
			{
				formGame.otherSoundPlayer.controls.play();
				if (formGame.otherSoundPlayer.playState != WMPPlayState.wmppsPlaying) // klo other sound tidak lagi main
					formGame.backSoundPlayer.controls.play();
			}
			else
			{
				formGame.backSoundPlayer.controls.play();
			}

			formGame.KirimForm(this);
			formGame.Show();
			this.Hide();

			//if (currentForm == null || currentForm == "game")
			//{
				
			//}
			////else if (currentForm == "question")
			//{
			//	formQuestion.KirimForm(this);
			//	formQuestion.changeForm = false;
			//	formQuestion.Show();
			//	this.Hide();
			//}
		// what will happen to formgame klo tutup form question after pindah ke ruangan n balik lagi			
		}

		private void timerA200_Tick(object sender, EventArgs e)
		{

		}

		private void GenerateInterval(out int timeApproaching, out int timeNearby, out int durationPresent)
		{
			timeApproaching = rnd.Next(15, 26);
			timeNearby = rnd.Next(15, 21);
			durationPresent = rnd.Next(7, 13);
		}



		//Properties.Resources.person1, new Size(60, 90), new Point(150, 350)
		// 1118, 610
	}
}
