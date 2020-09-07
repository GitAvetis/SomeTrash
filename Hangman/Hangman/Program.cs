using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            HangmanLogic hangmanLogic = new HangmanLogic();

            string word = hangmanLogic.Words();
            char[] str = hangmanLogic.WordAsMassOfChars(word);
            string[] fieldMass = new string[word.Length];
            int counter = word.Length - 2;
            int trys = word.Length - 2;

            fieldMass = hangmanLogic.emptyFieldMass(ref fieldMass);

            foreach (var item in fieldMass)
            {
                Console.Write(item);
            }

            Console.WriteLine();

            while (counter != 0 && trys != 0)
            {  
                hangmanLogic.Field(ref str,ref trys,ref counter,ref fieldMass);

                Console.WriteLine($"Букв отгадано: {word.Length - 2 - counter}   Осталось попыток: {trys}");
                Console.WriteLine();

                foreach (var item in fieldMass)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
            }
            bool winOrLose= hangmanLogic.WinOrLose(ref fieldMass);

            if(winOrLose)
            {
                Console.WriteLine();
                Console.WriteLine("Примите наши поздравления! Ваш вокабуляр - впечатляет!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Увы, но вы проиграли"); 
                Console.WriteLine();
                Console.WriteLine($"Слово, которое мы загадывали: {word}");
            }
            
        }
    }
}
