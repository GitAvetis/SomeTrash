using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ВерюНеВерю
{
    class Program
    {
        static void Main()
        {            
            Game( "Questions.csv"); 
        }
        static void Game(string csvFile)
        {
            IEnumerable<Questions> questionsList = File.ReadAllLines(csvFile)
                                   .Skip(1)
                                   .Select(Questions.CsvLineParse)
                                   .ToList();

            Console.WriteLine("Chose number of question and try to give a correct answer");
            Console.WriteLine();
            foreach (var item in questionsList)
            {
                Console.WriteLine($"{item.Number}. {item.Question}"); 
            }
           
            int questionNumber = int.Parse(Console.ReadLine());

            Console.Clear();
            foreach (var item in questionsList.Where(questionNum => questionNum.Number == questionNumber))
            {
                Console.WriteLine(item.Question);
            }

            Console.WriteLine("What do you think, Yes or No? Writе answer under this line ");
            string playersPrediction = Console.ReadLine().Trim().ToUpper();
            Console.Clear();
            foreach (var item in questionsList.Where(questionNum => questionNum.Number == questionNumber))
            {                  
                if (item.Answer.Trim().ToUpper() == playersPrediction)
                    Console.WriteLine($"You're right!");
                else
                    Console.WriteLine($"Nope. Actualy answer was {item.Answer}.\n{item.Comment}");
            }        

        }
    }
}
