using gRPCWebSocket;
using WebAPI.WebSocket.LogicImpl;

namespace WebAPI.WebAPI.Services.SocketService;

public class SocketService : ISocketService
{

    private readonly string SERVER_IP = "http://70.34.254.24:4242";

    private WebSocketLogicImpl _webSocketLogicImpl;

    public SocketService()
    {
        _webSocketLogicImpl = new WebSocketLogicImpl(SERVER_IP);
    }

    public async Task<ConfigResponse> setConfig(NewConfig config)
    {
        
        throw new NotImplementedException();
    }

    public async Task<UpdateResponse> getUpdate(Update update)
    {
        return await _webSocketLogicImpl.getUpdate(update);
    }

    public async Task<ConnectionResponse> getConnection()
    {
        throw new NotImplementedException();
    }
}