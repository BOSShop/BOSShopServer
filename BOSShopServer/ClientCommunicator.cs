using Germanen.GUNet.Attributes;
using Germanen.GUNet.Attributes.Server;
using Germanen.GUNet.Utils.Server;
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

        [OnPackage("CUpdateStarted")]
        public void OnUpdateStarted(PackageFromClientData data)
        {
            Console.WriteLine("Update started");
        }

        [OnPackage("CUpdateFinished")]
        public void OnUpdateFinished(PackageFromClientData data)
        {
            Console.WriteLine("Update finished");
        }

        [OnClientDisconnect]
        public void OnClientDisconnected(int id)
        {
            Console.WriteLine("Client with id " + id + " disconnected");
        }
    }
}