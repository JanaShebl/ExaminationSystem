using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem.Model.Questions
{
    internal abstract class Question
    {
        public string Header { get; set; } =null!;
        public string Body { get; set; } = null!;
        public  double Marks { get; set; }
        public  Answer[] AnswerList { get; set; } = null!;
        public  Answer RightAnswer { get; set; } = null!;
        public  Answer UserAnswer { get; set; } = null!;

        public abstract void AddQuestion();
        public virtual bool CheckAnswer(Answer userAnswer)
        {
            UserAnswer = userAnswer;
            return userAnswer.AnswerID == RightAnswer.AnswerID;
        }
        //public override string ToString()
        //{
        //    return Que
        //}
    }
}