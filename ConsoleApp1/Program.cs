using WebSocketSharp;

namespace WebSocket
{

   public class Client
    {
        public static void Main()
        {
            using (WebSocketSharp.WebSocket webSocket = new WebSocketSharp.WebSocket("ws://127.0.0.1:4242/Echo"))
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
