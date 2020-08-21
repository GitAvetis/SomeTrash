using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Udemy.HomeWorks
{
    /*
     Разработать класс представляющий комплексное число. Класс должен содержать два свойства для представления вещестенной (double) и мнимой части (double). 
    Сделать так, чтобы создать экземпляр класса без передачи соответствующих аргументов было невозможно.

Создать два метода, реализующих сложение и вычитание двух комплексных чисел. Чтобы сложить два комплексных 
    числа необходимо по отдельности сложить их вещественные и мнимые части.

То есть, предположим, что мы имеет два комплексных числа. У первого вещественная часть равна 1, мнимая 2. 
    У второго вещественная часть равна 3, мнимая 1. Результатам будет комплексное число, где вещественная часть равна 1+3=4, а мнимая равна 2 + 1 = 3.

Операция вычитания работает по тому же принципу, что и сложение (ну, только вычитание).

     */
    public class Complex
    { 
        public double Cr { get; private set; }
        public double Ci { get; private set; }
        public Complex(double cr,double ci)
        {
            Cr = cr;
            Ci = ci;
            
        }
        private Complex ()
        {

        }
        public Complex Plus (Complex other)
        {
            Complex complex = new Complex();
            complex.Cr = other.Cr + Cr;
            complex.Ci = other.Ci + Ci;
            return complex;

        }
        public Complex Minus (Complex other)
        {
            Complex complex = new Complex();
            complex.Cr = other.Cr - Cr;
            complex.Ci = other.Ci - Ci;
            return complex;

        }



    }
}
