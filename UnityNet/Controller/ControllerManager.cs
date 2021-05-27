using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using SocketGameProtocol;
using System.Reflection;
using SocketMultiplayerGameServer.Servers;

namespace SocketMultiplayerGameServer.Controller
{
    class ControllerManager
    {
        private Dictionary<RequestCode, BaseController> controlDict = new Dictionary<RequestCode, BaseController>();
        private Server server;
        public ControllerManager(Server server)
        {
            UserController userController = new UserController();
            controlDict.Add(userController.GetRequestCode, userController);

        }

        public void HandleRequest(MainPack pack,Client client)
        {
           

            if(controlDict.TryGetValue(pack.Requestcode, out BaseController controller))
            {
                string methodname = pack.Actioncode.ToString();
                MethodInfo method = controller.GetType().GetMethod(methodname);
                if(method==null)
                {
                    Console.WriteLine("没有找到指定的事件处理" + pack.Actioncode.ToString());
                    return;
                }

                object[] obj = new object[] { server, client, pack };
                object ret = method.Invoke(controller,obj); 
                if(ret!=null)
                {
                    client.Send(ret as MainPack);
                }
            }
            else
            {
                Console.WriteLine("没有找到对应的Controler处理");
            }
        }
    }
}
