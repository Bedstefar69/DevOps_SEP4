using gRPCWebSocket;

namespace WebAPI.WebAPI.Services.SocketService;

public interface ISocketService
{
   public Task<ConfigResponse> setConfig(NewConfig config);
   
   public Task<UpdateResponse> getUpdate(Update update);
   
   public Task<ConnectionResponse> getConnection();
}