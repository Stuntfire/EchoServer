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
            TcpListener server = new TcpListener(IPAddress.Loopback, 7); //modtager alt info på port 7.

            server.Start();

            using (TcpClient client = server.AcceptTcpClient()) //Venter på klienter...

            DoClient(client);
        }

        private static void DoClient(TcpClient client)
        {
            using (NetworkStream ns = client.GetStream())

            using (StreamReader sr = new StreamReader(ns))

            using (StreamWriter sw = new StreamWriter(ns))
            {
                String inline = sr.ReadLine();  //Læser den nuværende streng af bogstaver og returnerer data som en string

                int countWords = inline.Split(' ').Length;

                Console.WriteLine("Server modtaget: " + inline + " fra Client. " + countWords + " ord sendt fra server til Client");

                sw.WriteLine(inline);
                sw.Flush(); //Clears the buffer
            }
            
        }
    }
}
