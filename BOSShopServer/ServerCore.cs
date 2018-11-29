using Germanen.GUNet.Attributes;
using Germanen.GUNet.Attributes.Default;
using Germanen.GUNet.Authentication;
using Germanen.GUNet.Server;
using Germanen.GUNet.Settings.Server;
using Germanen.GUNet.Utils;
using System;
using System.Net;
using System.Threading;

namespace BOSShopServer
{
    public class ServerCore
    {
        public static GUNetServer Server { private set; get; }

        public static IAttributeManager AttributeManager { private set; get; }

        public static WebServer WebServer { private set; get; }

        static void Main(string[] args)
        {
            GUN.Init();

            AttributeManager = new AttributeManager();

            Server = new GUNetServer(new GUNServerSettings(AttributeManager, "1.0", IPAddress.Parse("127.0.0.1"), 8888, false, 12, 12, 0, true, new NullAuthenticator()));

            Server.StartServer();

            WebServer = new WebServer();

            AttributeManager.AddClass(new ClientCommunicator());

            new Thread(InputThread).Start();

            while (true)
            {
                Server.HandleNetworkingData();
                Console.Title = "Server - " + Server.Clients.Count;
                Thread.Sleep(1);
            }
        }

        static void InputThread()
        {
            string input = "";
            
            while(input != "exit")
            {
                input = Console.ReadLine();

                if(input == "update")
                {
                    foreach(int id in Server.Clients.Keys)
                    {
                        Server.SendTo(id, "SUpdate");
                    }
                }

                Thread.Sleep(1);
            }
        }
    }
}