using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyOwnThreads
{
    internal class Program
    {
        
      
       static int  numThreads;
       static  bool isFinished = false;
        bool _doneAlready = false;
        bool _firstisbad = false;
       static Random rnd = new Random(); 
        static void Main(string[] args)
        {
            var pr = new Program();
            pr.StartThreads();
        }
        private void StartThreads()
        {
            if (!_doneAlready)
            {
                Console.Write("Введите количество потоков: ");
                 numThreads = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                 
        _doneAlready = true;
            
            }
            for (var i = 0; i < numThreads; i++)
            {
                if (!_firstisbad)
                {
                    var newThread =
                        new Thread(new ThreadStart(ThreadProc))
                        {
                            Name = $"Поток {i + 1}",
                            Priority = ThreadPriority.Lowest
                        };
                    newThread.Start();
                    _firstisbad = true;
                }
                else
                {
                    var newThread =
                        new Thread(new ThreadStart(ThreadProc))
                        {
                            Name = $"Поток {i + 1}",
                          
                        };
                    newThread.Start();

                }


            }
            Thread.Sleep(5000);
            GoNextMaybe(numThreads);
        }

        private void GoNextMaybe(int num)
        {
            while (true)
            {
                Console.Write("Желаете продолжить? (Y/N)");
                var s = Console.ReadLine();
                if (s == "Y" || s == "y") StartThreads();
                if (s == "N" || s == "n")
                {
                    isFinished = true;
                    Console.WriteLine("Идет завершение всех потоков...");
                    for (var i = 0; i < num; i++)
                    {
                        var newThread =
                            new Thread(new ThreadStart(ThreadProc)) {Name = $"Поток {i + 1}"};
                        newThread.Start();
                    }

                    Thread.Sleep(5000);
                    Console.WriteLine("Работа всех потоков была завершена!");
                    Console.Read();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Неизвестный символ... " + s);
                    continue;
                }

                break;
            }
        }

        private static void ThreadProc()
        {
                UseResource();
        }
        private static void UseResource()
        {
           
            if (!isFinished)
            {
                var time = rnd.Next(1000, 5000);
                Thread.Sleep(time);
                Console.WriteLine("{0} выполнил  свою работу за {1}",
                Thread.CurrentThread.Name, time); 
            }
            else
            {            
                var time = rnd.Next(1000, 5000);
                Thread.Sleep(time);
                Console.WriteLine("{0} завершил  свою работу за {1}",
                    Thread.CurrentThread.Name, time);
            }
        }
        ~Program()
        {
           
        }

    }
}
