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

    public Task<ConnectionResponse> getConnection(Connection connection)
    {
        throw new NotImplementedException();
    }

    public async Task<UpdateResponse> getUpdate(Update update)
    {
        var timer = new PeriodicTimer(TimeSpan.FromSeconds(10));

        while (await timer.WaitForNextTickAsync())
        {
            //
        }
        
        ReadingService readingService = new ReadingService(new DataContext(null)); 
        throw new NotImplementedException();
    }
}