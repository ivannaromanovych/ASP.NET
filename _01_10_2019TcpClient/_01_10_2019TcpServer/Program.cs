using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _01_10_2019TcpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress iPAddress = IPAddress.Parse("127.0.0.57");
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 1098);
            TcpListener tcpListener = new TcpListener(iPEndPoint);
            tcpListener.Start();

            while(true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                using (NetworkStream stream = client.GetStream())
                {
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        Console.WriteLine(reader.ReadString());
                        using (BinaryWriter writer = new BinaryWriter(stream))
                        {
                            writer.Write("Cossack is dead");
                        }
                    }
                }
            }
        }
    }
}
