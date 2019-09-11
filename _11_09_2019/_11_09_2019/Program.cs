using _11_09_2019.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _11_09_2019
{
    class Program
    {
        //static int money = 0;
        static EFContext context = new EFContext();
        static List<User> users = context.Users.ToList();

        static void Main(string[] args)
        {
            /*Thread thread = new Thread(new ThreadStart(Add));
            Thread thread2 = new Thread(new ThreadStart(Add));
            Thread thread3 = new Thread(new ThreadStart(Add));

            thread.Start();
            thread2.Start();
            thread3.Start();

            thread.Join();//wait till thread work to the end
            thread2.Join();
            thread3.Join();
            Console.WriteLine(money);*/

            /*List<Action> actions = new List<Action>();
            for (int i = 0; i < 100; i++) 
            {
                actions.Add(new Action(Worker));
            }

            List<IAsyncResult> results = new List<IAsyncResult>();
            for (int i = 0; i < 100; i++)
            {
                //Started operation asynchronally
                results.Add(actions[i].BeginInvoke(null, null));
            }
            Console.WriteLine("Main continue working");
            for (int i = 0; i < 100; i++)
            {
                //is wating for operation is ended
                actions[i].EndInvoke(results[i]);
            }
            Console.WriteLine("Main ended operation");*/
            List<Action> actions = new List<Action>();
            List<IAsyncResult> results = new List<IAsyncResult>();
            for (int i = 0; i < 3; i++)
            {
                actions.Add(new Action(Send));
            }
            for (int i = 0; i < 3; i++)
            {
                results.Add(actions[i].BeginInvoke(null, null));
            }
            for (int i = 0; i < 3; i++)
            {
                actions[i].EndInvoke(results[i]);
            }
        }
        static void Send()
        {

            foreach (User user in users) 
            {
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("wladiktest420@gmail.com", "Qwertyu-1"),
                    EnableSsl = true
                };
                client.Send("wladiktest420@gmail.com",
                user.Email,
                "Greeting",
                $"Hi, {user.Name}, it's wladiktest420@gmail.com");
                Console.WriteLine($"sended {user.Name} {user.Id}");
            }
        }
        /*static void Add()
        {
            for (int i = 0; i < 1_000_000; i++)
            {
                //money++; is unsafe
                Interlocked.Increment(ref money);
            }
        }*/
        /*static void Worker()
        {
            Console.WriteLine("I'm working asynchronally");
            Console.WriteLine("Thread Id: " + Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"I already made {i + 1}. operation");
                Thread.Sleep(100);
            }
            Console.WriteLine("I ended my work!");
        }*/
    }
}
