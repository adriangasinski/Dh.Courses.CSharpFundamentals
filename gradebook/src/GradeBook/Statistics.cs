using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Statistics
    {
        public readonly double Average;
        public readonly double High;
        public readonly double Low;
        public readonly char LetterGrade;

        public Statistics(List<double> grades)
        {
            Low = double.MaxValue;
            High = double.MinValue;
            Average = 0.0;

            var index = 0;
            do 
            {
                Low = Math.Min(grades[index], Low);
                High = Math.Max(grades[index], High);
                Average += grades[index];
                index += 1;
            } while (index < grades.Count);
            Average /= grades.Count;

            switch(Average)
            {
                case var d when d >= 90.0:
                    LetterGrade = 'A';
                    break;
                
                case var d when d >= 80.0:
                    LetterGrade = 'B';
                    break;
                
                case var d when d >= 70.0:
                    LetterGrade = 'C';
                    break;
                
                case var d when d >= 60.0:
                    LetterGrade = 'D';
                    break;

                default:
                    LetterGrade = 'F';
                    break;
            } 
        }


    }
}