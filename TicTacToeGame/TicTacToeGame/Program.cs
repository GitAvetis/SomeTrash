using System;

namespace TicTacToeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose slot from 1 up to 9");
            Console.WriteLine();
            //cоздаём экземпляр массива, заполняем его ячейки индексами и выводим его на консоль 
            char[,] mass = new char[3, 3];
            massIndex(mass);
            HowMatchIsTheFish(mass);
            Console.WriteLine();

            bool userMove;
            bool machineMove;
            bool stop=false;
            int totalMoves = 0;
            int fish=0;
            bool stop2 = WinOrLose(mass,stop);

            Console.WriteLine();
            Console.WriteLine("Choose slot");
            
            while (totalMoves<=4&&stop2==false&& fish==totalMoves)

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
                            stop2 = WinOrLose(mass, stop);
                            if (userMove == true && machineMove!=true && totalMoves<4&& stop2 == false)
                            {

                                bool machineMoves = MachineMoves(machineMove, mass,totalMoves);
                                if (machineMoves == true)
                                stop2 = WinOrLose(mass, stop);
                                totalMoves++;
                               
                            }
                            
                            userMove = true;

                        }
                    }
               
                    Console.WriteLine($"U choose {userFieldIndex}-slot");
                    Console.WriteLine("///////////////////////////////////////////////////////");
                    Console.WriteLine();
                    
                    printfField(mass);
                    fish = HowMatchIsTheFish(mass);

                    if (totalMoves <= 4 && stop2 != true && fish == totalMoves)
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Choose slot");
                    }
                    else if (stop2 == true && fish == totalMoves)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Machine wins");
                    }
                    else if (stop2 == true && fish > totalMoves)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Player wins!");
                    }
                    else if (stop2 == false && fish > totalMoves)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("We have no winner!");
                    }

                }

                else
                {
                    Console.WriteLine("enter value from 1 up to 9");
                }

            }

            Console.ReadLine();
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
        }//функиця вывода игрового поля
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
        }//функция для вывода массива с индексированными ячейками
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
        }//заполнение одной из ячеек игроком по индексу с консоли
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
        }//заполнение рандомной ячейки компьютером из числа свободных 
        static bool WinOrLose(char[,] mass,bool stop)//
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
        static int HowMatchIsTheFish(char[,] mass)
        {
            int fish = 0;

            for (int i = 0; i <3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (mass[i, j] == 'X')
                    {
                        fish++;
                    }
                }
            }

            return fish;
        }

        
    }
}
