using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem.Model
{
    internal class Answer
    {

        public int AnswerID { get; set; }
        public string AnswerText { get; set; }
        public Answer(int answerID, string answerText)
        {
            AnswerID = answerID;
            AnswerText = answerText;
        }
        public Answer() : this(0, string.Empty)
        {
        }
        public override string ToString()
        {
            return AnswerID + ". " + AnswerText;
        }
    }
}
