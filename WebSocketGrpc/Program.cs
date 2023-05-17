using Grpc.Net.Client;
using gRPCWebSocket;
using SEP4_CLOUD_CS.LogicImpl;

namespace SEP4_CLOUD_CS;

public class Program
{

    public static void Main(String[] args)
    {
        using var channel = GrpcChannel.ForAddress("http://70.34.254.24:4242");
          var client = new ProtoService.ProtoServiceClient(channel);
  
          var reply = client.getConnection(new Connection
          {
              Ip = "",
              Url = "wss://iotnet.teracom.dk/app?token=vnoVQQAAABFpb3RuZXQudGVyYWNvbS5ka44TEFZ6iw5hEImHN64AWw0="
          });
  
          Console.WriteLine($"Response: {reply.Response}");
  

        WebSocketLogicImpl webSocketLogicImpl = new WebSocketLogicImpl("http://70.34.254.24:4242");
        Console.WriteLine("HEY IT WORKS");

    }
}