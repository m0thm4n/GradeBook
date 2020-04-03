using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            DiskBook book = new DiskBook("Nathan's Grade Book");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            Statistics stats = book.GetStatistics();
            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The low grade is {stats.Low:N1}");
            Console.WriteLine($"The high grade is {stats.High:N1}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                System.Console.WriteLine("Please enter a grade: ");
                string input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    double inputConvertedToDouble = double.Parse(input);
                    book.AddGrade(inputConvertedToDouble);
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e);
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("A grade was added!");
        }
    }
}