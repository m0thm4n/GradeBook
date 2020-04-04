using System;
using System.IO;

namespace GradeBook
{
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
}