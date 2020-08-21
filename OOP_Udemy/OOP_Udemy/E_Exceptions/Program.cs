using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace E_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DirFileDemo();
            }
            catch(Exception ex)
            {

            }
        }
        static void DirFileDemo()
        {
            //File.Copy("test.txt", @"F:\C#\Проекты", overwrite: true); - полный путь
            File.Copy("test.txt","test_copy.txt", overwrite: true);//Копирует файл(перезатрёт файл, если есть такой же файл при true)

            File.Move("test.txt", "test_copy_renamed.txt");

            File.Delete("test_copy.txt");

            if (File.Exists("test.txt"))//можно указать полный путь
                                        //проверяет наличие файла на диске. Не грантирует отсутвие исключений, 
                                        //так как файл в любой момент может пропасть, File.Exists выдаёт результат
                                        //проверки один раз при вызове(возращает тру или фолз)
            {
                File.AppendAllText("test.txt", "bla");
            }

            File.Replace("test_2.txt","test_3.txt","test_backup.txt");//Заменяет содержимое файлов и создаёт бэкап файла, который перезаписывается(тест3)

            bool existsDir = Directory.Exists(@"C:\tmp");//проверяем начличие определённой дерриктории по адресу
            if (existsDir)
            {
                var files = Directory.EnumerateFiles(@"C:\tmp", "*.txt", SearchOption.AllDirectories);
                //выписываем название всех файлов с нужным нам расширением.3 аргумент позволяет так же проверить содержимое вложенных папок
                foreach (var file in files)
                {
                    Console.WriteLine(file);//выдаст в консоль пути к нужным файлам
                }
            }
            //Directory.Delete
            //Path.GetFileName
            //string fullPath = Path.Combine(@"C:\tmp", "\\bla", "file.txt");

        }
        static void FileDemo()
        {
            IEnumerable<string> lines = File.ReadLines("test.txt");

            File.WriteAllText("test_2.txt", "my name is Artem");
            File.WriteAllLines("test_3.txt", new string[] { "My name", " is Artem" });
            File.WriteAllBytes("test_4.txt", new byte[] { 72, 101, 108, 108, 111 });
            
            string allText = File.ReadAllText("test_2.txt");
            Console.WriteLine(allText);

            string[] allLines = File.ReadAllLines("test_3.txt");
            Console.Write(allLines[0]);
            Console.WriteLine(allLines[1]);

            byte[] bytes = File.ReadAllBytes("test_4.txt");
            Console.WriteLine(Encoding.ASCII.GetString(bytes));


            Console.ReadLine();

            Stream fs = new FileStream("test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            try
            {
                string str = "Artem Not stupid!";
                byte[] strInBytes = Encoding.ASCII.GetBytes(str);

                fs.Write(strInBytes, 0, strInBytes.Length);
                 
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error:{ex.ToString()}");
            }
            finally
            {
                fs.Close();//аналог диспоуз, лучше использовать его, если есть возможность
            }

            Console.WriteLine("Now reading...");

            using (Stream readingStream = new FileStream("test.txt", FileMode.OpenOrCreate, FileAccess.Read))
            
            {
                byte[] temp = new byte[readingStream.Length];

                int bytesToRead = (int)readingStream.Length;
                int bytesRead = 0;
                while (bytesToRead  > 0)
                {
                    int n = readingStream.Read(temp, bytesRead, bytesToRead);
                    
                    if (n == 0)
                        break;

                    bytesRead += n;
                    bytesToRead -= n;
                    
                }
                string str = Encoding.ASCII.GetString(temp, 0, temp.Length);

                Console.WriteLine(str);
                Console.ReadLine();
            }
            /* Блок, аналогичный тому, что будет выполнять блок using
            Stream readingStream = null;
            try
            {
                readingStream = new FileStream("test.txt", FileMode.OpenOrCreate, FileAccess.Read);            }
            finally
            {
                fs.Close();
            }
            
             */
        }
        public void ExceptionsDemo()
        {

            FileStream file = null;
            try
            {
                file = File.Open("temp.txt", FileMode.Open);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine();
            }
            finally
            { 
              if(file!=null)
              file.Dispose();
            }

            Console.ReadLine();

            Console.WriteLine("Pls, enter any value...");

            string result = Console.ReadLine();

            int number = 0;

            try
            {
                number = int.Parse(result);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("OverflowException");
            }
            catch(FormatException ex)
            {
                Console.WriteLine("A format exception has occured");
                Console.WriteLine("Information is below");
                Console.WriteLine(ex.ToString());
            }
            catch(Exception ex)
            {

            }
            
            
            Console.WriteLine(number);
        } 
    }
}
