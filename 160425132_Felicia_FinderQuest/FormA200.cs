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
		int timerEntity;
		Entity entity = new Entity("\\sound\\ApproachingAudio.wav", "\\sound\\NearbyAudio.wav", "\\sound\\JumpscareAudio.wav", "\\sound\\DepanPlayer.mp3", Properties.Resources.Idle, new Size(550, 500), new Point(130, 0), Properties.Resources.Jumpscare, new Size(650, 500), new Point(234, 0));

		private void FormOffice_Load(object sender, EventArgs e)
		{
			bgm.URL = Application.StartupPath + "\\sound\\OfficeBGM.mp3";
			bgm.settings.setMode("loop", true);
			GenerateInterval();
			timerEntity = 0;
			timerA200.Interval = 1000;
			timerA200.Start();
			panelGameOver.SendToBack();
			timeJumpscare = 0;
			panelGameOver.Visible = false;
		}

		#region TANGAN & MEKANISME BUTTON
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
		#endregion

		#region GANTI FORM
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
		#endregion

		#region TIMER
		int timeApproaching, timeNearby, durationPresent;
		bool generateAgain = false, entityPresent = false;
		private void timerA200_Tick(object sender, EventArgs e)
		{
			timerEntity++;
			CheckTime();
			CheckTangan();
		}

		private void CheckTime()
		{
			if (generateAgain)
			{
				GenerateInterval();
				generateAgain = false;
			}
			if (timerEntity == timeApproaching) // sound 1
			{
				entity.PlaySound("approaching");
			}
			else if (timerEntity == timeApproaching + timeNearby) // sound 2
			{
				entity.PlaySound("nearby");
			}
			else if (timerEntity == timeApproaching + timeNearby + 6) // entity present
			{
				this.bgm.controls.pause();
				entity.PlaySound("depanPlayer");
				entity.DisplayEntity(this);
			}
			else if (timerEntity == timeApproaching + timeNearby + 7)
			{
				entityPresent = true;
			}
			else if(timerEntity == timeApproaching + timeNearby + 6 + durationPresent) // ngulang
			{
				generateAgain = true;
				timerEntity = 0;
				this.bgm.controls.play();
				entity.MusicDepanPlayer.controls.stop();
				entity.HideEntity();
				entityPresent = false;
			}
		}

		private void buttonTryAgain_Click(object sender, EventArgs e)
		{
			this.FormOffice_Load(sender, e);
			entity.MusicDepanPlayer.controls.stop();
			entity.HideEntity();
			entityPresent = false;

		}

		private void buttonExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void GenerateInterval()
		{
			//timeApproaching = rnd.Next(15, 31);
			//timeNearby = rnd.Next(15, 21);
			//durationPresent = rnd.Next(7, 16);
			timeApproaching = 2;
			timeNearby = 2;
			durationPresent = 7;
		}

		private void CheckTangan()
		{
			if (entityPresent)
			{
				if (tanganAda == false)
				{
					timerA200.Stop();
					GameOver();
				}
			}
		}

		int timeJumpscare;
		private void GameOver()
		{
			entity.DisplayJumpscare(this); // this taro di check tangan?
			// iki yaapa biar nunggu 2 dtk baru panel game over
			panelGameOver.Enabled = true;
			panelGameOver.Visible = true;
			panelGameOver.BringToFront();
		}
		#endregion


		// pas jumpscare, form question n game di hide and paused, pas retry, form game juga retry
		//Properties.Resources.person1, new Size(60, 90), new Point(150, 350)
		// 1118, 610
	}
}
