using System;

namespace ConsoleApp1
{
    class Program
    {
        public static int scriptNum;
        public static int questionNum;
        public static int lecturerNum;
        public static int subtotal;
        
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the number of scripts to be marked");
            scriptNum = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter the number of questions constituting the test");
            questionNum = Convert.ToInt32(Console.ReadLine());

            while ((questionNum > 10) && (questionNum <= 0))
            {
                Console.WriteLine("The number of questions constituting the test must be less than 10");
                questionNum = Convert.ToInt32(Console.ReadLine());
            }
            
            Console.WriteLine("Please enter the number of lecturers that will mark tests");
            lecturerNum = Convert.ToInt32(Console.ReadLine());
            
            int[] questionSubtotals = new int[questionNum];
            
            for (int i = 0; i < questionNum; i++)
            {
                Console.WriteLine("Please enter the subtotal marks of question" + (i +1));
                subtotal = Convert.ToInt32(Console.ReadLine());
                
                while (subtotal <= 0)
                {
                    Console.WriteLine("Please enter a subtotal that is greater than 0");
                    subtotal = Convert.ToInt32(Console.ReadLine());
                }
                
                questionSubtotals[i] = subtotal;
            }

            double scriptsToMarkA = scriptNum / lecturerNum;
            scriptsToMarkA = Math.Floor(scriptsToMarkA);
            double leftoverScripts = scriptNum - (scriptsToMarkA * lecturerNum);
            double lastLecturersTests = scriptsToMarkA + leftoverScripts;

            Console.WriteLine("Each lecturer will need to mark " + scriptsToMarkA + " tests, the last lecturer will " +
                              "need to mark " + lastLecturersTests + " tests");

            int questionSubtotalSum = 0;
            
            for (int i = 0; i < questionSubtotals.Length; i++)
            {
                questionSubtotalSum = questionSubtotalSum + questionSubtotals[i];
            }

            int arrayLength = questionSubtotals.Length;
            double markingTimeSecs = (questionSubtotalSum * 2);
            double markingTimeMins = markingTimeSecs / 60;
            double markingTime = Math.Round(markingTimeMins * scriptsToMarkA);
            double lastMarkingTime = Math.Round(markingTimeMins * lastLecturersTests);

            TimeSpan timespan = TimeSpan.FromMinutes(markingTime);
            TimeSpan timespan2 = TimeSpan.FromMinutes(lastMarkingTime);
            
            Console.WriteLine("The time it will take for each lecturer to mark all their tests is " 
                              + timespan.Hours + " hours and " + timespan.Minutes + " minutes");
            
            Console.WriteLine("The time it will take for the last lecturer to complete all of their tests is " 
                              + timespan2.Hours + " hours and " + timespan2.Minutes + " minutes");
        }
    }
}