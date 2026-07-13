using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _160425132_Felicia_FinderQuest
{
	public class Questions
	{
		#region data member
		private string question;
		private string answer;
		private int score;
		#endregion

		#region constructor
		public Questions(string question, string answer, int score)
		{
			this.Question = question;
			this.Answer = answer;
			this.Score = score;
		}
		#endregion

		#region properti
		public string Question
		{
			get => question;
			set
			{
				if (value != "")
				{
					question = value;
				}
				else
				{
					throw new Exception("Question cannot be empty");
				}
			}
		}
		public string Answer
		{
			get => answer;
			set
			{
				if (value != "")
				{
					answer = value;
				}
				else
				{
					throw new Exception("Answer cannot be empty");
				}
			}
		}
		public int Score { 
			get => score; 
			set
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
		#endregion

		#region method
		#endregion

	}
}