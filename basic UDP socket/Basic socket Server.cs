using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

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

            Socket handler = new Socket(ip.AddressFamily, SocketType.Dgram, ProtocolType.Udp);

            handler.ExclusiveAddressUse = false;
            handler.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            byte[] buffer = new byte[1024];
            handler.Bind(ipe);

            EndPoint sender = (EndPoint)ipe;
            while (true)
            {
                string data = "";

                handler.ReceiveFrom(buffer, ref sender);

                data = Encoding.ASCII.GetString(buffer);
                Console.WriteLine(data);


            }
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();







        }
    }
}
