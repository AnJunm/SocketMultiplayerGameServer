using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using SocketMultiplayerGameServer.Tool;
using SocketMultiplayerGameServer.DAO;
using SocketGameProtocol;


namespace SocketMultiplayerGameServer.Servers
{
    class Client
    {
        private Socket socket;
        private Message message;
        private UserData userData;

        private Server server;
        public UserData GetUserData
        {
            get { return userData; }
        }
        public Client(Socket socket,Server server)
        {
            this.server = server;
            this.socket = socket;
            message = new Message();
            userData = new UserData();

            StartReceive();
        }

        void StartReceive()
        {
            //socket.BeginReceive(message.Buffer,message.StartIndex,message.Remainningsize,SocketFlags.None,ReceiveCallback);
            socket.BeginReceive(message.Buffer, message.StartIndex, message.RemainningSize, SocketFlags.None,ReceiveCallback,null);
        }

        void ReceiveCallback(IAsyncResult iar)
        {
            try
            {
              
                if (socket == null || socket.Connected == false) return;
                int len = socket.EndReceive(iar);
                if (len == 0)
                {
                    return;
                }
                message.ReadBuffer(len,HandleRequest);
                StartReceive();
            }
            catch
            {

            }
        }

        public void Send(MainPack pack)
        {
            socket.Send(Message.PackData(pack));
        }


        void HandleRequest(MainPack pack)
        {
            server.HandleRequest(pack, this);
        }

        public bool Logon(MainPack pack)
        {
            return GetUserData.Logon(pack);
        }
    }
}
