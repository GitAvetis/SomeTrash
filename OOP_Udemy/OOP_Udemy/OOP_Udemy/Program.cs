using OOP_Udemy.Homeworks;
using OOP_Udemy.HomeWorks;
using System;
using System.Collections.Generic;

namespace OOP_Udemy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose slot from 1 up to 9");
            Console.WriteLine();

            char[,] mass = new char[3, 3];

            massIndex(mass);
            Console.WriteLine();

            Random rnd = new Random();
            bool userMove=false;
            bool machineMove = false;
            int totalMoves = 0;
         
            Console.WriteLine();
            Console.WriteLine("Choose slot");
            while (true)
                    
            {
               Console.WriteLine();
               int userFieldIndex = int.Parse(Console.ReadLine());
               
               if (userFieldIndex > 0 && userFieldIndex < 10)
               {
                   userMove = false; 
                   machineMove = false;

                    if (totalMoves == 3 || totalMoves == 6)
                    {
                        Console.Clear();
                    }

                    while (userMove != true)
                       {

                       if (userFieldIndex == 1 && mass[0, 0] != 'O'&& mass[0, 0] != 'X' )
                       {
                           mass[0, 0] = 'X';
                           userMove=true;

                       }
                       else if (userFieldIndex == 2 && (mass[0, 1] != 'O' && mass[0, 0] != 'X'))
                       {
                           mass[0, 1] = 'X';
                            userMove = true;
                        }
                       else if (userFieldIndex == 3 && (mass[0, 2] != 'O' && mass[0, 0] != 'X'))
                       {
                           mass[0, 2] = 'X';
                            userMove = true;
                        }
                       else if (userFieldIndex == 4 && (mass[1, 0] != 'O' && mass[0, 0] != 'X'))
                       {
                           mass[1, 0] = 'X';
                            userMove = true;
                        }
                       else if (userFieldIndex == 5 && (mass[1, 1] != 'O' && mass[0, 0] != 'X'))
                       {
                           mass[1, 1] = 'X';
                            userMove = true;
                        }
                       else if (userFieldIndex == 6 && (mass[1, 2] != 'O' && mass[0, 0] != 'X'))
                       {
                           mass[1, 2] = 'X';
                            userMove = true;
                       }
                       else if (userFieldIndex == 7 && (mass[2, 0] != 'O' && mass[0, 0] != 'X'))
                       {
                           mass[2, 0] = 'X';
                            userMove = true;
                        }
                       else if (userFieldIndex == 8 && (mass[2, 1] != 'O' && mass[0, 0] != 'X'))
                       {
                           mass[2, 1] = 'X';
                            userMove = true;
                        }
                       else if (userFieldIndex == 9 && (mass[2, 2] != 'O' && mass[0, 0] != 'X'))
                       {
                           mass[2, 2] = 'X';
                            userMove = true;
                        }
                       else
                       {
                           Console.WriteLine("this slot is not emty");
                            userMove = true;
                            machineMove =true;
                       }
                              

                    }

                    if (machineMove == false)
                    {
                        
                        while (machineMove != true)
                        {
                            int l = rnd.Next(0, 3);
                            int m = rnd.Next(0, 3);

                            if (mass[l, m] != 'X' && mass[l, m] != 'O')
                            {
                                mass[l, m] = 'O';
                                machineMove = true;
                            }

                        }

                    }

                  Console.WriteLine($"U choose {userFieldIndex}-slot");
                  Console.WriteLine("///////////////////////////////////////////////////////");
                  Console.WriteLine();

                  printfField(mass);
                    
                  Console.WriteLine("Choose slot");

               }
               else
               {
                   Console.WriteLine("enter value from 1 up to 9");
               }

            }
        }
                static void printfField(char[,] mass)
        {
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    
                    if (j == 2 && i == 0)
                    {
                        Console.Write($"|{mass[i, j]}|   ");
                        Console.WriteLine();
                        Console.WriteLine("________________");
                    }
                    else if (j == 2 && i == 1)
                    {
                        Console.Write($"|{mass[i, j]}|   ");
                        Console.WriteLine();
                        Console.WriteLine("________________");
                    }
                    else
                    {                        
                        Console.Write($"|{mass[i, j]}|   ");
                    }
                }
            }
        }
                static void massIndex(char [,] mass)
        {
            int b = 1;

            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    mass[i, j] = Convert.ToChar(Convert.ToString(b));
                    if (j == 2 && i == 0)
                    {
                        b++;
                        Console.Write($"|{mass[i, j]}|   ");
                        Console.WriteLine();
                        Console.WriteLine("__________________");
                    }
                    else if (j == 2 && i == 1)
                    {
                        b++;
                        Console.Write($"|{mass[i, j]}|   ");
                        Console.WriteLine();
                        Console.WriteLine("__________________");

                    }
                    else
                    {

                        b++;
                        Console.Write($"|{mass[i, j]}|   ");

                    }
                }
            }
        }
                static void GuessNumberGameTest()
                {
                    GuessNumberGame guessNumberGame = new GuessNumberGame(100, 5, GuessNumberGame.GuessingMode.Machine);
                    guessNumberGame.Start();
                }
                static void ComplexTest()
                {

                    //Complex c = new Complex();
                    Complex c1 = new Complex(1, 2);
                    Complex c2 = new Complex(1, 1);

                    Complex result = c1.Plus(c2);
                    Console.WriteLine($"Real part:{result.Cr}. Imaginary part:{result.Ci}");
                }
                static void StreamsDemo()
                {
                    var ms = new MyStack<int>();
                    ms.Push(1);
                    ms.Push(2);
                    ms.Push(3);
                    // проблема в том, что использование объектов не ограничивает тип принимаемых значений

                    //ms.Push('a');
                    /*эти типы теперь не компилируются(после замены object на обощённый джинерик)
                    ms.Push("abra");
                    ms.Push(false);
                    ms.Push(0.3);
                    ms.Push(new Character(Race.Elf));
                    */

                    foreach (var item in ms)
                    {
                        Console.WriteLine(item);
                    }
                    Console.ReadLine();

                    while (ms.Count != 0)
                    {
                        Console.WriteLine((int)ms.Peek());//Console.WriteLine((int)ms.Pop
                        ms.Pop();
                    }
                    Console.WriteLine(ms.Peek());

                    ms.Pop();

                    Console.WriteLine(ms.Peek());

                    ms.Push(3);
                    ms.Push(4);
                    ms.Push(5);

                    Console.WriteLine(ms.Peek());

                    Console.ReadLine();
                }
                static void ProblemOfRepresentatives()
                {
                    IShape rect = new Rect() { Height = 2, Width = 5 };
                    IShape square = new Square() { SideLength = 5 };
                    Console.WriteLine($"Rect area = {rect.CalcSquare()}");
                    Console.WriteLine($"Square area = {square.CalcSquare()}");

                    /*Rect rect = new Rect { Height = 2, Width = 5 };
                    int rectArea = AreaCalculator.CalcSquare(rect);
                    Console.WriteLine($"Rect area = {rectArea}");

                    Rect square = new Square { Height = 2, Width = 10 }; //При вызове квадарата мы можем указать ему
                    // разные значения длины и ширины, чего, естесвенно, не должно было быть
                    AreaCalculator.CalcSquare(square);
                    */
                    Console.ReadLine();
                }
                static void Interfaceses_and_Abstract_classes()
                {
                    List<object> list = new List<object>() { 1, 2, 3 };
                    IBaseCollection collection = new BaseList(4);
                    collection.AddRange(list);
                    collection.Add(1);

                    IBaseCollection2 collection2 = new BaseList2(3);
                    collection2.Add2(1);
                    //Shape shape = new Shape(); - нельзя создать экземпляр класса таким образом, так как он абстрактный 
                    Shape[] shapes = new Shape[2];
                    shapes[0] = new Triangle(10, 20, 30);
                    shapes[1] = new Reactangle(5, 10);
                    foreach (Shape shape in shapes)
                    {
                        shape.Draw();
                        Console.WriteLine(shape.Perimiter());
                    }
                }
                static void Inheritance_Наследование()
                {
                    ModelXTerminal terminal = new ModelXTerminal("123");
                    terminal.Connect();
                    Console.ReadLine();

                }
                static void BoxingUnboxing()
                {
                    //  Character C = new Character("Elf");
                    //     Console.WriteLine(C.Race);

                    static void Do(object obj2)
                    {
                        bool IsPointRef = obj2 is PointRef;
                        if (IsPointRef)
                        {
                            PointRef pr = (PointRef)obj2;
                            Console.WriteLine(pr.x);
                        }
                        else
                        {
                            //do smth
                        }
                        PointRef pr1 = obj2 as PointRef;
                        if (pr1 != null)
                        {
                            Console.WriteLine(pr1.x);
                        }
                        else
                        {
                            //do smth
                        }

                    }


                    //PointVal pv= null; -не получится. Не бывает нулевым при вызове. Чтобы присвоить null, нужно после структуры поставить знак вопроса
                    PointVal? pv = null;
                    if (pv.HasValue)
                    {
                        PointVal pv2 = pv.Value;
                        Console.WriteLine(pv.Value.x);
                        Console.WriteLine(pv2.x);
                    }
                    else
                    {
                        //
                    }
                    PointVal pv3 = pv.GetValueOrDefault();
                    //NullReferenceExeption
                    /* PointRef c = null;
                     Console.WriteLine(c.x);*/
                }
                static void PassByRef()
                {

                    int a = 2;
                    int b = 4;

                    Swap(ref a, b);
                    Console.WriteLine($"in main: a={a}, b={b}");
                }
                static void Swap(ref int a, int b)
                {
                    Console.WriteLine($"Original: a={a}, b={b}");

                    int z = b;
                    b = a;
                    a = z;
                    Console.WriteLine($"Swapped: a={a}, b={b}");
                }
                static void Numbers()
                {
                    var list = new List<int>();
                    AddNumbers(list);
                    foreach (var item in list)
                    {
                        Console.WriteLine(item);
                    }
                }
                static void AddNumbers(List<int> numbers)
                {
                    numbers.Add(1);
                    numbers.Add(2);
                    numbers.Add(3);
                }
                static void StackAndHeap()
                {
                    EvilStruct es1 = new EvilStruct();
                    es1.PointRef = new PointRef() { x = 1, y = 2 };//аналог инициализации приведённой ниже
                                                                   //es1.PointRef.x = 1;
                                                                   //es1.PointRef.y = 2;
                    EvilStruct es2 = es1;
                    Console.WriteLine($"es1.PointRef.x={ es1.PointRef.x},es1.PointRef.y={ es1.PointRef.y}");
                    Console.WriteLine($"es2.PointRef.x={ es2.PointRef.x},es2.PointRef.y={ es2.PointRef.y}");

                    es2.PointRef.x = 42;
                    es2.PointRef.y = 45;

                    Console.WriteLine($"es1.PointRef.x={ es1.PointRef.x},es1.PointRef.y={ es1.PointRef.y}");
                    Console.WriteLine($"es2.PointRef.x={ es2.PointRef.x},es2.PointRef.y={ es2.PointRef.y}");

                    Console.ReadLine();

                    PointVal a;
                    a.x = 3;
                    a.y = 5;

                    PointVal b = a;
                    b.x = 7;
                    b.y = 10;

                    a.LogValues();
                    b.LogValues();
                    Console.WriteLine("After structs");

                    PointRef c = new PointRef();
                    c.x = 3;
                    c.y = 5;

                    PointRef d = c;
                    d.x = 7;
                    d.y = 10;
                    c.LogValues();
                    d.LogValues();
                }

            
    }
}
