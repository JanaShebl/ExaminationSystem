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
            Console.Write("Do You Want To Start The Exam? (Y | N): ");
            char choice = char.Parse(Console.ReadLine() ?? "N");

            if (char.ToUpper(choice) == 'Y')
            {
                Console.Clear();

                Stopwatch timer = Stopwatch.StartNew();

                subject.SubjectExam.ShowExam();

                timer.Stop();
                Console.WriteLine($"\nTime Taken: {timer.Elapsed.Minutes:D2} Minutes and {timer.Elapsed.Seconds:D2} Seconds");
            }
            else if(char.ToUpper(choice) == 'N')
            {
                Console.WriteLine("Exam Cancelled.");
            }
            //else {
            //    bool flag = false;
            //    do
            //    {
            //        if(char.ToLower(choice) != 'y' && char.ToLower(choice) != 'n')
            //        {
            //            Console.Write("Do You Want To Start The Exam? (Y | N): ");
            //            choice = char.Parse(Console.ReadLine() ?? "N");
            //        }
            //        else if(char.ToLower(choice) == 'y')
            //        {
            //            Console.Clear();
            //            Stopwatch timer = Stopwatch.StartNew();
            //            subject.SubjectExam.ShowExam();
            //            timer.Stop();
            //            Console.WriteLine($"\nTime Taken: {timer.Elapsed.Minutes:D2} Minutes and {timer.Elapsed.Seconds:D2} Seconds");
            //        }
            //        else if (char.ToLower(choice) == 'n')
            //        {
            //            Console.WriteLine("Exam Cancelled.");
            //            flag = true;
            //        }
            //        else
            //        {
            //            Console.WriteLine("Invalid choice. Please enter Y or N.");
            //        }
            //    }
            //    while (!flag);
            //}
        
    }
    }
}
// ليميت للدقايق , الهيدر ملوش لازمة , هندلة الستارت اكزام , كلين عشان بعد ما يخلص امتحان و مفيش حاجة بتحصل لو الوقت خلص