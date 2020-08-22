using System;

namespace TicTacToeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose slot from 1 up to 9");
            Console.WriteLine();

            char[,] mass = new char[3, 3];
            massIndex(mass);

            Console.WriteLine();

            bool userMove;
            bool machineMove;
            bool stop=false;
            int totalMoves = 0;
            bool stop2 = WinOrLose(mass,stop);

            Console.WriteLine();
            Console.WriteLine("Choose slot");

            while (totalMoves<=5&&stop2==false)

            {
                int i;
                int j;
                Console.WriteLine();
                stop2 = WinOrLose(mass, stop);

                int userFieldIndex = int.Parse(Console.ReadLine());

                if (userFieldIndex > 0 && userFieldIndex < 10)
                
                {
                    {
                        userMove = false;
                        machineMove = false;
                        i = 0;
                        j = 0;

                        if (totalMoves == 2 || totalMoves==4)
                        {
                            Console.Clear();
                        }
                        while (userMove != true)
                        {                            
                            userMove = UserMoves(userMove, userFieldIndex, mass, i, j);

                            if (userMove == true&&machineMove!=true&&totalMoves<4)
                            {

                                bool machineMoves = MachineMoves(machineMove, mass,totalMoves);
                                if (machineMoves == true)
                                    totalMoves++;
                               
                            }
                            userMove = true;

                        }
                    }
               
                    Console.WriteLine($"U choose {userFieldIndex}-slot");
                    Console.WriteLine("///////////////////////////////////////////////////////");
                    Console.WriteLine();
                    
                    printfField(mass);

                    if (totalMoves <= 4)
                    {
                        Console.WriteLine("Choose slot");
                    }
                    
                    else
                    {
                        Console.WriteLine("It's over. We have no winner");
                    }
                }

                else
                {
                    Console.WriteLine("enter value from 1 up to 9");
                }

            } 
        }
        static void printfField(char[,] mass)
        {
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {

                    if (j == 2 && i == 0)
                    {
                        Console.Write($"|{mass[i, j]}|   ");
                        Console.WriteLine();
                        Console.WriteLine("________________");
                    }
                    else if (j == 2 && i == 1)
                    {
                        Console.Write($"|{mass[i, j]}|   ");
                        Console.WriteLine();
                        Console.WriteLine("________________");
                    }
                    else
                    {
                        Console.Write($"|{mass[i, j]}|   ");
                    }
                }
            }
        }
        static void massIndex(char[,] mass)
        {
            int b = 1;

            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    mass[i, j] = Convert.ToChar(Convert.ToString(b));
                    if (j == 2 && i == 0)
                    {
                        b++;
                        Console.Write($"|{mass[i, j]}|   ");
                        Console.WriteLine();
                        Console.WriteLine("__________________");
                    }
                    else if (j == 2 && i == 1)
                    {
                        b++;
                        Console.Write($"|{mass[i, j]}|   ");
                        Console.WriteLine();
                        Console.WriteLine("__________________");

                    }
                    else
                    {

                        b++;
                        Console.Write($"|{mass[i, j]}|   ");

                    }
                }
            }
        }
        static bool UserMoves(bool userMoves, double userFieldIndexes, char[,] mass, int i, int j)
        { 
            userFieldIndexes = userFieldIndexes - 1;
            double remainder= userFieldIndexes / 3 - Convert.ToInt32(userFieldIndexes)/3;
            i = Convert.ToInt32(userFieldIndexes) / 3;
            if (remainder == 0)
            {
                j = 0;
            }
            else if (remainder > 0.5)
            {
                j = 2;
            }
            else
            {
                j = 1;
            }
            if(mass[i, j]!='X'&& mass[i, j] != 'O')
            {
               mass[i, j] = 'X';
               userMoves = true;

            } 
            else
            { 
                Console.WriteLine("this slot is already used");
            }
 
            return (userMoves);
        }
        static bool MachineMoves(bool machineMoves,char[,] mass, int totalMoves)
        {
            Random rnd = new Random();
            int l;
            int m;
            while (machineMoves != true)
            {
                 l = rnd.Next(0, 3);
                 m = rnd.Next(0, 3);

                if (mass[l, m] != 'X' && mass[l, m] != 'O'&&totalMoves<4)
                {
                    mass[l, m] = 'O';
                    machineMoves = true;
                }
            }

            return (machineMoves);
        }
        static bool WinOrLose(char[,] mass,bool stop)
        {

            if (mass[0,0]== mass[0,1]&&mass[0,1]==mass[0,2])
            {
                Console.WriteLine("WIN!");
                stop = true;
            }
            else if (mass[0, 0] == mass[1, 0] && mass[2, 0] == mass[1, 0])
            {
                Console.WriteLine("WIN!");
                stop = true;
            }
            else if (mass[0, 0] == mass[1, 1] && mass[2, 2] == mass[1, 1])
            {
                Console.WriteLine("WIN!");
                stop = true;
            }
            else if (mass[2, 0] == mass[1, 1] && mass[0, 2] == mass[1, 1])
            {
                Console.WriteLine("WIN!");
                stop = true;
            }
            else if (mass[0, 0] == mass[1, 1] && mass[2, 2] == mass[1, 1])
            {
                Console.WriteLine("WIN!");
                stop = true;
            }
            else if (mass[1, 0] == mass[1, 1] && mass[1, 2] == mass[1, 1])
            {
                Console.WriteLine("WIN!");
                stop = true;
            }
            else if (mass[2, 0] == mass[2, 1] && mass[2, 2] == mass[2, 1])
            {
                Console.WriteLine("WIN!");
                stop = true;
            }
            else if (mass[0, 2] == mass[1, 2] && mass[2, 2] == mass[1, 2])
            {
                Console.WriteLine("WIN!");
                stop = true;
            }
            else if (mass[0, 1] == mass[1, 1] && mass[2, 1] == mass[1, 1])
            {
                Console.WriteLine("WIN!");
                stop = true;
            }
            else if (mass[0, 0] == mass[1, 0] && mass[2, 0] == mass[1, 0])
            {
                Console.WriteLine("WIN!");
                stop = true;
            }
            return stop;

        }
    }
}
