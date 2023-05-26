using Grpc.Net.Client;
using gRPCWebSocket;
using WebAPI.WebAPI.Data;
using WebAPI.WebAPI.Services.ReadingService;
using WebAPI.WebSocket.LogicInterfaces;

namespace WebAPI.WebSocket.LogicImpl;

public class WebSocketLogicImpl : IWebSocketLogic

{
    private string url;


    public WebSocketLogicImpl(string url)
    {
        this.url = url;
    }
    
    public async Task<ConfigResponse> setConfig(NewConfig config)
    {
        var client = new ProtoService.ProtoServiceClient(GrpcChannel.ForAddress(url));
        var response = await client.setConfigAsync(config);
        
        return response;
    }

    public async Task<ConnectionResponse> getConnection()
    {
        using var channel = GrpcChannel.ForAddress(url);
        var client = new ProtoService.ProtoServiceClient(channel);
  
        var reply = client.getConnection(new Connection
            {
                Url = "wss://iotnet.teracom.dk/app?token=vnoVQQAAABFpb3RuZXQudGVyYWNvbS5ka44TEFZ6iw5hEImHN64AWw0="
            });
        return reply;
    }

    public async Task<UpdateResponse> getUpdate(Update update)
    {
        using var channel = GrpcChannel.ForAddress(url);
        var client = new ProtoService.ProtoServiceClient(channel);
        return client.checkStatus(update);
    }
}