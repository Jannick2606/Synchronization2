using System;
using System.Threading;

namespace Synchronization2
{
    class Program
    {
        static readonly object lock1 = new object();
        static int num = 0;
        static void Main(string[] args)
        {
            Thread t1 = new Thread(PrintStars);
            Thread t2 = new Thread(PrintHashtags);
            t1.Start();
            t2.Start();
        }
        static void PrintStars()
        {
            while (true)
            {
                Monitor.Enter(lock1);
                try
                {
                    for (int i = 0; i < 60; i++)
                    {
                        Console.Write("*");
                        num++;
                    }
                    Console.WriteLine($" {num}");
                    Thread.Sleep(300);
                }
                finally
                {
                    Monitor.Exit(lock1);
                }
            }
        }
        static void PrintHashtags()
        {
            while (true)
            {
                Monitor.Enter(lock1);
                try
                {
                    for (int i = 0; i < 60; i++)
                    {
                        Console.Write("#");
                        num++;
                    }
                    Console.WriteLine($" {num}");
                    Thread.Sleep(300);
                }
                finally
                {
                    Monitor.Exit(lock1);
                }
            }
        }
    }
}
