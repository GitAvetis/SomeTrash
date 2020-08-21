using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Udemy.Homeworks
{
    public class GuessNumberGame
    {
        private readonly int max;
        private readonly int max_tries;
        private readonly GuessingMode mode;

        public enum GuessingMode
        {
            User,
            Machine
        }
        public GuessNumberGame(int max = 100,int max_tries=5,GuessingMode mode = GuessingMode.User)
        {
            this.max = max;
            this.max_tries = max_tries;
            this.mode = mode;

        }
        public void Start()
        {
            if (mode == GuessingMode.User)
            {
                UserGueses();
            }
            else
            {
                MachineGueses();
            }
        }
        private void MachineGueses()
        {
            Console.WriteLine("Enter a number that's going to be guessed by a computer");

            int guessedNumber = -1;
            while (guessedNumber == -1)
            {
                int parsedNumber = int.Parse(Console.ReadLine());
                if (parsedNumber >= 0 && parsedNumber <= this.max)
                {
                    guessedNumber = parsedNumber;
                }
            }

            int lastGuess = -1;
            int min = 0;
            int max = this.max;
            int tries = 0;
            while (lastGuess != guessedNumber && tries < max_tries)
            {
                lastGuess = (max + min) / 2;
                Console.WriteLine($"Did u guess this number - {lastGuess}?");
                Console.WriteLine($"If yes, enter 'y', if your number greater - enter 'g', if less - 'l'");

                string answer = Console.ReadLine();
                if (answer == "y")
                {
                    Console.WriteLine("Super! I guessed your number,man!");
                }
                else if (answer == "g")
                {
                    min = lastGuess;
                }
                else
                {
                    max = lastGuess;
                }
                if (lastGuess == guessedNumber)
                {
                    Console.WriteLine("Don't cheat, man!");
                }
                tries++;
                if (tries == max_tries)
                {
                    Console.WriteLine("No tries anymore:(I lost!)");
                }
            }
        }    

        private void UserGueses()
        {
            Console.WriteLine("U choosed user mode");
            Console.WriteLine("U have 5 tries, i wish u luck!");
            Random random = new Random();
            int guessedNumber = random.Next(max);

            int lastGuess = -1;
            int tries = 0;
            if (guessedNumber > max / 2)
            {
                guessedNumber = random.Next(max / 2, 100);
            }
            while (lastGuess != guessedNumber && tries < max_tries)
            {
                lastGuess = int.Parse(Console.ReadLine());
                if (lastGuess == guessedNumber)
                {
                    Console.WriteLine("Congrats! You win!");
                }
                else if (lastGuess < guessedNumber)
                {
                    Console.WriteLine("my number is greater");
                }
                else
                {
                    Console.WriteLine("my number is less");
                }
                if (tries == max_tries)
                {
                    Console.WriteLine("U lost");
                }
                tries++;
            }
        }

       
    }
}
