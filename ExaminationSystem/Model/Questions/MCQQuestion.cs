using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem.Model.Questions
{
    internal class MCQQuestion : Question
    {
        public MCQQuestion()
        {
            AnswerList = new Answer[4];
        }

        public override void AddQuestion()
        {
            Header = "MCQ)";

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
                if (!marksValid || marks <= 0)
                {
                    Console.WriteLine("Invalid Marks. Please enter a positive number.");
                }
            } while (!marksValid || marks <= 0);
            Marks = marks;

            for (int i = 0; i < 4; i++)
            {
                
                do
                {
                    Console.WriteLine("Enter the answer for choice " + (i + 1) + ": ");
                    AnswerList[i] = new Answer(i + 1, Console.ReadLine());
                }
                while (string.IsNullOrEmpty(AnswerList[i].AnswerText));
            }

            int rightAnswerID;
            bool answerIDValid;
            do
            {
                Console.WriteLine("Enter the ID of the correct answer (1-4): ");
                answerIDValid = int.TryParse(Console.ReadLine(), out rightAnswerID);
                if (!answerIDValid || rightAnswerID < 1 || rightAnswerID > 4)
                {
                    Console.WriteLine("Invalid answer ID. Please enter a number between 1 and 4.");
                }
            }
            while (!answerIDValid || rightAnswerID < 1 || rightAnswerID > 4);
            RightAnswer = AnswerList[rightAnswerID - 1];
        }
    }
}
