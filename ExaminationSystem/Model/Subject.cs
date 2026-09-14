using ExaminationSystem.Model.ExamFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem.Model
{
    internal class Subject
    {
        public Exam SubjectExam { get; set; } = null!;


        public void CreateExam()
        {
            int examType;
            bool isValidType;

            do
            {
                Console.WriteLine("Please Choose Exam Type (1 for Final Exam, 2 for Practical Exam): ");
                isValidType = int.TryParse(Console.ReadLine(), out examType) && (examType == 1 || examType == 2);

                if (!isValidType)
                {
                    Console.WriteLine("Invalid choice. Please enter 1 for Final or 2 for Practical.");
                }
            } while (!isValidType);

            if (examType == 1)
            {
                SubjectExam = new FinalExam();
            }
            else
            {
                SubjectExam = new PracticalExam();
            }
        }
    }
}
