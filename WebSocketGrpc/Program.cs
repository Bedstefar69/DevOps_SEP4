using Grpc.Net.Client;
using gRPCWebSocket;
using SEP4_CLOUD_CS.LogicImpl;

namespace SEP4_CLOUD_CS;

public class Program
{

    public static void Main(String[] args)
    {
        using var channel = GrpcChannel.ForAddress("http://172.17.0.2:4242");
        //172.17.0.2 -> Docker
        //70.34.253.20 -> localhost
        var client = new ProtoService.ProtoServiceClient(channel);
  
        var reply = client.getConnection(new Connection
        {
            Url = "wss://iotnet.teracom.dk/app?token=vnoVQQAAABFpb3RuZXQudGVyYWNvbS5ka44TEFZ6iw5hEImHN64AWw0="
        });
  
        Console.WriteLine($"Response: {reply.Response}");
  

        WebSocketLogicImpl webSocketLogicImpl = new WebSocketLogicImpl("http://172.17.0.2:4242");
        Console.WriteLine("HEY IT WORKS");

    }
}