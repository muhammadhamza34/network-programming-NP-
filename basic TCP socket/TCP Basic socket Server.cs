using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("This is server");

            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ip = host.AddressList[0];
            IPEndPoint ipe = new IPEndPoint(ip, 12000);

            Socket listner = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);


            listner.Bind(ipe);

            listner.Listen(10);

            Socket handler = listner.Accept();

            byte[] buffer = new byte[1024];

            string data = "";

            handler.Receive(buffer);

            data = Encoding.ASCII.GetString(buffer);

            Console.WriteLine(data);


            data = "Hi from server";

            buffer = Encoding.ASCII.GetBytes(data);
            handler.Send(buffer);

            handler.Shutdown(SocketShutdown.Both);
            handler.Close();






            
        }
    }
}
