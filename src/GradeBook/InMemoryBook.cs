using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(char letter)
        {
            switch (letter) 
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
                case 'F':
                    AddGrade(50);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null) 
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else 
            {
                System.Console.WriteLine("Invalid Grade");
            }
        }

        // public void GetStatistics() 
        // {
        // }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {
            Statistics result = new Statistics();

            for (int index = 0; index < grades.Count; index++)
            {
                result.Add(grades[index]);
            }

            return result;
        }

        private List<double> grades;

        //private string name;
    }
}