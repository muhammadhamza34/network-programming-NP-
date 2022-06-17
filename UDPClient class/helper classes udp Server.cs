using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("This is server");

            try
            {
                IPEndPoint ip = new IPEndPoint(IPAddress.Any, 1200);
                UdpClient server = new UdpClient(ip);
               
                Console.WriteLine("[UDP] [Listenning]");
                while (true)
                {
                    byte[] data = server.Receive(ref ip);
                    string ch = Encoding.Unicode.GetString(data, 0, data.Length);
                   
                    Console.WriteLine(ch + " " + DateTime.Now.ToString());
                }


            }
            catch
            {
                Console.WriteLine("Warrning:connection failed");
                Console.ReadKey();
            }




        }
    }
}
