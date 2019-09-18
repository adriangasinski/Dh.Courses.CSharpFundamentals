﻿using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Adrian's Grade Book");

            while (true) 
            {
                //System.Console.Clear();
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
                    System.Console.WriteLine("Grade has been added.");
                }
                catch(ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                
            }        
                


            // book.AddGrade(89.1);
            // book.AddGrade(90.5);
            // book.AddGrade(77.5);

            var stats = book.GetStatistics();

            System.Console.WriteLine($"The lowest grade is {stats.Low}.");
            System.Console.WriteLine($"The highest grade is {stats.High}.");
            System.Console.WriteLine($"The average grade is {stats.Average:N1}.");
            System.Console.WriteLine($"The letter grade is {stats.LetterGrade}.");
            
        }
    }
}