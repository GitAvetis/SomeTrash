namespace ConverterOfNumsSystems
{
    class FilterForInput
    {
        public FilterForInput()
        {
        }

        public bool OkString(int _notationNum, string _inputString)
        {   

            
            if (string.IsNullOrWhiteSpace(_inputString))
            {
               return   false;
            }
            else if (_notationNum == 16)
            {
                int counter = 0;
                for (int i = 0; i < _inputString.Length; i++)
                {
                    if ((_inputString[i] >= 48 && _inputString[i] <=57)||((_inputString[i] >= 65 && _inputString[i] <= 70)))
                        counter++;
                }
                if (counter == _inputString.Length)
                    return true;
                else
                    return false;

            }
            else
            {
            
               int counter = 0;
               for (int i = 0; i < _inputString.Length; i++)
               {
                   if (_inputString[i] >= 48 && _inputString[i] <= _notationNum+47)
                       counter++;
               }
               if (counter == _inputString.Length)
                  return true;
               else
                  return false;
                
            }
            
        }
        
    }
}
