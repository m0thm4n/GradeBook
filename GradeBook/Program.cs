﻿using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Scott's Grade Book");
            book.AddGrade(89.3);
            book.AddGrade(90.5);
            book.ShowStatistics();

            //var grades = new List<double>() { 12.7, 10.3, 6.11, 4.1 };

            //var result = 0.0;
            //var highGrade = double.MinValue;
            //var lowGrade = double.MaxValue;

            //foreach(var number in grades)
            //{
            //    lowGrade = Math.Min(number, lowGrade);
            //    highGrade = Math.Max(number, highGrade);
            //    result += number;
            //}
            //result /= grades.Count;

            //Console.WriteLine($"The low grade is {lowGrade:N1}");
            //Console.WriteLine($"The high grade is {highGrade:N1}");
            //Console.WriteLine($"The average grade is {result:N1}");
        }
    }
}