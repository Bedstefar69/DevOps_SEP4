using gRPCWebSocket;

namespace SEP4_CLOUD_CS.LogicInterfaces;

public interface WebSocketLogic
{
    Task<ConfigResponse> setConfig(NewConfig config);
    Task<ConnectionResponse> getConnection(Connection connection);
    Task<UpdateResponse> getUpdate(Update update);

}