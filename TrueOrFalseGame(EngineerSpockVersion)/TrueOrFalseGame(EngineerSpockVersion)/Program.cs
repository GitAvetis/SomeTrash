using System;

namespace TrueOrFalseGame_EngineerSpockVersion_
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game("Questions.csv");
            game.EndOfGame += (sender, eventArgs) =>
            {
                Console.WriteLine($"Questions asked:{eventArgs.QuestionsPassed}. Mistakes made:{eventArgs.MistakesMade}.");
                Console.WriteLine(eventArgs.IsWin ? "You won!" : "You lost!");
            };
            while (game.GameStatus == GameStatus.GameInProgress)
            {
                Question q = game.GetNextQuestion();
                Console.WriteLine("Do u belive in the nezt statement or question? Enter 'y' or 'n'" );
                Console.WriteLine(q.Text);

                string answer = Console.ReadLine();
                bool boolAnswer = answer == "y";
                if(q.CorrectAnswer==boolAnswer)
                    Console.WriteLine("Good job. You're right!");
                else
                {
                    Console.WriteLine("Oops, actually you're mistaken. Here is the explanation");
                }

                game.GiveAnswer(boolAnswer);
            }

            Console.ReadLine();
        }
    }
}
