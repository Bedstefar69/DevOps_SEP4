using Grpc.Net.Client;
using gRPCWebSocket;
using SEP4_CLOUD_CS.LogicInterfaces;
using WebAPI.Data;
using WebAPI.Services.ReadingService;
using WebAPI.Services.UserService;

namespace SEP4_CLOUD_CS.LogicImpl;

public class WebSocketLogicImpl : WebSocketLogic

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