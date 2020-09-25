using System;


namespace ConverterOfNumsSystems
{
    class Program
    {
        private static void Main()
        {
            Console.WriteLine("Programm started");
            while (true)
            {
                Console.WriteLine("Chose type of convertation system for entering num.");

                    int _from = int.Parse(Console.ReadLine());

                Console.WriteLine($"Enter your number for converting from {_from}-th number system");
                string _num = Console.ReadLine().ToUpper();
                bool v = new FilterForInput().OkString(_from, _num);
                if (v == true)
                {
                    Console.WriteLine("Chose output convertation system for your num.");
                    int _to = int.Parse(Console.ReadLine());
                    double dec = new ReversNotation().NumInDecimal(_from, _num);
                    GC.Collect();

                    Console.WriteLine("Chose rank of number system");
                    new StraightNotation(_to,dec);

                    GC.Collect();
                }
                else if (_num == "STOP")
                {
                    Console.WriteLine("Comeback to main menu...");
                    Console.WriteLine();
                    Console.Clear();
                    break;
                }
                else
                {

                    Console.WriteLine("Wrong input. Try again");
                    Console.WriteLine();
                }

            } 

        }
    }
}
