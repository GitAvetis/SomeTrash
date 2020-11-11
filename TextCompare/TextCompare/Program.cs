using System;

namespace TextCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            var text=new Text();
            int counter = 1;
            int counter2;

            Console.WriteLine("Введите название первого файла");
            string name_1 = $"{Console.ReadLine()}"+".txt";

            Console.WriteLine("Введите название второго файла");
            string name_2 = $"{Console.ReadLine()}" + ".txt";

            string[] text1 = text.TextExample(name_1);
            string[] text2 = text.TextExample(name_2);

            for (int i = 0; i < text1.Length; i++)
            {
                if (i > 8)
                {
                    if (text1[i] != text2[i])
                    {
                        Console.WriteLine($"строка:{counter} false");
                        Console.WriteLine();
                        Console.WriteLine($"Строки {name_2}");
                        Console.WriteLine();

                        for (int j = -3; j < 5; j++)
                        {
                            counter2 =counter+ j;
                            if (i+j==i)
                                Console.ForegroundColor = ConsoleColor.Red;
                            else
                                Console.ForegroundColor = ConsoleColor.White;

                            Console.WriteLine($"{counter2}  {text2[i + j]}");
                        }

                        Console.WriteLine();
                        Console.WriteLine($"Строки в {name_1}");
                        Console.WriteLine();

                        for (int j = -3; j < 5; j++)
                        {
                            counter2 = counter + j;
                            if (i + j == i)
                                Console.ForegroundColor = ConsoleColor.Red;
                            else
                                Console.ForegroundColor = ConsoleColor.White;

                            Console.WriteLine($"{counter2}  {text1[i + j]}");
                        }

                        i = text1.Length;

                        Console.WriteLine();
                        Console.WriteLine("Исправьте проблемную часть и запустите программу повторно для дальнейшего поиска несовпадений");
                        Console.WriteLine("Нажмите ввод, чтобы закончить программу...");
                        Console.WriteLine();
                        Console.ReadLine();

                    }
                }

                else
                {
                    if (text1[i] != text2[i])
                    {
                        Console.WriteLine($"строка:{counter} false");
                        Console.WriteLine();
                        Console.WriteLine($"Строки в рабочем коде");
                        Console.WriteLine();

                        for (int j = 0; j < 8; j++)
                        {
                            counter2 = counter + j;
                            if (i + j == i)
                                Console.ForegroundColor = ConsoleColor.Red;
                            else
                                Console.ForegroundColor = ConsoleColor.White;

                            Console.WriteLine($"{counter2}  {text2[i + j]}");
                        }
                        

                        Console.WriteLine();
                        Console.WriteLine($"Строки в проблемном коде");
                        Console.WriteLine();

                        for (int j = 0; j < 8; j++)
                        {
                            counter2 = counter + j;
                            if (i + j == i)
                                Console.ForegroundColor = ConsoleColor.Red;
                            else
                                Console.ForegroundColor = ConsoleColor.White;

                            Console.WriteLine($"{counter2}  {text1[i + j]}");
                        }

                        i = text1.Length;
                        Console.WriteLine();
                        Console.WriteLine("Исправьте проблемную часть и запустите программу повторно для дальнейшего поиска несовпадений");
                        Console.WriteLine("Нажмите ввод, чтобы закончить программу...");
                        Console.WriteLine();
                        Console.ReadLine();
                    }

                }
                   
                counter++;
            }
        }
        
    }
}
