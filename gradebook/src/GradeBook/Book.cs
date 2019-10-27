using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class Book
    {
        public Book(string name) 
        {
            Name = name;
            grades = new List<double>();
        }

        public void AddLetterGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                case 'D':
                    AddGrade(60);
                    break;

                default:
                    AddGrade(0);
                    break;
            }
        }

        public void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);    
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }

            }
            else 
            {
                throw new ArgumentException($"Ivalid {nameof(grade)}");
            }   
        }
        public event GradeAddedDelegate GradeAdded;

        public bool IsGradeInBook(double grade)
        {
            return grades.Contains(grade);
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            
            result.Low = double.MaxValue;
            result.High = double.MinValue;
            result.Average = 0.0;

            var index = 0;
            do 
            {
                result.Low = Math.Min(grades[index], result.Low);
                result.High = Math.Max(grades[index], result.High);
                result.Average += grades[index];
                index += 1;
            } while (index < grades.Count);
            result.Average /= grades.Count;

            switch(result.Average)
            {
                case var d when d >= 90.0:
                    result.LetterGrade = 'A';
                    break;
                
                case var d when d >= 80.0:
                    result.LetterGrade = 'B';
                    break;
                
                case var d when d >= 70.0:
                    result.LetterGrade = 'C';
                    break;
                
                case var d when d >= 60.0:
                    result.LetterGrade = 'D';
                    break;

                default:
                    result.LetterGrade = 'F';
                    break;
            }
            return result;
        }

        private List<double> grades;
        public string Name;
        
    }
}