using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    class Book
    {
        public Book(string name) 
        {
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public void ShowStatistics()
        {
            var result = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;

            foreach (var number in grades)
            {
                lowGrade = Math.Min(number, lowGrade);
                highGrade = Math.Max(number, highGrade);
                result += number;
            }
            result /= grades.Count;

            Console.WriteLine($"The low grade is {lowGrade:N1}");
            Console.WriteLine($"The high grade is {highGrade:N1}");
            Console.WriteLine($"The average grade is {result:N1}");
        }

        private List<double> grades;
        private string name;
    }
}
