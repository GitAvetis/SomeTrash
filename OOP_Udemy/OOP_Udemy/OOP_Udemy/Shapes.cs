using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Udemy
{
    public abstract class Shape
    {
        public Shape()
        {
            Console.WriteLine("Shape created");
        }
            
        //объявляем абстрактные члены
        public abstract void Draw();
        public abstract double Area();
        public abstract double Perimiter();


    }

    public class Triangle : Shape
    {
        private readonly double ab;
        private readonly double bc;
        private readonly double ac;

        public Triangle(double ab, double bc, double ac)
        {
            this.ab = ab;
            this.bc = bc;
            this.ac = ac;
            Console.WriteLine("Triangle created");
        }
        public override double Area()
        {
            double s = (ab + bc + ac) / 2;
            return Math.Sqrt(s * (s - ab) * (s - bc) * (s - ac));

        }

        public override void Draw()
        {
            Console.WriteLine("Drawing triangle...");
        }

        public override double Perimiter()
        {
            return ab + bc + ac;
        }
    }
    public class Reactangle : Shape
       
    {   
        private readonly double width;
        private readonly double height;

        public Reactangle(double width, double height)
        {
            this.width = width;
            this.height = height;

            Console.WriteLine("Rectangle Created");
        }
        public override double Area()
        {
            return width * height;
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing Rectangle");
        }

        public override double Perimiter()
        {
            return 2 * (width + height);
        }  
    }
}
