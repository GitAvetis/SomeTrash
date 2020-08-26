using System;
using System.Text;

namespace ForPavelShkitkin
{
    class Program
    {
        private static TicTacToeGame g = new TicTacToeGame();
        static void Main(string[] args)
        {
            Console.WriteLine(GetPrintableState());

            while (g.GetWinner() == Winner.GameIsUnfinised)
            {
                int index = int.Parse(Console.ReadLine());
                g.MakeMove(index);

                Console.WriteLine();
                Console.WriteLine(GetPrintableState());
            }

            Console.WriteLine($"Result: {g.GetWinner()}");
            Console.ReadLine();
        }
        static string GetPrintableState()
        {
            var sb = new StringBuilder();
            for (int i = 0; i <= 7; i++)
            {
                sb.AppendLine("     |      |     ")
                    .AppendLine(
                    $" {GetPrintableChar(i)}  |  {GetPrintableChar(i + 1)}  |  {GetPrintableChar(i + 2)}  |")
                    .AppendLine("_____|_____|_____");

            }
            return sb.ToString();
        }
        static string GetPrintableChar(int index)
        {
            State state = g.GetState(index);
            if (state == State.Unset)
            {
                return index.ToString();
            }
            return state == State.Cross ? "X" : "Y";
        }
    }
}
