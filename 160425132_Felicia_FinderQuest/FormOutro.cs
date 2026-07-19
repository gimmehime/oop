using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _160425132_Felicia_FinderQuest;
using AxWMPLib;

namespace _160425132_Felicia_FinderQuest
{
	public partial class FormOutro : Form
	{
		public FormOutro()
		{
			InitializeComponent();
		}

		private void FormOutro_Load(object sender, EventArgs e)
		{
			this.FormBorderStyle = FormBorderStyle.None;
			this.WindowState = FormWindowState.Maximized; // size form sebesar layar
			axWindowsMediaPlayer1.uiMode = "none";
			axWindowsMediaPlayer1.Dock = DockStyle.Fill; // size video sebesar layar
			string videoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Outro.mp4");

			if (File.Exists(videoPath))
			{
				axWindowsMediaPlayer1.URL = videoPath;
				axWindowsMediaPlayer1.Ctlcontrols.play();
			}
			else
			{
				MessageBox.Show("File video tidak ditemukan di bin/Debug.");
			}
		}

		private void axWindowsMediaPlayer1_PlayStateChange_1(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
		{
			if (e.newState == 8)
			{
				Application.Exit();
			}
		}
	}
}

