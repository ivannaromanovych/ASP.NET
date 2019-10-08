using HelloBelkaService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace _08_10_2019BelkaHost
{
    class Program
    {
        public static object TcpCannel { get; private set; }

        static void Main(string[] args)
        {
            HelloBelkaService.HelloBelkaContractService remotingService =
                new HelloBelkaService.HelloBelkaContractService();
            TcpChannel channel = new TcpChannel(1488);

            ChannelServices.RegisterChannel(channel);

            RemotingConfiguration.RegisterWellKnownServiceType( 
                typeof(HelloBelkaContractService), 
                "AddUser",
                WellKnownObjectMode.Singleton);
            Console.WriteLine("Host started!!");
            Console.ReadLine();
        }
    }
}
