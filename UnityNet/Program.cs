using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using SocketMultiplayerGameServer.Servers;

//namespace SocketMultiplayerGameServer
//{
//    class program
//    {
//        private static Socket socket;

//        private static byte[] buffer = new byte[1024];
//        static void Main(string[] args)
//        {
//            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//            socket.Bind(new IPEndPoint(IPAddress.Any, 6666));
//            socket.Listen(0);
//            StartAccept();
//            Console.Read();
//        }
//        static void StartAccept()
//        {
//            socket.BeginAccept(AcceptCallback, null);
//        }
//        static void StartReceive(Socket client)
//        {
//            client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallback, client);
//        }
//        static void ReceiveCallback(IAsyncResult iar)
//        {
//            Socket client = iar.AsyncState as Socket;

//            int len = client.EndReceive(iar);
//            if (len == 0)
//            {
//                return;

//            }
//            string str = Encoding.UTF8.GetString(buffer, 0, len);
//            Console.WriteLine(str);
//            StartReceive(client);
//        }
//        static void AcceptCallback(IAsyncResult iar)
//        {
//            Socket client = socket.EndAccept(iar);
//            StartReceive(client);
//            StartAccept();
//        }
//    }

//}


namespace SocketMultiplayerGameServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server(6666);
            Console.Read();
        }
    }
}