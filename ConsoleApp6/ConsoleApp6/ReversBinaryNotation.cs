using System;


namespace ConsoleApp6
{
    class ReversBinaryNotation
    {
        public ReversBinaryNotation()
        {
            while (true)
            {
                Console.WriteLine("Enter your number in Binary notation");
                string _num = Console.ReadLine();
                if (_num != "")
                {
                    if (_num[0] - 48 == 0 && (_num.Length <= 1 ))
                    {
                        Console.WriteLine($"Your number in Decimal notation: {_num}");
                        _num = _num.Remove(0, 1);
                    } 
                    else

                    while (_num.StartsWith('0'))
                        {
                            _num = _num.Remove(0,1);
                        }
                    if (_num != "")
                    {
                        double _decNum = 0;
                        int counter = _num.Length - 1;

                        _decNum += Math.Pow(2, _num.Length - 1);

                        for (int j = 1; j < _num.Length; j++)
                        {

                            if (_num[j] - 48 == 1)
                            {
                                counter--;
                                _decNum += Math.Pow(2, counter);
                            }
                            else
                            {
                                counter--;
                            }

                        }

                        Console.WriteLine($"Your number in Decimal notation: {_decNum}");

                    }

                }       
                else
                {
                    Console.WriteLine("Empty srting");
                    Console.WriteLine();
                }
            }

        }
    }
}
