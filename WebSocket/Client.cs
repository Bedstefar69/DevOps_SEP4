using WebSocketSharp;

namespace WebSocket
{

   public class Client
    {
        public void init()
        {
            using (WebSocketSharp.WebSocket webSocket = new WebSocketSharp.WebSocket("ws://127.0.0.1:1337/Echo"))
            {
                webSocket.OnMessage += Socket_OnMessage;
                
                webSocket.Connect();
                webSocket.Send("Hi");

                Console.ReadKey();
            }
        }

        private static void Socket_OnMessage(object sender, MessageEventArgs e)
        {
            Console.WriteLine("Recieved: " + e.Data);
        }

    }

}