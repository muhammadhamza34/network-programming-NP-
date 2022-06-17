using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("This is client");

            try
            {
                UdpClient handler = new UdpClient("127.0.0.1", 1200);
                while (true)
                {


                    byte[] data = Encoding.Unicode.GetBytes("hi");
                    handler.Send(data, data.Length);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }






        }
    }
}
