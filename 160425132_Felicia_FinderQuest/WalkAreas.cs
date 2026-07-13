using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _160425132_Felicia_FinderQuest
{
	public class WalkAreas : Areas
	{
		#region data member
		private int noArea;
		private List<Persons> lstPersons; // compo
		#endregion

		#region constructor
		public WalkAreas(string name, Image background, int noArea) : base(name, background)
		{
			this.NoArea = noArea;
			this.LstPersons = new List<Persons>();
		}
		#endregion

		#region properti
		public int NoArea { get => noArea; set => noArea = value; }
		public List<Persons> LstPersons { get => lstPersons; set => lstPersons = value; }
		#endregion

		#region method
		public override string DisplayData()
		{
			return "No. Area : " + this.NoArea + " - " + base.DisplayData();
		}
		public void AddPerson(int no, string name, Image image, Size size, Point location, string dialog)
		{
			Persons person = new Persons(no, name, image, size, location, dialog);
			this.LstPersons.Add(person);
		}
		public void DisplayPersons(Control container)
		{
			foreach (Persons person in this.LstPersons)
			{
				person.DisplayPicture(container);
			}
		}
		public void RemoveAllPersons()
		{
			foreach (Persons person in this.LstPersons)
			{
				person.Picture.Dispose(); // <--- klo ga di dispose, gambar tetap ada di memori?
			}
			this.LstPersons.Clear();
		}
		public bool CheckTouchPerson(Players player, out Persons touchPerson)
		{
			foreach (Persons person in this.LstPersons)
			{
				if (player.Picture.Bounds.IntersectsWith(person.Picture.Bounds))
				{
					touchPerson = person;
					return true;
				}
			}
			touchPerson = null;
			return false;
		}
		public bool CheckFinishAllQuestions()
		{
			int numSolved = 0;
			foreach (Persons person in this.LstPersons)
			{
				if (person.SolvedStatus == true)
				{
					numSolved++;
				}
			}
			if (numSolved == this.LstPersons.Count)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion

	}
}