using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _160425132_Felicia_FinderQuest
{
	public class Players
	{
		#region data member
		private string name;
		private PictureBox picture; // composition
		private int score;
		private Time playTime; //aggregation
		#endregion

		#region constructor
		public Players(string name, Image image, Size size, Point location, Time time)
		{
			this.Name = name;
			this.Score = 0;
			this.PlayTime = time;
			this.Picture = new PictureBox();
			this.Picture.Image = image;
			this.Picture.Size = size;
			this.Picture.Location = location;
		}
		#endregion

		#region properti
		public string Name
		{
			get => name; set
			{
				if (value != "")
				{
					name = value;
				}
				else
				{
					throw new Exception("Name can not be empty");
				}
			}
		}
		public PictureBox Picture { get => picture; set => picture = value; }
		public int Score
		{
			get => score;
			private set
			{
				if (value >= 0)
				{
					score = value;
				}
				else
				{
					score = 0;
				}
			}
		}
		public Time PlayTime { get => playTime; set => playTime = value; }
		#endregion

		#region method
		public string DisplayData()
		{
			string data = "Name : " + this.Name +
						  "\nScore : " + this.Score +
						  "\nPlaytime : " + this.PlayTime.DisplayData();
			return data;
		}
		public void DisplayPicture(Control container) // semua new stufff!! TT
		{
			this.Picture.Parent = container;
			this.Picture.SizeMode = PictureBoxSizeMode.StretchImage;
			this.Picture.BackColor = Color.Transparent;
			this.Picture.BringToFront();
		}

		public void MoveRight(int distance)
		{
			this.Picture.Location = new Point(this.Picture.Location.X + distance, this.Picture.Location.Y);
			this.Picture.Image = Properties.Resources.player_right;
		}
		public void MoveLeft(int distance)
		{
			this.Picture.Location = new Point(this.Picture.Location.X - distance, this.Picture.Location.Y);
			this.Picture.Image = Properties.Resources.player_left;
		}
		public void AddScore(int score)
		{
			this.Score += score;
		}
		public void Reset()
		{
			this.Score = 0;
			this.PlayTime = null;
			this.Picture.Location = new Point (10, 400);
			this.Picture.SendToBack();
		}

		#endregion
	}
}