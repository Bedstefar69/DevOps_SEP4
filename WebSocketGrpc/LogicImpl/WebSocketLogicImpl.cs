using Grpc.Net.Client;
using gRPCWebSocket;
using SEP4_CLOUD_CS.LogicInterfaces;

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

    public Task<UpdateResponse> getUpdate(Update update)
    {
        throw new NotImplementedException();
    }
}