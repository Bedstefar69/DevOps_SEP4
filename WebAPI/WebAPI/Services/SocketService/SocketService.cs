using gRPCWebSocket;
using Microsoft.CodeAnalysis.Text;
using WebAPI.WebAPI.Data;
using WebAPI.WebAPI.Models;
using WebAPI.WebSocket.LogicImpl;

namespace WebAPI.WebAPI.Services.SocketService;

public static class SocketService
{
    

    public static async Task<ConfigResponse> setConfig(NewConfig config)
    {
        string SERVER_IP = "http://172.17.0.3:4242";
        WebSocketLogicImpl _webSocketLogicImpl = new WebSocketLogicImpl(SERVER_IP);
        var response = await _webSocketLogicImpl.setConfig(config);
        return response;
    }
    

    public static async Task<UpdateResponse> getUpdate()
    {
        string SERVER_IP = "http://172.17.0.3:4242";
        WebSocketLogicImpl _webSocketLogicImpl = new WebSocketLogicImpl(SERVER_IP);
        Console.WriteLine("Getting readings automatically");
            Console.WriteLine("Checking for a reading");
            var response = await _webSocketLogicImpl.getUpdate(new Update
            {
                Response = "getReadings"
            });
            Console.WriteLine(response.Temp + " | " + response.Humid + " | " + response.Ox);
            return response;
    }
    
}