using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using ChatContract;

namespace ChatServiceServer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(ChatServiceImpl)))
            {
                host.AddServiceEndpoint(typeof (IChatContractServer),
                                        new NetTcpBinding(SecurityMode.None),
                                        new Uri("net.tcp://localhost:8080"));
                host.Open();
                Console.WriteLine("Host is opened, press any key to end ...");
                Console.ReadKey();
            }
        }
    }
}
