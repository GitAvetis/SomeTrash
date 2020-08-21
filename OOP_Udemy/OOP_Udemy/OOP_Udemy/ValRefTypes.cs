using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Udemy
{
    public struct EvilStruct
    {
        public int x;
        public int y;
        public PointRef PointRef;
    }
    public struct PointVal
    {
        public int x;
        public int y;

        public void LogValues()
        {
            Console.WriteLine($"X={x}; Y={y}");
        }

    }
    public class PointRef
    { 
        public int x;
        public int y;

        public void LogValues()
        {
            Console.WriteLine($"X={x}; Y={y}");
        }
    }
}