using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Udemy
{
    class Lesson80_BoxingUnboxing_
    {
        static void Lesson80()
        {
            //boxing
            int x = 1;
            object obj = x;
            //unboxing
            int y = (int)obj;
            Console.WriteLine(y);
            Console.ReadLine();

            double pi = 3.14;
            object obj1 = pi;

            int number = (int)(double)obj1;
            Console.WriteLine(number);
        }


        public static void Do(object obj2)
        {
            bool IsPointRef = obj2 is PointRef;
            if (IsPointRef)
            {
                PointRef pr = (PointRef)obj2;
                Console.WriteLine(pr.x);
            }
            else
            {
                //do smth
            }
            PointRef pr1 = obj2 as PointRef;
            if(pr1 != null)
            {
                Console.WriteLine(pr1.x);
            }
            else
            {
                //do smth
            }

        }

        
    }
}
