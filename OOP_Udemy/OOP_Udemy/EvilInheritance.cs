using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Udemy
{
    public interface IShape
    {
        int CalcSquare();
    }
    public class Rect : IShape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public int CalcSquare()
        {
            return Width * Height;
        }
    }
    public class Square : IShape
    {
        public int SideLength { get; set; }
        public int CalcSquare()
        {
            return SideLength * SideLength;
        }
    }

    public class AreaCalculator
    {
        public static int CalcSquare(Square square)
        {
            return square.SideLength * square.SideLength;
        }

        public static int CalcSquare(Rect rect)
        {
            return rect.Height * rect.Width;
        }
    }
        
}
