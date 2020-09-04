using System;
using System.IO;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            HangmanLogic hangmanLogic = new HangmanLogic();

            string word = hangmanLogic.Words();            


            Console.WriteLine(word.Length);
            Console.WriteLine(word);

                hangmanLogic.Field(word);
            
      
        }
    }
}
