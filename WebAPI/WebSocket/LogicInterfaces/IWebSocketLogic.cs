using gRPCWebSocket;

namespace WebAPI.WebSocket.LogicInterfaces;

public interface IWebSocketLogic
{
    Task<ConfigResponse> setConfig(NewConfig config);
    Task<ConnectionResponse> getConnection(Connection connection);
    Task<UpdateResponse> getUpdate(Update update);

}