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
            IPAddress ip = IPAddress.Parse("");
            IPEndPoint ipe = new IPEndPoint(ip, 12000);
            Socket listner = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            int[] workload = new int[100];
            List<string> answers = new List<string>();
            int c =5;
            int dis = workload.Length / c;
            listner.Bind(ipe);
            listner.Listen(c);
            string data = "";
            Socket handler = null;
            int conn = 0;

            while(conn<c)
            {
                handler = listner.Accept();
		conn++;
                byte[] buffer = new byte[1024];

                int start = (conn -1) * dis;
                int end = (conn * dis) - 1;
                toclient(workload, start, end, handler);
                handler.Receive(buffer);

                data = Encoding.ASCII.GetString(buffer);

                answers.Add(data);

            }
            Socket handler2 = listner.Accept();
            byte[] buffer = new byte[1024];
            toclient(Array.ConvertAll(answers.ToArray(), item => (NewType)item), 0, 4, handler2);
            handler.Receive(buffer);

            data = Encoding.ASCII.GetString(buffer);

            
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }
        public static void toclient(int[] workload,int start,int end,Socket handler)
        {
            string data = "";

            for (int i = start; i <= end; i++)
            {
                data += workload[i].ToString() + ",";
            }
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            handler.Send(buffer);

        }
    }
}