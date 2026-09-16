using ExaminationSystem.Model.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem.Model.ExamFolder
{
    internal abstract class Exam
    {
        public int TimeOfExam { get; set; }
        public int NumberOfQuestions { get; set; }
        protected List<Question> QuestionsList = new List<Question>();

        protected Exam()
        {
            bool isValidTime;
            int time;
            do
            {
                Console.Write("Enter Time of Exam in Minutes between 30 and 180: ");
                isValidTime = int.TryParse(Console.ReadLine(), out time) && time >= 30 && time <= 180;
                if (!isValidTime)
                {
                    Console.WriteLine("Invalid Time. Please enter a number between 30 and 180.");
                }
            } while (!isValidTime);

            TimeOfExam = time;

            bool isValidNum;
            int num;
            do
            {
                Console.Write("Enter Number of Questions: ");
                isValidNum = int.TryParse(Console.ReadLine(), out num) && num > 0;
                if (!isValidNum)
                {
                    Console.WriteLine("Invalid Number. Please enter a positive number.");
                }
            } while (!isValidNum);

            NumberOfQuestions = num;
        }
        public abstract void ShowExam();
        public abstract void CreateQuestions();
    }
}
