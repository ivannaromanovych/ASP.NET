using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _10_09_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart threadStart = GoldMining;
            mitka: Console.Write("Enter count of units: ");
            int count;
            if (!int.TryParse(Console.ReadLine(), out count))
                goto mitka;
            List<Thread> threads = new List<Thread>(count);
            units = new List<Miner>(count);
            for (int i = 0; i < count; i++)
            {
                threads.Add(new Thread(threadStart));
                threads[i].Start();
                Console.WriteLine($"Started miner no {i}");
                for (int j = 0; j < 10; j++)
                {
                    Thread.Sleep(100);
                }
            }

            for (int i = 0; i < units.Count; i++) 
                Console.WriteLine($"{i} - {units[i].Coins}");
            Console.ReadKey();
        }
        public static List<Miner> units;
        static void GoldMining()
        {
            Random rand = new Random();
            units.Add(new Miner());
            Thread.Sleep(100);
            units.Last().Coins += rand.Next(5, 20);
            Console.WriteLine($"\t\t\t Hello from miner!");
        }
    }
}
/*        static void Main(string[] args)
        {
            ThreadStart threadStart = ThreadFunc;
            Thread thread = new Thread(threadStart);
            thread.Start();
            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"{i} Hello from main!");
            }
        }
        static void ThreadFunc()
        {
            Console.WriteLine("Thread started work");
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine($"\t\t\t Hello from thread!");
            }
        }
*/