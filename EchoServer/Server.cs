using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EchoServer
{
    class Server
    {
        public void Start()
        {
            TcpListener myTpcListener = new TcpListener(IPAddress.Loopback, 7);

            myTpcListener.Start();
        }
    }
}
