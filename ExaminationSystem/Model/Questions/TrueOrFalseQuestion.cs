using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem.Model.Questions
{
    internal class TrueOrFalseQuestion : Question
    {
        public TrueOrFalseQuestion()
        {
            AnswerList = [new Answer(1,"True"), new Answer(2,"False")];
        }

        public override void AddQuestion()
        {
            Header = "True/False)";

            do
            {
                Console.WriteLine("Enter Question Body : ");   
                Body = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(Body));

            double marks;
            bool marksValid;
            do
            {
                Console.WriteLine("Enter Question Marks : ");
                marksValid = double.TryParse(Console.ReadLine(), out marks);
                if(!marksValid || marks <= 0)
                {
                    Console.WriteLine("Invalid Marks. Please enter a positive number.");
                }
            }
            while (!marksValid || marks <= 0);
            Marks= marks;

            int rightAnswerID;
            bool answerIDValid;

            do
            {
                Console.WriteLine("Enter Right Answer (1 for True) (2 for False)");
                answerIDValid = int.TryParse(Console.ReadLine(), out rightAnswerID);
                if(!answerIDValid || rightAnswerID != 1 && rightAnswerID != 2)
                {
                    Console.WriteLine("Invalid Input , Please Enter 1 for true and 2 for false");
                }
            }
            while (!answerIDValid || rightAnswerID != 1 && rightAnswerID != 2);
            RightAnswer = AnswerList[rightAnswerID - 1];


        }
    }
}
