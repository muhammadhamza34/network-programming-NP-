using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is client");

            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ip = host.AddressList[0];
            IPEndPoint remote = new IPEndPoint(ip, 12000);

            Socket sender = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            sender.Connect(remote);

            byte[] buffer = new byte[1024];
            string data = "Hi I am client";

            buffer = Encoding.ASCII.GetBytes(data);

            sender.Send(buffer);

            sender.Receive(buffer);

            data = Encoding.ASCII.GetString(buffer);

            Console.WriteLine(data);

            sender.Shutdown(SocketShutdown.Both);

            sender.Close();
        }
    }
}
