﻿using WebSocketSharp;
using WebSocketSharp.Server;

namespace WebSocket
{
    public class Echo : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine("Recieved Message: " + e.Data);
            Send(e.Data);
        }
    }

    public class EchoAll : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine("Recieved from all: " + e.Data);
            Sessions.Broadcast(e.Data);
        }
    }

    public class Server
    {

        public static void Main(string[] args)
        {
            WebSocketServer socketServer = new WebSocketServer("ws://127.0.0.1:4242");
            socketServer.AddWebSocketService<Echo>("/Echo");
            socketServer.AddWebSocketService<EchoAll>("/EchoAll");

            socketServer.Start();
            Console.WriteLine("Running");

            Console.ReadKey();
            socketServer.Stop();


        }
    }
}