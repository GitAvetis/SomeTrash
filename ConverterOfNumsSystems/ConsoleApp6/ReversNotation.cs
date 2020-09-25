using System;


namespace ConverterOfNumsSystems
{
    class ReversNotation
    {
        public ReversNotation()
        {

            
        }
        public double NumInDecimal(int _notation, string _num)
        {
            Console.WriteLine($"Enter your number for converting from {_notation}-th number system");
            int coefficient;

            double _decNum = 0;
            int counter = _num.Length - 1;

            for (int j = 0; j < _num.Length; j++)
            {
                if (_num[j] - 48 > 9)
                    coefficient = _num[j] - 55;

                else
                    coefficient = _num[j] - 48;

                _decNum += (coefficient) * (Math.Pow(_notation, counter));
                counter--;

            }

            return _decNum;

        }
    }
}
