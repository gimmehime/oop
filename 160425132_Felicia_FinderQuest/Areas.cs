using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _160425132_Felicia_FinderQuest
{
	public abstract class Areas
	{
		#region data member
		private string name;
		private Image background;
		#endregion

		#region constructor
		public Areas(string name, Image background)
		{
			this.Name = name;
			this.Background = background;
		}
		#endregion

		#region properti
		public string Name
		{
			get => name;
			set
			{
				if (value != "")
				{
					name = value;
				}
				else
				{
					throw new Exception("Level name cannot be empty");
				}
			}
		}
		public Image Background { get => background; set => background = value; }
		#endregion

		#region method
		public virtual string DisplayData()
		{
			return this.Name;
		}
		public void DisplayPicture(Control container)
		{
			container.BackgroundImage = this.Background;
		}
		#endregion

	}
}