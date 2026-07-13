using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace _160425132_Felicia_FinderQuest
{
	public class TalkAreas : Areas
	{
		#region data member
		private Persons person; //aggre
		#endregion

		#region constructor
		public TalkAreas(string name, Image background, Persons person) : base(name, background)
		{
			this.Person = person;
		}
		#endregion

		#region properti
		public Persons Person { get => person; set => person = value; }
		#endregion

		#region method
		public override string DisplayData()
		{
			return this.Person.Name + "'s Talk Area - " + base.DisplayData();
		}
		#endregion

	}
}