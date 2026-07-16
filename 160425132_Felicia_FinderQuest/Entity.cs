using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using WMPLib;

namespace _160425132_Felicia_FinderQuest
{
	public class Entity
	{
		#region data member
		private PictureBox idle;
		private PictureBox jumpscare;
		private WindowsMediaPlayer soundApproaching;
		private WindowsMediaPlayer soundNearby;
		private WindowsMediaPlayer soundJumpscare;
		private WindowsMediaPlayer musicDepanPlayer;
		private List<string> soundPath;
		#endregion

		#region constructor
		public Entity(string soundpath1, string soundpath2, string soundpath3, string soundpath4, Image image1, Size size1, Point location1, Image image2, Size size2, Point location2)
		{
			this.Idle = new PictureBox();
			this.Idle.Image = image1;
			this.Idle.Size = size1;
			this.Idle.Location = location1;
			this.Jumpscare = new PictureBox();
			this.Jumpscare.Image = image1;
			this.Jumpscare.Size = size1;
			this.Jumpscare.Location = location1;

			this.SoundApproacing = new WindowsMediaPlayer();
			this.SoundNearby = new WindowsMediaPlayer();
			this.SoundJumpscare = new WindowsMediaPlayer();
			this.MusicDepanPlayer = new WindowsMediaPlayer();

			this.SoundPath = new List<string> { soundpath1, soundpath2, soundpath3, soundpath4 };
		}
		#endregion

		#region properti
		public PictureBox Idle { get => idle; set => idle = value; }
		public PictureBox Jumpscare { get => jumpscare; set => jumpscare = value; }
		public WindowsMediaPlayer SoundApproacing { get => soundApproaching; set => soundApproaching = value; }
		public WindowsMediaPlayer SoundNearby { get => soundNearby; set => soundNearby = value; }
		public WindowsMediaPlayer SoundJumpscare { get => soundJumpscare; set => soundJumpscare = value; }
		public WindowsMediaPlayer MusicDepanPlayer { get => musicDepanPlayer; set => musicDepanPlayer = value; }
		public List<string> SoundPath { get => soundPath; set => soundPath = value; }
		#endregion

		#region method
		public void DisplayEntity(Control container)
		{
			this.Idle.Parent = container;
			this.Idle.SizeMode = PictureBoxSizeMode.StretchImage;
			this.Idle.BackColor = Color.Transparent;
			this.Idle.Visible = true;
		}
		public void DisplayJumpscare(Control container)
		{
			this.Idle.Parent = container;
			this.Idle.SizeMode = PictureBoxSizeMode.StretchImage;
			this.Idle.BackColor = Color.Transparent;
			this.Idle.BringToFront();

			this.PlaySound("jumpscare");
		}

		public void HideEntity()
		{
			this.Idle.Visible = false;
		}

		public void PlaySound(string type)
		{
			if (type == "approaching")
			{
				this.SoundApproacing.URL = Application.StartupPath + this.SoundPath[0];
				this.SoundApproacing.controls.play();
			}
			else if (type == "nearby")
			{
				this.SoundNearby.URL = Application.StartupPath + this.SoundPath[1];
				this.SoundNearby.controls.play();
			}
			else if (type == "jumpscare")
			{
				this.SoundJumpscare.URL = Application.StartupPath + this.SoundPath[2];
				this.SoundJumpscare.controls.play();
			}
			else if (type == "depanPlayer")
			{
				this.MusicDepanPlayer.URL = Application.StartupPath + this.SoundPath[3];
				this.MusicDepanPlayer.controls.play();
			}
		}

		public void PauseSound()
		{
			this.MusicDepanPlayer.controls.stop();
		}
		#endregion

	}
}

//backSoundPlayer.URL = Application.StartupPath + "\\sound\\BacksoundWalkArea.mp3";
//backSoundPlayer.settings.setMode("loop", true);
//otherSoundPlayer.controls.play();

//Properties.Resources.person1, new Size(60, 90), new Point(150, 350)