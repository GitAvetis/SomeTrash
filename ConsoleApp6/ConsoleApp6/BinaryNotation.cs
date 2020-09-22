using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp6
{
    class BinaryNotation
    {
        public BinaryNotation()
        {
            while (true)
            {
                Console.WriteLine("Enter number in decimal notation");
                int _num = int.Parse(Console.ReadLine());
                int counter = 0;
                int _numForCicle = _num;
                if (_num == 0)
                    counter = 1;
                while (_num >= 1)
                {
                    _num /= 2;
                    counter++;
                }

                int[] mass = new int[counter];

                for (int j = mass.Length - 1; j >= 0; j--)
                {   
                    mass[j] = _numForCicle % 2;
                    _numForCicle /= 2;

                }

                Console.WriteLine("Your number in binary notation");

                foreach (var item in mass)
                {

                    Console.Write(item);

                }

                Console.WriteLine();

            }
        }
        
    }
}
