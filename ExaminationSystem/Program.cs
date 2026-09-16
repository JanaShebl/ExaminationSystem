using ExaminationSystem.Model;
using ExaminationSystem.Model.Questions;
using System.Diagnostics;

namespace ExaminationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject();
            subject.CreateExam();
            Console.Clear();
            Console.WriteLine("Enter Question Details");
            subject.SubjectExam.CreateQuestions();

            Console.Clear();
            string startExam;

            do
            {
                Console.Write("Do You Want To Start The Exam? (Y | N): ");
                startExam = Console.ReadLine()?.Trim().ToUpper() ?? "";

                if (startExam != "Y" && startExam != "N")
                {
                    Console.WriteLine("Invalid choice. Please enter exactly 'Y' or 'N'.");
                }

            } while (startExam != "Y" && startExam != "N" || string.IsNullOrEmpty(startExam));

            if (startExam == "Y")
            {
                Console.Clear();
                Stopwatch timer = Stopwatch.StartNew();
                subject.SubjectExam.ShowExam();
                timer.Stop();

                Console.WriteLine($"Time Taken: {timer.Elapsed.Minutes:D2} Minutes and {timer.Elapsed.Seconds:D2} Seconds");
                if (timer.Elapsed.TotalMinutes > subject.SubjectExam.TimeOfExam)
                {
                    Console.WriteLine("Warning: You exceeded the allowed exam time!");
                }
            }
            else
            {
                Console.WriteLine("Exam Cancelled.");
            }


        }
    }
}