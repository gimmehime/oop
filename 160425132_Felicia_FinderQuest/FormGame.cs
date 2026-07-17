using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace _160425132_Felicia_FinderQuest
{
    public partial class FormGame : Form
    {
        public FormGame()
        {
            InitializeComponent();
        }

		#region THE BEGINNING
		Time time;
        public Players player;
		public FormQuestion form;
		public bool won = false;

		int numOfWalkArea = 3;
        WalkAreas currentWalkArea = null;
        TalkAreas currentTalkArea = null;

        public Persons activePerson;
        Point activePersonLastLocation; // lokasi terakhir activePerson di walk area

        bool enterTalkArea = false;
        bool paused = false;

        public WindowsMediaPlayer backSoundPlayer = new WindowsMediaPlayer();  //bgm
		public WindowsMediaPlayer otherSoundPlayer;

        private void FormGame_Load(object sender, EventArgs e)
        {
			player = new Players("John", Properties.Resources.player_right, new Size(50, 80), new Point(10, 370));
			panelGame.Visible = false;
            labelTime.Visible = false;
            panelTalkArea.Visible = false;

            playPauseToolStripMenuItem.Enabled = false;
            timerTime.Interval = 1000;

            this.KeyPreview = true; // prioritaskan input pakai keyboard?
            this.DoubleBuffered = true;  // krn banyak gambar yg berubah" (berubahnya cepet banget) jadi bisa flicker jedag jedug
                                         // gambar" disusun di sebuah buffer/memori, lalu nanti bergantian?
        }
		#endregion

		#region MENU STRIP
		private void StartNewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartGame();
        }
        private void PlayPauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (playPauseToolStripMenuItem.Text == "Pause Game")
            {
                paused = true;
                timerTime.Stop();
                playPauseToolStripMenuItem.Text = "Play Game";
                backSoundPlayer.controls.pause();
            }
            else
            {
                paused = false;
                timerTime.Start();
                playPauseToolStripMenuItem.Text = "Pause Game";
                backSoundPlayer.controls.play();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
			//Application.Exit();
			this.Close();
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Press arrow key to move the player.\n\nPress Enter to talk with the person.\n\nPress y key to answer the question.\n\nPress Esc to exit the talk area.", "How to Play");
        }
		#endregion

		#region TIMER
		private void TimerTime_Tick(object sender, EventArgs e)
        {
            time.AddWithSecond(-1);

            labelTime.Text = time.DisplayData();
            if (time.Hour == 0 && time.Minute == 0 && time.Second == 0)
            {
                timerTime.Stop();
                backSoundPlayer.controls.stop();  // knp ini ga di dlm GameOver() aja
                PlaySound("lose game");

                MessageBox.Show("Game Over. Time is up.");
                GameOver();
            }
        }
		#endregion

		#region KEYBOARD KEY DOWN
		private void FormGame_KeyDown(object sender, KeyEventArgs e) // dapat dari event di window properti
        {
            int distance = 30;

            if (paused == false)
            {
				// or bisa pakai
				//if (paused)
				//{
				//	return;
				//}

				if (e.KeyCode == Keys.Right)
				{
					if (player.Picture.Location.X + player.Picture.Width >= this.Width - 20)
					{
						if (currentWalkArea.CheckFinishAllQuestions() == true)
						{
							if (currentWalkArea.NoArea < numOfWalkArea) // masih ada area selanjutnya nda?
							{
								currentWalkArea.NoArea += 1;
								GenerateWalkArea();
							}
							else
							{
								backSoundPlayer.controls.stop(); // bgm di stop dulu
								PlaySound("win game");
								MessageBox.Show("Congratulation! You win the game!");
								GameOver();
								won = true;
							}
						}
					}
					else
					{
						player.MoveRight(distance);
					}
				}
				else if (e.KeyCode == Keys.Left)
				{
					if (paused == false)
					{
						if (player.Picture.Location.X >= 10)
						{
							player.MoveLeft(distance);
						}
					}
				}
				else if (e.KeyCode == Keys.Enter)
				{
					if (currentWalkArea.CheckTouchPerson(player, out Persons touchPerson) == true)
					{
						enterTalkArea = true;  // blm tahu buat apa
						activePerson = touchPerson;
						activePersonLastLocation = activePerson.Picture.Location;
						EnterTalkArea();
					}
				}
				else if (e.KeyCode == Keys.Escape)
				{
					ExitTalkArea();
				}
				else if (e.KeyCode == Keys.Y && activePerson.SolvedStatus == false)
				{
					form = new FormQuestion();
					form.Owner = this;
					form.ShowDialog();
				}
				if (player != null)
					player.DisplayPicture(this);  // utk menampilkan player pada form
			}
        }
        #endregion

        #region METHOD (Start & Game Over)
        private void GameOver()
        {
            timerTime.Stop();

            panelGame.Visible = false;
            labelTime.Visible = false;
            startNewGameToolStripMenuItem.Enabled = true;
        }

        private void StartGame()  // start from here
        {
            panelGame.Visible = true;
            labelTime.Visible = true;
            playPauseToolStripMenuItem.Enabled = true;
            startNewGameToolStripMenuItem.Enabled = false;

            time = new Time(0, 1, 0);  // untuk set timer ke 60 dtk
            timerTime.Start();

            if (currentWalkArea != null)
            {
                currentWalkArea.RemoveAllPersons();
            }

            currentWalkArea = null;
            GenerateWalkArea(); // ciptakan walk area 1


            labelPlayer.Text = player.DisplayData();
            player.DisplayPicture(this);

            PlaySound("walk area");

            paused = false;
            playPauseToolStripMenuItem.Text = "Pause Game";
			this.Focus();
        }

		public void ResetGame()
		{
			//this.FormGame_Load(sender, e); -> gabisa krn ga dari event (cth button_click, di parameter nya ada sender dan e nya jadi bisa dipake buat FormGame_Load)
			panelGame.Visible = false;
			labelTime.Visible = false;
			panelTalkArea.Visible = false;
			this.BackgroundImage = Properties.Resources.background;
			this.backSoundPlayer.controls.stop();

			playPauseToolStripMenuItem.Enabled = false;
			player.Reset();
		}
        #endregion

        #region METHODS (Generate Area)
        private void GenerateWalkArea()
		{
			if (currentWalkArea == null)
			{
				currentWalkArea = new WalkAreas("The Barn", Properties.Resources.walkArea1, 1);

				currentWalkArea.AddPerson(1, "Anna", Properties.Resources.person1, new Size(60, 90), new Point(150, 350), "I have a question for you. Are you ready?\nPress 'y' to continue");
				currentWalkArea.AddPerson(2, "Andy", Properties.Resources.person2, new Size(60, 90), new Point(420, 350), "Can you answer my question? Let's go!\nPress 'y' to continue");
				currentWalkArea.AddPerson(3, "Bobby", Properties.Resources.person3, new Size(60, 90), new Point(600, 360), "Just answer my question please..\nPress 'y' to continue");
			}
			else if (currentWalkArea.NoArea == 2)
			{
				// hapus smua person di area sblmnya
				currentWalkArea.RemoveAllPersons();
				currentWalkArea = new WalkAreas("The Field", Properties.Resources.walkArea2, 2);

				currentWalkArea.AddPerson(4, "Rina", Properties.Resources.person4, new Size(60, 90), new Point(100, 300), "I'm sure you can answer my question\nPress 'y' to continue");
				currentWalkArea.AddPerson(5, "Tommy", Properties.Resources.person5, new Size(60, 90), new Point(450, 350), "You look so smart. Can you answer this?\nPress 'y' to continue");
			}
			else if (currentWalkArea.NoArea == 3)
			{
				currentWalkArea.RemoveAllPersons();
				currentWalkArea = new WalkAreas("The Farm", Properties.Resources.walkArea3, 3);

				currentWalkArea.AddPerson(6, "Marie", Properties.Resources.person6, new Size(60, 90), new Point(120, 380), "Answer my question carefully.. \nPress 'y' to continue");
				currentWalkArea.AddPerson(7, "Luke", Properties.Resources.person7, new Size(60, 90), new Point(470, 380), "I have a question for you.\nPress 'y' to continue");
			}

			currentWalkArea.DisplayPicture(this); // tampilin gambar walk area
			currentWalkArea.DisplayPersons(this); // tampilin person di lstPerson
			labelArea.Text = currentWalkArea.DisplayData();

			if (player != null)
			{
				player.Picture.Location = new Point(0, player.Picture.Location.Y);
			}
		}

		private void GenerateTalkArea() // cek dulu person mana yg sekarang sedang menyentuh player, then make a talk area dgn person tsb. Active person juga dikasih question sesuai noPerson yg disentuh
        {
            if (activePerson.NoPerson == 1)
            {
                currentTalkArea = new TalkAreas("Anna's House", Properties.Resources.talkArea1,activePerson);

                activePerson.AddQuestion("Solve this math equation: \n x + y = 10 \nIf x = 3, then y = ?", "7", 100);
            }
            else if (activePerson.NoPerson == 2)
			{
				currentTalkArea = new TalkAreas("Andy's Room", Properties.Resources.talkArea2, activePerson);

				activePerson.AddQuestion("What is the capital city of Indonesia?", "jakarta", 50);  //J nya kapital nda ??
			}
			else if (activePerson.NoPerson == 3)
			{
				currentTalkArea = new TalkAreas("Bobby's Office", Properties.Resources.talkArea3, activePerson);

				activePerson.AddQuestion("I have this pattern: \n1   1   2   3   5   8...\nWhat is the next number?\n", "13", 200);
			}
            else if (activePerson.NoPerson == 4)
			{
				currentTalkArea = new TalkAreas("Rina's Room", Properties.Resources.talkArea4, activePerson);

				activePerson.AddQuestion("What is the chemical compound name for sulfuric acid?", "H2SO4", 250);
			}
            else if (activePerson.NoPerson == 5)
			{
				currentTalkArea = new TalkAreas("Tommy's Place", Properties.Resources.talkArea5, activePerson);

				activePerson.AddQuestion("Check this C# codes: \nint result = 10 / 100; \nMessageBox.Show(result); \nWhat is the output of these codes?", "0", 170);
			}
            else if (activePerson.NoPerson == 6)
			{
				currentTalkArea = new TalkAreas("Marie's Place", Properties.Resources.talkArea6, activePerson);

				activePerson.AddQuestion("A product has a selling price of $100 and is discounted 10% off the list price. It also has a shipping fee of $5." +
                    "\nIf you want to purchase this product, how much will you have to pay?", "95", 300);
			}
            else if (activePerson.NoPerson == 7)
			{
				currentTalkArea = new TalkAreas("Luke's House", Properties.Resources.talkArea7, activePerson);

				activePerson.AddQuestion("What is the 1st principle (sila ke - 1) of Pancasila ?", "Ketuhanan Yang Maha Esa", 150);
			}
		}
		#endregion

		#region METHODS (Others)
		public void EnterTalkArea()
		{
			GenerateTalkArea();

			player.Picture.Visible = false;

			panelTalkArea.BackgroundImage = currentTalkArea.Background;
			panelTalkArea.Visible = true;
			panelTalkArea.BringToFront();

			activePerson.Picture.Size = new Size(200, 300);
			activePerson.Picture.Location = new Point(300, 100);
			activePerson.DisplayPicture(panelTalkArea);

			if (activePerson.SolvedStatus == true)
			{
				activePerson.Dialog = "Congratulation! \nYou have answered my question.";
			}

			activePerson.DisplayDialog(panelTalkArea);
			PlaySound("talk area");
		}

		public void ExitTalkArea()
		{
			player.Picture.Visible = true;
			enterTalkArea = false;

			panelTalkArea.Visible = false;
			activePerson.Picture.Size = new Size(60, 90);
			activePerson.Picture.Location = activePersonLastLocation;
			activePerson.DisplayPicture(this);
			PlaySound("walk area");
		}

		private void PlaySound(string type)
		{
			otherSoundPlayer = new WindowsMediaPlayer();
			if (type == "walk area")
			{
				backSoundPlayer.URL = Application.StartupPath + "\\sound\\BacksoundWalkArea.mp3";
				backSoundPlayer.settings.setMode("loop", true);
			}
			else if (type == "talk area")
			{
				backSoundPlayer.URL = Application.StartupPath + "\\sound\\BacksoundTalkArea.mp3";
				backSoundPlayer.settings.setMode("loop", true);
			}
			else if (type == "lose game")
			{
				otherSoundPlayer.URL = Application.StartupPath + "\\sound\\LoseGame.mp3";
			}
			else if (type == "win game")
			{
				otherSoundPlayer.URL = Application.StartupPath + "\\sound\\WinGame.mp3";
			}
			otherSoundPlayer.controls.play();
		}
		#endregion


		FormA200 formA200;
		public void KirimForm(FormA200 frm)
		{
			this.formA200 = frm;
		}

		private void FormGame_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;
				this.Hide();
				formA200.Show();
				formA200.bgm.controls.play();
				backSoundPlayer.controls.pause();
				if (otherSoundPlayer != null)
					otherSoundPlayer.controls.pause();
				//formA200.currentForm = "game";
			}
		}

		private void labelBackToRoom_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}

// multiline di textbox di enabled spy bisa di tinggiin, autosize dimatiin di label spy bisa ganti size
