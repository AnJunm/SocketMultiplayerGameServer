using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using SocketGameProtocol;
using SocketMultiplayerGameServer.Servers;

namespace SocketMultiplayerGameServer.Controller
{
    class UserController:BaseController
    {
        public UserController()
        {
            requestCode = RequestCode.User;

        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public MainPack Logon(Server server,Client client,MainPack pack)
        {
            if(client.Logon(pack))
            {
                pack.Returncode = ReturnCode.Succeed;

            }
            else
            {
                pack.Returncode = ReturnCode.Fail;
            }
            return pack;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        //public MainPack Login(Server server, Client client, MainPack pack)
        //{

        //}

        
    }
}
