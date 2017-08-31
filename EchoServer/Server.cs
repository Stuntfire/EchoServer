using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EchoServer
{
    public class Server
    {
        public Server()
        {

        }

        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 7);

            server.Start();

            using (TcpClient client = server.AcceptTcpClient())

            using (NetworkStream ns = client.GetStream())

            using (StreamReader sr = new StreamReader(ns))

            using (StreamWriter sw = new StreamWriter(ns))
            {
                DoClient(sr, sw);
            }
        }

        private static void DoClient(StreamReader sr, StreamWriter sw)
        {
            String inline = sr.ReadLine();

            int countWords = inline.Split(' ').Length;

            Console.WriteLine("Server modtaget: " + inline + " fra Client." + countWords + " ord sendt fra server til Client");

            sw.WriteLine(inline);
            sw.Flush();
        }
    }
}
