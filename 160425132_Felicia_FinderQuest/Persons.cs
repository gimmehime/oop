using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace _160425132_Felicia_FinderQuest
{
	public class Persons
	{
		#region data member
		private int noPerson;
		private string name;
		private PictureBox picture; // compo
		private string dialog; // compo
		private Questions personQuestion; // compo
		private bool solvedStatus;
		#endregion

		#region constructor
		public Persons(int noPerson, string name, Image image, Size size, Point location, string dialog)
		{
			this.NoPerson = noPerson;
			this.Name = name;
			this.Picture = new PictureBox();
			this.Picture.Image = image;   // mustie picture nya ga item
			this.Picture.Size = size;
			this.Picture.Location = location;
			this.Dialog = dialog;
			this.SolvedStatus = false;
		}
		#endregion

		#region properti
		public int NoPerson { get => noPerson; 
			set
			{
				if (value >= 0)
				{
					noPerson = value;
				}
				else
				{
					throw new Exception("No person cannot be negative");
				}
			}
		}
		public string Name { get => name;
			set
			{
				if (value != "")
				{
					name = value;
				}
				else
				{
					throw new Exception("Name cannot be empty");
				}
			}
		}
		public PictureBox Picture { get => picture; set => picture = value; }
		public string Dialog { get => dialog; set => dialog = value; }
		public Questions PersonQuestion { get => personQuestion; set => personQuestion = value; }
		public bool SolvedStatus { get => solvedStatus; private set => solvedStatus = value; }
		#endregion

		#region method
		public void AddQuestion(string question, string answer, int score)
		{
			this.PersonQuestion = new Questions(question, answer, score);
		}
		public bool CheckAnswer(string playerAnswer, out int score)
		{
			if(playerAnswer.ToLower() == this.PersonQuestion.Answer.ToLower())
			{
				this.SolvedStatus = true;
				score = this.PersonQuestion.Score;
				return true;
			}
			score = 0;
			return false;
		}
		public string DisplayData()
		{
			string data = "Hi... I'm " + this.Name + ".\n" + this.Dialog;
			return data;
		}
		public void DisplayDialog(Control container)
		{
			Label labelDialog = new Label();
			labelDialog.Parent = container;
			labelDialog.Text = this.DisplayData();
			labelDialog.Font = new Font("Arial", 18);
			labelDialog.TextAlign = ContentAlignment.TopCenter;
			labelDialog.Size = new Size(500, 90);
			
			labelDialog.Location = new Point(this.Picture.Location.X - 150, 10); // set lokasi agar label dialog di atas person
			labelDialog.BackColor = Color.LightYellow;
			labelDialog.BorderStyle = BorderStyle.FixedSingle;
			labelDialog.Visible = true;
			labelDialog.BringToFront();
		}
		public void DisplayPicture(Control container)
		{
			this.Picture.Parent = container;
			this.Picture.SizeMode = PictureBoxSizeMode.StretchImage;
			this.Picture.BackColor = Color.Transparent;
			this.Picture.BringToFront();
		}
		#endregion

	}
}