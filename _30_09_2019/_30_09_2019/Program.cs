﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _30_09_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ipaddress = IPAddress.Parse("8.8.8.8");
            IPEndPoint iPEndPoint = new IPEndPoint(ipaddress, 80);

            try
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(iPEndPoint);

                socket.Listen(10);

                Console.WriteLine("Server is waiting for a response");
                while (true)
                {
                    Socket handler = socket.Accept();

                    string data = null;
                    while (true)
                    {
                        byte[] bytes = new byte[1024];
                        int countOfBytes = handler.Receive(bytes);
                        data += Encoding.UTF8.GetString(bytes, 0, countOfBytes);
                        if (data.IndexOf("<EndString>") > -1)
                        {
                            break;
                        }
                    }
                    string response = $"Hello, Semen. Your message've been received({data})";
                    handler.Send(Encoding.UTF8.GetBytes(response));

                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
