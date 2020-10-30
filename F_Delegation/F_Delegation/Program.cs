using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;

namespace F_Delegation
{
    class Program
    {
        static void Main(string[] args)
        {
           // ParsTest("Top100ChessPlayers3.csv");
            MinMaxSumAverage("Top100ChessPlayers3.csv");
            Console.WriteLine();
        }
        static void ParsTest(string file)
        {
            string[] list = File.ReadAllLines(file);
            list = file.Split(';');
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
           
        }
        static void MinMaxSumAverage(string file)
        {
            //var lines = File.ReadAllLines(file);

            IEnumerable<ChessPLayer> list = File.ReadAllLines(file)
                   .Skip(1)
                   .Select(ChessPLayer.ParseFideCsv)
                   .Where(player => player.BirthYear > 1988)
                   .OrderByDescending(player => player.Rating)
                   .Take(10);

            //      .ToList();
             Console.WriteLine($"The lowest rating in TOP10: {list.Min(x=>x.Rating)}");
            //Console.WriteLine($"The highest rating in TOP10: {list.Max(x=>x.Rating)}");
          //  Console.WriteLine($"The average rating in TOP10: {list.Average(x=>x.Rating)}");
        }
        private static void DisplayLargestFilesWithLinq(string pathToDir) 
        {
            new DirectoryInfo(pathToDir)
                .GetFiles()
                .OrderByDescending(file => file.Length)
                .Take(5)
                .ForEach(file => Console.WriteLine($"{file.Name} weights{file.Length}"));// в случае, если тело метода(после => содержит больше одной строки, то оно помещается в фигурные скобки и для возврата значения из метода необходимо прописать ретёрн

            /* Валидный способ решения без foreach
            IEnumerable<FileInfo> orderedFiles = new DirectoryInfo(pathToDir)
                     .GetFiles()
                     .OrderBy(file => file.Length)
                     .Take(5);
            foreach (var file in orderedFiles)
            {
                Console.WriteLine($"{file.Name} weights{file.Length}");
            }*/
        }

       /* static long KeySelector(FileInfo file)
        {
            return file.Length;
        }*/

        private static void DisplayLargestFilesWithoutLinq(string pathToDir)
        {
            var dirInfo = new DirectoryInfo(pathToDir);
            FileInfo[] files = dirInfo.GetFiles();

            Array.Sort(files, FilesComparison);

            for (int i = 0; i < 5; i++)
            {
                FileInfo file = files[i];
                Console.WriteLine($"{file.Name} weights {file.Length}");

            }
        }

        private static int FilesComparison(FileInfo x, FileInfo y)
        {
            if (x.Length == y.Length) return 0;
            if (x.Length > y.Length) return 1;
            return -1;

        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //var timer = (Timer)sender;
            Console.WriteLine("Handling Timer Elapsed Event");
        }

        private static void HandleOnTooFast(object obj, CarArgs speed)
        {
            Console.WriteLine($"Stop called Speed{speed.CurrentSpeed}");
            var car = (Car)obj;
            car.Stop();
        }
    }
}
