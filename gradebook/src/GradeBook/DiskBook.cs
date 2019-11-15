using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book, IBook
    {

        public DiskBook(string name) : base(name)
        {
            Name = name;
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {

            using(var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            
        }

        public override Statistics GetStatistics()
        {
             var allLines = File.ReadAllLines($"{Name}.txt");

             grades = new List<double>();

             foreach(var line in allLines)
            {
                grades.Add(Convert.ToDouble(line.Trim()));
                 
            }
                
            Statistics stats = new Statistics(grades);
            return stats;
        }

        private List<double> grades;
    }
}