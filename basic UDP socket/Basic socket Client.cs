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

            Console.WriteLine("This is client");

            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ip = host.AddressList[0];
            IPEndPoint ipe = new IPEndPoint(ip, 12000);

            Socket handler = new Socket(ip.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
            handler.ExclusiveAddressUse = false;
            handler.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            byte[] buffer = new byte[1024];
            handler.Bind(ipe);

            EndPoint sender = (EndPoint)ipe;
            while (true)
            {
                string data = "hi";
                buffer = Encoding.ASCII.GetBytes(data);
                handler.SendTo(buffer, sender);
            }


            handler.Shutdown(SocketShutdown.Both);
            handler.Close();







        }
    }
}
