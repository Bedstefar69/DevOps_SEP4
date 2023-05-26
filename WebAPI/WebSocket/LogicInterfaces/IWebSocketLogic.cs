using gRPCWebSocket;

namespace WebAPI.WebSocket.LogicInterfaces;

public interface IWebSocketLogic
{
    Task<ConfigResponse> setConfig(NewConfig config);
    Task<ConnectionResponse> getConnection();

    static Task<UpdateResponse> getUpdate(Update update)
    {
        return new Task<UpdateResponse>(null);
    }

}