using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject 
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name{
            get;
            set;
        }
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name {get;}
        event GradeAddedDelegate GradeAdded;
        
    }

    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
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

        public override void AddGrade(double grade)
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
        public override event GradeAddedDelegate GradeAdded;

        public bool IsGradeInBook(double grade)
        {
            return grades.Contains(grade);
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics(grades);
            return result;
        }

        private List<double> grades;
        
        
    }
}