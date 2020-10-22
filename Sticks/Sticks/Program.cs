using System;

namespace Sticks
{
    class Game 
    {
        public delegate void LowSticks();
        private LowSticks lowSticks;
        public void RegisterOnLowSticks(LowSticks lowSticks)
        {
            this.lowSticks = lowSticks;
        }
        public int i { get; set; } = 1;
        public int _totalSticks { get; set; }
        public string numberOfSticks { get; set; }
        public bool notEnuff { get; set; } = false;
        public void Start(int _totalSticks)
        {
            this._totalSticks = _totalSticks;
        }
        public bool TryMinus(string numberOfSticks, out int result)
        {
            this.numberOfSticks = numberOfSticks;
            result = 0;

            if (int.TryParse(numberOfSticks, out int number))
            {

                if (number > 0 && number <= 3)
                {
                    result = number;
                    return true;
                }

                else return false;

            }
            else
                return false;

        }
        public void Minus(int numberOfSticks)
        {
            int n = 0;
            while (n!= numberOfSticks)
            {
                _totalSticks -= 1;
                n++;
                if (_totalSticks == 0)
                {
                    lowSticks();
                    notEnuff = true;
                    break;
                }
            }
            
        }

        public bool WhoWasLast()
        {

            bool ItWasPlayer;
            if (i % 2 == 0)
            {
                ItWasPlayer = true;
            }
            else
                ItWasPlayer = false;
            return ItWasPlayer;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Console.WriteLine("Choose total sticks number");
            game.Start(int.Parse(Console.ReadLine()));
            game.RegisterOnLowSticks(HandleOnLowSticks);
            Console.WriteLine("Now enter number of sticks, that u want to take");
            
            while (true)
            {
                if (game.notEnuff == true)
                    break;
                Console.WriteLine("Your turn");
                string line = Console.ReadLine();
                if (game.TryMinus(line, out int number))
                {
                    game.Minus(number);
                    game.i++;

                    Console.WriteLine($"Total: {game._totalSticks}");

                    if (game._totalSticks > 0)
                    {
                        game.i++;
                        Random random = new Random();
                        int n;
                        if (game._totalSticks > 3)
                            n = 3;
                        else n = game._totalSticks;
                        int computerNum = random.Next(1, n);
                        game.Minus(computerNum);
                        Console.WriteLine($"Computer takes {computerNum} stick(s) ");

                        Console.WriteLine($"Total: {game._totalSticks}");
                        
                    }
                }
                else Console.WriteLine("U can take only 1-3 sticks");

            }

            if (game.WhoWasLast())
                Console.WriteLine("Game over. Computer wins ");
            else
                Console.WriteLine("Game over. You win this, congratz");

        }

        private static void HandleOnLowSticks()
        { 
            Console.WriteLine("Low sticks");
        }
    }

    
}
