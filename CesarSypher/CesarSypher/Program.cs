using System;
using System.Collections.Generic;
using System.IO;

namespace CesarSypher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vvedite kluch shifrovki");
            int gap = int.Parse(Console.ReadLine());

            Dictionary<int, string> D_alphabet = new Dictionary<int, string>(33);

            string[] alphabet = File.ReadAllLines("alphabet.txt");
            int index;

            Dictionary<string, int> D_alphabet2 = new Dictionary<string, int>(33);
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (i + gap < 33)
                {
                    index = i + gap;
                    D_alphabet2.Add(alphabet[index], i);
                }

                else
                {
                    index = gap - (alphabet.Length - i);
                    D_alphabet2.Add(alphabet[index], i);
                }

            }

           /* foreach (var item in D_alphabet2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine();
*/
            for (int i = 0; i < alphabet.Length; i++)
            {
                D_alphabet.Add(i, alphabet[i]);
            }
            /*foreach (var item in D_alphabet)
            {
                Console.WriteLine(item);
            }
            */
            Console.WriteLine("Fraza dlya rasshifrovki:");
            string str = Console.ReadLine();
           
            string[] words = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
          
                for (int i = 0; i < words.Length; i++)
                {
                    string[] wordAsMassOfStrings=WordAsMassOfStrings(words,i);
                    for (int k = 0; k < words[i].Length; k++)
                    {
                         int key = D_alphabet2[wordAsMassOfStrings[k]];
                         string value = D_alphabet[key];
                         Console.Write(value);
                    }
                Console.WriteLine();
                }

            
        }

        static string[] WordAsMassOfStrings(string[] words, int j)
        {

            string[] wordAsMassOfStrings = new string[words[j].Length];
            char[] wordAsMassOfChars = words[j].ToCharArray();
            for (int i = 0; i < words[j].Length; i++)
            {
                wordAsMassOfStrings[i] = wordAsMassOfChars[i].ToString();
            }
            

            return wordAsMassOfStrings;
        }
    }
}
