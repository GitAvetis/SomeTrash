using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Udemy.Homeworks
{
    class TicTacToeGame
    {
        public enum Players
        {
            Player1,
            Player2
        }
        public TicTacToeGame(Players players=Players.Player1)
        {
            char[,] mass=new char [3,3];
            int k = int.Parse(Console.ReadLine());
            int i = 0;
            while (i < 10)
            {
                if (k > 0 && k < 10)
                {
                    switch (k)
                    {
                        case 1:
                            mass[0, 0] = 'X';
                            return;
                        case 2:
                            mass[0, 1] = 'X';
                            return;
                        case 3:
                            mass[0, 2] = 'X';
                            return;
                        case 4:
                            mass[1, 0] = 'X';
                            return;
                        case 5:
                            mass[1, 1] = 'X';
                            return;
                        case 6:
                            mass[1, 2] = 'X';
                            return;
                        case 7:
                            mass[2, 0] = 'X';
                            return;
                        case 8:
                            mass[2, 1] = 'X';
                            return;
                        case 9:
                            mass[2, 2] = 'X';
                            return;

                    }
                    
                    i++;
                }
                else
                {
                    Console.WriteLine("enter value from 1 up to 9");
                }

            }
            
            foreach (var item in mass)
            {
                Console.WriteLine(item);
            }
        }
       
    }
}
