using System;
using System.IO;

namespace Hangman
{
    public class HangmanLogic
    {
        public  string word { get; set; }//поле для слова, полученного из файла
        public  char[] str { get; set; }//поле для слова, переведённого в формат массива.

        public string [] emptyFieldMass (ref string[] fieldMass)//заполнение промежутка между первой и последней буквой слова нижними подчёркиваниями
        {
            int lastIndexOfWord = word.Length - 1;
            string firstLetter = Convert.ToString(word[0]);
            string lastLetter = Convert.ToString(word[lastIndexOfWord]);
            
            fieldMass = new string[word.Length];
            for (int i = 1; i < fieldMass.Length - 1; i++)
            {
                fieldMass[i] = " _ ";
            }

            fieldMass[0] = firstLetter;
            fieldMass[lastIndexOfWord] = lastLetter;
            
            return fieldMass;
        }
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
        public char[] WordAsMassOfChars(string word )//преобразование слова в виде строки в массив чаров
        {
            str = word.ToCharArray();
            return str;
        }
        public char[] WordCut( ref char [] str)//обрезаем из слова первый и последний элемент
        {
            char[] cutWord  = new char[str.Length-2];
            int i=0;
            int k=1;

            while (k != str.Length - 1 && i != str.Length)
            {
                cutWord[i] = str[k];
                i++;
                k++;
            }
                     
            return cutWord;
        }
        public string MassToString(ref char [] str)//обратная конвертация массива в строку
        {
            
            string wordAsString = new string(WordCut(ref str)) ;
            return wordAsString;
        }
       
        public int counter { get; set; }
        public int trys { get; set; }
        public int Fail(ref int trys)
        {
            this.trys = trys;
            int success = trys--;
            return success;
        }
        public int Success(ref int counter)
        {
            this.counter = counter;
            int success = counter--;
            return success;
        }
        public string MassOfStringsToString(string[] fieldMass)//обратная конвертация массива в строку
        {

            string wrdAsString="";
            for (int i = 0; i < word.Length; i++)
            {
                wrdAsString += fieldMass[i];
            }
             
            return wrdAsString;
        }
        public bool WinOrLose(ref string[] fieldMass)
        {
            bool winOrLose;
            string field = new string(MassOfStringsToString(fieldMass));

            if (field.Contains('_'))
            {
                winOrLose = false;
            }
            else
                winOrLose = true;

            return winOrLose;
        }
        public string[] Field(ref char[] str,ref int trys, ref int counter,ref string[] fieldMass)//Основная логика.Поиск введённой буквы в массиве.
        {
 
            string field= new string(MassToString(ref str));
            string testLetter = Convert.ToString(InsertLetters());

            if (field.Contains(testLetter) && testLetter != "")
            {
                fieldMass[field.IndexOf(testLetter) + 1] = $" {testLetter} ";
                str[field.IndexOf(testLetter) + 1] = '_';
                Success(ref counter);
            }
            else
            {
                Fail(ref trys);
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
