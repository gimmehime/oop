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
    public partial class FormQuestion : Form
    {
        public FormQuestion()
        {
            InitializeComponent();
        }
        FormGame frmGame;
		private void FormQuestion_Load(object sender, EventArgs e)
		{
            frmGame = (FormGame)this.Owner;
            labelQuestion.Text = frmGame.activePerson.PersonQuestion.Question;
		}

		private void buttonSubmit_Click(object sender, EventArgs e)
		{
            if (frmGame.activePerson.CheckAnswer(textBoxAnswer.Text, out int score) == true)
            {
                MessageBox.Show("Your answer is correct! You get " + score + " points.");
                frmGame.player.AddScore(score);
                frmGame.labelPlayer.Text = frmGame.player.DisplayData();
            }
            else
            {
                MessageBox.Show("Sorry... your answer is incorrect!");
            }
            this.Close();
            frmGame.ExitTalkArea();
		}
	}
}
