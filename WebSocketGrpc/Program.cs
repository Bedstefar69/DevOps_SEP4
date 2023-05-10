using Grpc.Net.Client;
using gRPCWebSocket;

namespace SEP4_CLOUD_CS;

public class Program
{

    public static void Main(String[] args)
    {
        using var channel = GrpcChannel.ForAddress("http://localhost:4242");
        var client = new ProtoService.ProtoServiceClient(channel);
        var reply = client.checkStatus(new Update
        {
            Humid = 420,
            Ox = 420,
            Temp = 420
        } );

        Console.WriteLine($"Response: {reply.Response}");
    }


}