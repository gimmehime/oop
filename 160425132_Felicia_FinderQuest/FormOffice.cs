using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _160425132_Felicia_FinderQuest
{
	public partial class FormOffice : Form
	{
		public FormOffice()
		{
			InitializeComponent();
		}

		Entity entity = new Entity("\\sound\\1.wav", "\\sound\\2.wav", "\\sound\\Die.wav", Properties.Resources.EntityPlaceHolder, new Size(650, 500), new Point (234,0), Properties.Resources.JumpscarePlaceHolder, new Size(650, 500), new Point(234, 0));

		private void FormOffice_Load(object sender, EventArgs e)
		{
			buttonMechanism.Image = Properties.Resources.JumpscarePlaceHolder;
		}

		private void buttonMechanism_Click(object sender, EventArgs e)
		{

		}



		//Properties.Resources.person1, new Size(60, 90), new Point(150, 350)
		// 1118, 610
	}
}
