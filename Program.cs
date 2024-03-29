using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Stack_Queue_Консоль
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> spisok_b = new Queue<string>();
            Queue<string> spisok_g = new Queue<string>();
            Stack<int> spisok_10 = new Stack<int>();

            StreamReader sr = new StreamReader("person.txt");

            Console.WriteLine("Задание №1 (queue 6)");

            Console.Write("Введите название файла(person): ");
            string name1 = Console.ReadLine();
            if (File.Exists(name1 + ".txt"))
            {
                while (!sr.EndOfStream)
                {
                    string[] str = sr.ReadLine().Split(' ');
                    if (str[3].StartsWith("ж"))
                        spisok_g.Enqueue($"{str[0]} {str[1]} {str[2]} " +
                                          $"{str[3]} {str[4]} {str[5]} ");
                    if (str[3].StartsWith("м"))
                        spisok_b.Enqueue($"{str[0]} {str[1]} {str[2]} " +
                                          $"{str[3]} {str[4]} {str[5]} ");
                }
                sr.Close();
            }
            else Console.WriteLine("Файл не найден");

            while (spisok_b.Count != 0)  
            {
                Console.WriteLine(spisok_b.Dequeue());
            }

            Console.WriteLine();

            while (spisok_g.Count != 0)
            {
                    Console.WriteLine(spisok_g.Dequeue());
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения");
            Console.ReadLine();
            Console.WriteLine("Задание №2 (stack 9)");

            
            Console.Write("Введите название файла(formuls): ");
            string name = Console.ReadLine();
            int k = 0;
            if (File.Exists(name + ".txt"))
            {
                if (new FileInfo(name + ".txt").Length == 0)
                {
                    Console.WriteLine("Файл пуст");
                }
                else
                {
                    string[] formuls = File.ReadAllLines(name + ".txt");
                    for (int j = 0; j < formuls.Length; j++)
                    {
                        Console.WriteLine(formuls[j]);
                        for (int i = 0; i < formuls[j].Length; i++)
                        {
                            Random random = new Random();
                            char c = formuls[j][i];
                            int number = Convert.ToInt32(formuls[j][0].ToString());
                            if (char.IsDigit(c))
                            {
                                spisok_10.Push(Convert.ToInt32(c.ToString()));
                            }
                            else if (c == 'm')
                            {
                                int a = random.Next(0, number);
                                int b = random.Next(0, number);
                                int answer = (a - b) % 10;
                                spisok_10.Push(answer);
                            }
                            else if (c == 'p')
                            {
                                int a = random.Next(0, number);
                                int b = random.Next(0, number);
                                int answer = (a + b) % 10;
                                spisok_10.Push(answer);
                            }
                        }
                        Console.WriteLine(spisok_10.Pop());
                    }
                }
            }
            else
            {
                Console.WriteLine("Файл не найден");
            }
        }
    }
}
