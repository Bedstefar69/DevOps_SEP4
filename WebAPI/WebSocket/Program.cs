using Grpc.Net.Client;
using gRPCWebSocket;

namespace WebAPI.WebSocket;

public class Program
{

    public static void Main(String[] args)
    {
        using var channel = GrpcChannel.ForAddress("http://140.82.33.21:4242");
        //172.17.0.2 -> Docker
        //70.34.253.20 -> 140.82.33.21
        var client = new ProtoService.ProtoServiceClient(channel);
  
        var reply = client.getConnection(new Connection
        {
            Url = "wss://iotnet.teracom.dk/app?token=vnoVQQAAABFpb3RuZXQudGVyYWNvbS5ka44TEFZ6iw5hEImHN64AWw0="
        });
  
        Console.WriteLine($"Response: {reply.Response}");
  

        //WebSocketLogicImpl webSocketLogicImpl = new WebSocketLogicImpl("http://172.17.0.6:4242");
        Console.WriteLine("HEY IT WORKS");

        var reply2 = client.setConfig(new NewConfig
        {
            MaxHumid = 12,
            MinHumid = 34,
            MaxTemp = 56,
            MinTemp = 78,
            MaxOx = 90,
            MinOx = 12
        });
        Console.WriteLine($"Response from config: {reply2}");

    }
}