using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new DiskBook("Adrian's Grade Book");

            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();

            System.Console.WriteLine("--------------------------------------");
            System.Console.WriteLine($"The lowest grade is {stats.Low}.");
            System.Console.WriteLine($"The highest grade is {stats.High}.");
            System.Console.WriteLine($"The average grade is {stats.Average:N1}.");
            System.Console.WriteLine($"The letter grade is {stats.LetterGrade}.");

        }

        private static void EnterGrades(Book book)
        {
            while (true)
            {
                //System.Console.Clear();
                System.Console.WriteLine("--------------------------------------");
                System.Console.WriteLine("Provide the grade and press enter.");
                System.Console.WriteLine("To quit press 'q'.");
                var input = Console.ReadLine();

                if (input.ToLower() == "q")
                {
                    break;
                }
                try
                {
                    book.AddGrade(double.Parse(input));
                }
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }

            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            System.Console.WriteLine("Grade has beeen added. This is a message from a method assigned to an event");
        }
    }
}