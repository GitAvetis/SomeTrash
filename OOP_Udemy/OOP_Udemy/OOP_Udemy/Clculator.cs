using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Udemy
{
   public static class Clculator
    {
        public static bool TryDivide(double divisible, double divisior, out double result)
        {
            result = 0;
            if(divisior==0)
            {
                return false;
            }
            result = divisible / divisior;
            return true;
        }
        public static double Avarage(int[] numbers)
        {
            double sum = 0;
            double count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum = numbers[i] + sum;
            }
            count = sum / numbers.Length;
            return count;
        }
        public static double Avarage2(params int[] numbers)
        {
            double sum = 0;
            double count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum = numbers[i] + sum;
            }
            count = sum / numbers.Length;
            return count;
        }
        public static double CalcTriangleSquare(double ab, double bc, double ac)
        {
            double p = (ab + bc + ac) / 2;
            return Math.Sqrt(p * (p - ab) * (p - bc) * (p - ac));

        }
        public static double CalcTriangleSquare(double b, double h)
        {
            return 0.5 * b * h;
        }
        public static double CalcTriangleSquare(double ab, double ac, int alpha, bool IsInRadians=false)
        {
            if (IsInRadians)
            {
                return 0.5 * ab * ac * Math.Sin(alpha);
            }
            else
            {
                double rads = alpha * Math.PI / 180;
                return 0.5 * ab * ac * Math.Sin(rads);
            }
        }
            
        
    }
}
