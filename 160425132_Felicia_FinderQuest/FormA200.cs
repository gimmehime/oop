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
		WindowsMediaPlayer napas = new WindowsMediaPlayer();
		int timerEntity;
		Entity entity = new Entity("\\sound\\ApproachingAudio.wav", "\\sound\\NearbyAudio.wav", "\\sound\\JumpscareAudio.mp3", "\\sound\\DepanPlayer.mp3", Properties.Resources.Idle, new Size(350, 605), new Point(150, 25), Properties.Resources.Jumpscare, new Size(900, 500), new Point(0, 0));

		private void FormOffice_Load(object sender, EventArgs e)
		{
			bgm.URL = Application.StartupPath + "\\sound\\OfficeBGM.mp3";
			bgm.settings.setMode("loop", true);

			GenerateInterval();
			timerEntity = 0;
			timerA200.Interval = 1000;
			timerA200.Start();
			timerJumpscare.Stop();
			timerWon.Stop();
			timerKetTimesUp.Stop();

			panelGameOver.SendToBack();
			panelGameOver.Enabled = false;
			panelGameOver.Visible = false;

			this.DoubleBuffered = true;
		
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
				napas.controls.stop();
			}
			else
			{
				buttonViewMonitor.Enabled = false;
				pictureBoxTangan.Visible = true;
				pictureBoxTangan.BringToFront();
				napas.URL = Application.StartupPath + "\\sound\\nafas.mp3";
				napas.settings.setMode("loop", true);
				tanganAda = true;
			}
		}

		private void pictureBoxTangan_Click(object sender, EventArgs e)
		{
			// Klik gambar tangan = sama seperti klik Cover Eyes (buka tangan)
			buttonCoverEyes_Click(sender, e);
		}
		#endregion

		#region GANTI FORM
		FormGame formGame = new FormGame();
		int monitorCooldown = 0; // countdown sebelum View Monitor bisa diklik lagi
		bool gameTimeUp = false; // apakah Finder Quest game over karena waktu habis
		private void buttonViewMonitor_Click(object sender, EventArgs e)
		{
			// Kalau baru balik dari game over, reset waktu game dulu
			if (gameTimeUp)
			{
				formGame.ResetGameTime();
				gameTimeUp = false;
			}

			// Timer hantu TETAP JALAN selama di FormGame
			bgm.controls.pause();
			if (formGame.otherSoundPlayer != null)
			{
				if (formGame.otherSoundPlayer.playState != WMPPlayState.wmppsPaused)
					formGame.backSoundPlayer.controls.play();
				else
					formGame.otherSoundPlayer.controls.play();
			}
			else
			{
				formGame.backSoundPlayer.controls.play();
			}

			formGame.KirimForm(this);
			formGame.Show();
			this.Hide();
		}
		#endregion

		#region TIMER
		int timeApproaching, timeNearby, timePresent;
		bool generateAgain = false, entityPresent = false;
		private void timerA200_Tick(object sender, EventArgs e)
		{
			timerEntity++;
			CheckTime();
			CheckTangan();

			// Countdown monitor cooldown (setelah finder quest game over)
			if (monitorCooldown > 0)
			{
				monitorCooldown--;
				buttonViewMonitor.Text = "Wait... (" + monitorCooldown + "s)";
				if (monitorCooldown == 0)
				{
					buttonViewMonitor.Enabled = true;
					buttonViewMonitor.Text = "View Monitor➡";
					timerEntity = 0;
					generateAgain = true;
					//entity.HideEntity();
				}
			}

			if (formGame.won)
			{
				timerA200.Stop();
				timerWon.Start();
			}
		}
		private void timerWon_Tick(object sender, EventArgs e)
		{
			timerWon.Stop();
			formGame.Close();
			this.bgm.controls.stop();
			FormOutro form = new FormOutro();
			this.Hide();
			form.Show();
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
			else if (timerEntity == timeApproaching + timeNearby + timePresent) // entity present
			{
				this.bgm.controls.pause();
				entity.DisplayEntity(this);
				entity.PlaySound("depanPlayer");
			}
			else if (timerEntity == timeApproaching + timeNearby + timePresent + 1)  // tunggu 1 detik supaya player bisa react
			{
				entityPresent = true;
			}
		}

		private void GenerateInterval()
		{
			timeApproaching = rnd.Next(7, 15);
			timeNearby = rnd.Next(13, 19);
			timePresent = 6;
		}

		private void CheckTangan()
		{
			if (entityPresent)
			{
				if (tanganAda == false)
				{
					// Tidak tutup mata saat hantu datang → Game Over
					timerA200.Stop();
					GameOver();
				}
				else
				{
					// Berhasil tutup mata → hantu hilang, generate waktu muncul lagi
					if (monitorCooldown == 0)  // kalau entitas tidak sedang agresif, maka generate again
						generateAgain = true;
					timerEntity = 0;
					this.bgm.controls.play();
					entity.HideEntity();
					entityPresent = false;
				}
			}
		}
		#endregion

		#region GAME OVER
		private void timerJumpscare_Tick(object sender, EventArgs e)
		{
			timerJumpscare.Stop();

			entity.HideJumpscare();
			generateAgain = true;
			timerEntity = 0;
			panelGameOver.Enabled = true;
			panelGameOver.Visible = true;
			panelGameOver.BringToFront();
		}

		private void GameOver()
		{
			formGame.tutup = true;
			formGame.Close();
			if (formGame.form != null)
			{
				formGame.form.Close();
			}
			formGame.backSoundPlayer.controls.pause();
			if (formGame.otherSoundPlayer != null)
				formGame.otherSoundPlayer.controls.pause();
			this.Show();
			this.bgm.controls.stop();

			entity.HideEntity();
			entity.MusicDepanPlayer.controls.stop();
			entity.DisplayJumpscare(this);
			timerJumpscare.Start();
		}

		private void buttonTryAgain_Click(object sender, EventArgs e)
		{
			this.FormOffice_Load(sender, e);
			entityPresent = false;
			formGame.tutup = false;
			formGame = new FormGame();
		}

		private void buttonExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
		#endregion

		#region WAKTU FINDER QUEST HABIS
		// Dipanggil dari FormGame saat waktu habis
		public void HandleGameTimeUp()
		{
			// Sembunyikan FormGame, tampilkan FormA200
			formGame.backSoundPlayer.controls.pause();
			if (formGame.otherSoundPlayer != null)
				formGame.otherSoundPlayer.controls.stop();
			formGame.Hide();
			this.Show();
			this.bgm.controls.play();

			// Disable View Monitor selama 15 detik
			buttonViewMonitor.Enabled = false;
			monitorCooldown = 15;
			gameTimeUp = true;

			// Hantu jadi SUPER agresif selama menunggu!
			timerEntity = 0;
			timeApproaching = 2;  // approaching di detik ke-2
			timeNearby = 1;       // nearby di detik ke-3
			timePresent = 3;      // tampil di detik ke-6

			labelKetTimesUp.Visible = true;
			timerKetTimesUp.Start();
		}

		private void timerKetTimesUp_Tick(object sender, EventArgs e)
		{
			timerKetTimesUp.Stop();
			labelKetTimesUp.Visible = false;
		}
		#endregion

		public FormIntro frmIntro = new FormIntro();
		private void FormA200_FormClosing(object sender, FormClosingEventArgs e)
		{
			frmIntro.Close();
		}
	}
}


//#region Discarded codes
//// Dipanggil saat hantu muncul dan player sedang di FormGame → paksa balik ke ruangan
////private void ForceReturnFromGame()
////{
////	formGame.backSoundPlayer.controls.pause();
////	if (formGame.otherSoundPlayer != null)
////		formGame.otherSoundPlayer.controls.pause();
////	formGame.Hide();
////	this.Show();
////}
//#endregion