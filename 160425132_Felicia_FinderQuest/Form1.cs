using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxWMPLib;

namespace _160425132_Felicia_FinderQuest
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.FormBorderStyle = FormBorderStyle.None;
			this.WindowState = FormWindowState.Maximized; // bikin size form sebesar layar
			axWindowsMediaPlayer1.uiMode = "none";
			axWindowsMediaPlayer1.Dock = DockStyle.Fill; // bikin size video sebesar layar
			string videoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Vid1.mp4");

			if (File.Exists(videoPath))
			{
				axWindowsMediaPlayer1.URL = videoPath;
				axWindowsMediaPlayer1.Ctlcontrols.play();
			}
			else
			{
				MessageBox.Show("File video tidak ditemukan di bin/Debug.");
				BukaMainMenu();
			}
		}

		FormOffice f2;
		private void BukaMainMenu()
		{
			MessageBox.Show("Masuk ke gamee");
			this.Hide();
			f2 = new FormOffice();
			f2.Show();
		}

		private void axWindowsMediaPlayer1_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
		{
			if (e.newState == 8)
			{
				BukaMainMenu();
			}
		}
	}
}
