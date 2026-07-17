using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _160425132_Felicia_FinderQuest;

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


//FormA200 formA200;
//FormGame formGame = new FormGame();
//public void KirimForm(FormA200 frm)
//{
//	this.formA200 = frm;
//}

//public bool changeForm = false;
//private void labelBackToRoom_Click(object sender, EventArgs e)
//{
//	changeForm = true;
//	this.Close();
//}

//private void FormQuestion_FormClosing(object sender, FormClosingEventArgs e)
//{
//	if (e.CloseReason == CloseReason.UserClosing)
//	{
//		if (changeForm)
//		{
//			e.Cancel = true;
//			this.Hide();
//			formA200.Show();
//			formA200.bgm.controls.play();
//			formGame.backSoundPlayer.controls.pause();
//			formA200.currentForm = "question";
//		}
//	}
//}
