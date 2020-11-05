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
            LinqDemo("Top100ChessPlayers3.csv");
            RemoveAllDemo();
        }
        static void RemoveAllDemo()
        {
            var list = new List<int> { 0, 1, 2, 3, 4, 5 };
            list.RemoveAll(x => x%2==0);//greedy 
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        static void RemoveInFor()
        {
            var list = new List<int> { 0, 1, 2, 3, 4, 5 };
            for (int i = 0; i < list.Count; i++)
            {
                var item=list[i];
                if (item <= 3)
                {
                    list.Remove(item);
                    i--;//чтобы не сдвинуть индексы
                }
            }
            Console.WriteLine(list.Count==2);
        }
        static void RemoveInForBackwards()
        {
            var list = new List<int> { 0, 1, 2, 3, 4, 5 };
            for (int i = list.Count-1; i >=0 ; i--)
            {
                var item = list[i];
                if (item <= 3)
                {
                    list.Remove(item);
                }
            }
            Console.WriteLine(list.Count == 2);
        }
        static void RemoveInForeach()
        {
            var list = new List<int> { 0, 1, 2, 3, 4, 5 };
            foreach (var item in list)
            {
                if(item % 2 == 0)
                {
                    list.Remove(item);
                }
            }
        }
        static void OtlojennoeIMnojestvennoeVipolnenie()
        {
            var list = new List<int> { 1, 2, 3 };
            var query = list.Where(c => c >= 2).ToList();
            // var query = list.Where(c => c >= 2);//yeld return в where
            //запрос выполняется только в случае обращения гриди оператора 
            //поэтому сразу в переменную query не занесётся 2 и 3. Сначала тройка удалится
            // после чего при вызове query.Count() будет обращение к нашему листу, в котором уже 1 элемент,
            // удоволетворяющий условию. Поэтому на выходе получем 1(хотя по логике мы ждали двойку)
            list.Remove(3);
            //если мы хотим сразу материализовать результаты запроса, то можно в конце добавить гриди оператор .ТуЛист()

            Console.WriteLine(query.Count());
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
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
        static void LinqDemo(string file)
        {

            {
                //lazy операторы 
                IEnumerable<ChessPLayer> list = File.ReadAllLines(file)
                       .Skip(1)
                       .Select(ChessPLayer.ParseFideCsv)
                       //.Where(delegate(ChessPLayer player){ return player.BirthYear > 1988; })// устаревший аналог люмбда выражения называющийся анонимным методом
                       .Where(player => player.BirthYear > 1988)
                       .OrderByDescending(player => player.Rating)
                       .Take(10)
                       .ToList();//добавили гриди оператор, чтобы при каждом обращении к листу не заставлять компилятор
                                 //повторно проходи по всему списку занаво делая выборку по нашим условиям. Теперь это будет сделанно лишь единожды
                                 //это решает проблему multiple enumeration

                // SQL-like syntax:
              /*  IEnumerable<ChessPLayer> list2 = File.ReadAllLines(file)
                       .Skip(1)
                       .Select(ChessPLayer.ParseFideCsv);
                var filtered = from player in list2
                               where player.BirthYear > 1988
                               orderby player.Rating descending
                               select player;
              */
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine($"The lowest rating in TOP10: {list.Min(x => x.Rating)}");
                Console.WriteLine($"The highest rating in TOP10: {list.Max(x => x.Rating)}");
                Console.WriteLine($"The average rating in TOP10: {list.Average(x => x.Rating)}");

                Console.WriteLine(list.First());
                Console.WriteLine(list.Last());

                Console.WriteLine(list.First(player => player.Counrty == "USA"));
                Console.WriteLine(list.Last(player => player.Counrty == "USA"));

                ChessPLayer firstFromBra = list.FirstOrDefault(player => player.Counrty == "BRA");
                if (firstFromBra != null)
                {
                    Console.WriteLine(firstFromBra.LastName);
                }
                var lastFromBra = list.LastOrDefault(player => player.Counrty == "BRA");

                Console.WriteLine(list.Single(player => player.Counrty == "FRA"));//Работает только в случае, когда только один случай удоволетворяет условию, иначе выбросит исключение
                Console.WriteLine(list.SingleOrDefault(player => player.Counrty == "BRA"));//Работает так же, как и сингл, но отработет, если вообще не будет удоволетворяющих вхождений.  

                Console.WriteLine(list.SingleOrDefault(player => player.Counrty == "USA"));// Должен выбросить исключение, так как в списке более одного совпадения по условию
            }
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
