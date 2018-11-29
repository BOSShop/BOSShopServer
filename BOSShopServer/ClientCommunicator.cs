using Germanen.GUNet.Attributes.Server;
using System;
using System.Collections.Generic;
using System.Text;

namespace BOSShopServer
{
    public class ClientCommunicator
    {
        [OnClientConnect]
        public void OnClientConnected(int id)
        {
            Console.WriteLine("Client with id " + id + " connected");
        }

        [OnClientDisconnect]
        public void OnClientDisconnected(int id)
        {
            Console.WriteLine("Client with id " + id + " disconnected");
        }
    }
}