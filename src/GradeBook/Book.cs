using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public interface IBook 
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
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

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {

            Name = name;
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using (StreamWriter stream = File.AppendText($"{Name}.txt"))
            {  
                stream.WriteLine(grade);
                if (GradeAdded != null) 
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }


        public override Statistics GetStatistics()
        {
            Statistics result = new Statistics();
            
            using (StreamReader reader = File.OpenText($"{Name}.txt"))
            {
                string line = reader.ReadLine();
                while (line != null) 
                {
                    double number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }

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
