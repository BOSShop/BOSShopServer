using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace BOSShopServer
{
    public class WebServer
    {
        public HttpListener listener;

        public WebServer()
        {
            listener = new HttpListener();

            listener.Prefixes.Add("http://*:8889/");

            listener.Start();

            new Thread(ListenThread).Start();
        }

        private void ListenThread()
        {
            while (listener.IsListening)
            {
                HttpListenerContext context = listener.GetContext();

                Process(context);
            }
        }

        private void Process(HttpListenerContext context)
        {
            string url = context.Request.Url.AbsolutePath.Substring(1);

            if (url == "Update.zip")
            {
                byte[] data = File.ReadAllBytes(url);

                context.Response.ContentType = "application/zip";
                context.Response.ContentLength64 = data.LongLength;

                context.Response.OutputStream.Write(data);

                context.Response.StatusCode = (int)HttpStatusCode.OK;

                context.Response.OutputStream.Flush();

                context.Response.Close();
            }
        }
    }
}