using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Hangman
{
    public class HangmanLogic
    {
        private string word { get; set; }//поле для слова, полученного из файла
        private char[] str { get; set; }//поле для слова, переведённого в формат массива.
        public string Words()//получение рандомного слова из файла. Возвращает его в виде стринга
        {
            string[] allLines = File.ReadAllLines("WordsStockRus.txt");
                        
            Random rnd = new Random();
            int wordIndex = rnd.Next(0, allLines.Length);
            word = allLines[wordIndex];
            word.ToLower();
            word.Trim();
                        
            return word;

        }
        public char[] WordAsMassOfChars()//преобразование слова в виде строки в массив чаров
        {
                         
            str = word.ToCharArray();
            return str;
        }
        public char[] WordCut( char [] str)//обрезаем из слова первый и последний элемент
        {
            char[] fullWord  = new char[str.Length-2];
            int i=0;
            int k=1;

            while (k != str.Length - 1 && i != str.Length)
            {
                fullWord[i] = str[k];
                i++;
                k++;
            }
                     
            return fullWord;
        }
        public string MassToString()//обратная конвертация массива в строку
        {
            string wordAsString = new string (WordCut(WordAsMassOfChars()));
            return wordAsString;
        }
        public string[] Field(string word)//всё подряд
        {   
            
            string[] fieldMass = new string[word.Length];
            int lastIndexOfWord = word.Length-1;
            int letterIndex;
            int counter=word.Length-2;
            int trys = counter;
            string firstLetter = Convert.ToString(word[0]);
            string lastLetter = Convert.ToString(word[lastIndexOfWord]);
            

            for (int i = 1; i < fieldMass.Length-1; i++)
            {
                fieldMass[i] = " _ ";
            }
            
            fieldMass[0] = firstLetter;
            fieldMass[lastIndexOfWord] = lastLetter;
           // str = WordAsMassOfChars();
           
            while (counter != 0&&trys!=0)
            {
                string field= new string(MassToString());
                Console.WriteLine();
                string letter = InsertLetters();
                string testLetter = Convert.ToString(letter);
                letterIndex = field.IndexOf(letter);
                
                if (field.Contains(letter))
                {
                    Console.WriteLine("DONE");
                    fieldMass[letterIndex+1] = $" {testLetter} ";
                    str[letterIndex] = '_';
                    counter--;
                }
                else
                {
                    Console.WriteLine("FAIL");
                    trys--;
                }
                Console.WriteLine();
                foreach (var item in field)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
                foreach (var item in fieldMass)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
                foreach (var item in str)
                {
                    Console.Write(item);
                }

                Console.WriteLine();

            }
            
            return fieldMass;
        }
        public string InsertLetters()//для ввода одной буквы с консоли. Возвращает букву формата стринг
        {
            string insert = (Console.ReadLine());   
            string letter;
            if (insert.Length > 1)
            {
                insert.ToCharArray();
                letter = Convert.ToString(insert[0]);
            }
            else
                letter = insert;                

            return letter;
        }
        public HangmanLogic()
        {
            
        }
    }
}
