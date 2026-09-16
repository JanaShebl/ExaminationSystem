using ExaminationSystem.Model.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem.Model.ExamFolder
{
    internal class PracticalExam : Exam
    {
        public PracticalExam() : base()
        {
        }
        public override void CreateQuestions()
        {
            for (int i = 0; i < NumberOfQuestions; i++)
            { 
                MCQQuestion mcqQuestion = new MCQQuestion();
                mcqQuestion.AddQuestion();
                QuestionsList.Add(mcqQuestion);
            }

        }
        public override void ShowExam()
        {
            Console.WriteLine("___Practical Exam___");
            Console.WriteLine($"Time of Exam: {TimeOfExam}");
            Console.WriteLine($"Number of Questions: {NumberOfQuestions}");
            Console.WriteLine("");

            double totalMarks = 0;
            for (int i=0;i< QuestionsList.Count; i++){
                Console.WriteLine($"{QuestionsList[i].Header} Q {i + 1}: {QuestionsList[i].Body} marks: {QuestionsList[i].Marks}");
                foreach (Answer answer in QuestionsList[i].AnswerList)
                {
                    Console.WriteLine(answer);
                }

                bool isValidAnswer = false;
                int answerID = 0;
                    do
                    {
                        Console.Write("Enter your answer (1-4): ");
                        isValidAnswer = int.TryParse(Console.ReadLine(), out answerID) && answerID >= 1 && answerID <= 4;
                        if (!isValidAnswer)
                        {
                            Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                        }
                    } while (!isValidAnswer);

                    //answerID = answerID - 1;
                
               
                if (QuestionsList[i].CheckAnswer(QuestionsList[i].AnswerList[answerID - 1]))
                {
                    totalMarks += QuestionsList[i].Marks;
                }
            }
            Console.Clear(); // change
            Console.WriteLine($"Total Marks: {totalMarks}");
            for (int i = 0; i < QuestionsList.Count; i++)
            {
                Console.WriteLine($"Q{i+1} Your Answer: {QuestionsList[i].UserAnswer.AnswerText}, Correct Answer: {QuestionsList[i].RightAnswer.AnswerText}");
            }
        }   


    }
}
