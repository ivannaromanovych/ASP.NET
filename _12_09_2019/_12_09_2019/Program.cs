using System;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace _12_09_2019
{

    class Program
    {
        static void Work(int time)
        {
            Console.WriteLine("Work time {0} threadId {1}", time, Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(time);
            Action action = new Action(() => Work(2000));
            Task task = new Task(action);

            task.Start();

            Console.WriteLine("Inserted Task is working");

            task.Wait();

            Console.WriteLine("End time {0} threadId {1}", time, Thread.CurrentThread.ManagedThreadId);

        }
        static void Main(string[] args)
        {
            Action action = new Action(() => Work(2000));
            Task task = new Task(action);

            task.Start();
            Console.WriteLine("Main is working");

            //wationg for operation is ended in other thread
            task.Wait();

            Console.WriteLine("Main is ended!");
        }
    }
}
