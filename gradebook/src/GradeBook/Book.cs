using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book(string name) 
        {
            this.name = name;
            grades = new List<double>();
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public void ShowStatistics()
        {
            var lowVal  = double.MaxValue;
            var highVal = double.MinValue;
            double gradesSum = 0.0;

            foreach(var grade in grades)
            {
                lowVal = Math.Min(grade, lowVal);
                highVal = Math.Max(grade, highVal);
                gradesSum += grade;
            }
            var avgGrade = gradesSum / grades.Count;

            System.Console.WriteLine($"The lowest grade is {lowVal}.");
            System.Console.WriteLine($"The highest grade is {highVal}.");
            System.Console.WriteLine($"The average grade is {avgGrade:N1}.");
        }

        private List<double> grades;
        private string name;
        
    }
}