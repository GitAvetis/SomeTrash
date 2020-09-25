using System;


namespace ConverterOfNumsSystems
{
    class StraightNotation
    {
        public StraightNotation(int _notation, double _num)
        {
           int counter = 0;
           int _numForCicle = Convert.ToInt32(_num);
           int _octalMassLength = Convert.ToInt32(_num);
           if (_num == 0)
             counter = 1;

           while (_octalMassLength >= 1)
           {
               _octalMassLength /= _notation;
               counter++;
           }

           string[] massStr = new string[counter];

           for (int j = massStr.Length - 1; j >= 0; j--)
           {
               massStr[j] = (_numForCicle % _notation).ToString();
                
               if (int.Parse(massStr[j])>9&& int.Parse(massStr[j]) <= 15 )
               {
                   massStr[j] = ((char)(int.Parse(massStr[j]) + 55)).ToString();
               }
                _numForCicle /= _notation;
            
           }

           Console.WriteLine($"your number in { _notation}-th number system");

           foreach (var item in massStr)
           {
               Console.Write(item);
           }

           Console.WriteLine();
            
        }
        
    }
}
