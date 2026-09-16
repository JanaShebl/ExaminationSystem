using ExaminationSystem.Model.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem.Model.ExamFolder
{
    internal class FinalExam : Exam
    {
        public FinalExam(): base() { }
        public override void CreateQuestions()
        {
            for(int i = 0; i < NumberOfQuestions; i++)
            {
                int typeOfQueston;
                bool isValidType;
                do
                {
                    Console.WriteLine("Choose the type of question: 1 for MCQ, 2 for True/False");
                    isValidType = int.TryParse(Console.ReadLine(), out typeOfQueston);
                    if (!isValidType || (typeOfQueston != 1 && typeOfQueston != 2))
                    {
                        Console.WriteLine("Invalid input. Please enter 1 for MCQ or 2 for True/False.");
                    }

                } while (!isValidType || (typeOfQueston != 1 && typeOfQueston != 2));

                if(typeOfQueston == 1)
                {
                    MCQQuestion mcqQuestion = new MCQQuestion();
                    mcqQuestion.AddQuestion();
                    QuestionsList.Add(mcqQuestion);
                }
                else if (typeOfQueston == 2)
                {
                    TrueOrFalseQuestion trueOrFalseQuestion = new TrueOrFalseQuestion();
                    trueOrFalseQuestion.AddQuestion();
                    QuestionsList.Add(trueOrFalseQuestion);
                }

            }
            
        }
        public override void ShowExam()
        {
            Console.WriteLine("___Final Exam___");
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
                if (QuestionsList[i] is MCQQuestion)
                {
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
                }

                else if (QuestionsList[i] is TrueOrFalseQuestion)
                {
                    do
                    {
                        Console.Write("Enter your answer (1 for True, 2 for False): ");
                        isValidAnswer = int.TryParse(Console.ReadLine(), out answerID) && (answerID == 1 || answerID == 2);
                        if (!isValidAnswer)
                        {
                            Console.WriteLine("Invalid input. Please enter 1 for True or 2 for False.");
                        }
                    } while (!isValidAnswer);
                    //answerID = answerID - 1;
                }
                if (QuestionsList[i].CheckAnswer(QuestionsList[i].AnswerList[answerID - 1]))
                {
                    totalMarks += QuestionsList[i].Marks;
                }
            }

            Console.Clear();
            Console.WriteLine($"Total Marks: {totalMarks}");
            for (int i = 0; i < QuestionsList.Count; i++)
            {
                Console.WriteLine($"Question {i + 1}: {QuestionsList[i].Header} - Your Answer: {QuestionsList[i].UserAnswer.AnswerText}, Correct Answer: {QuestionsList[i].RightAnswer.AnswerText}");
            }
        }   

    }
}
