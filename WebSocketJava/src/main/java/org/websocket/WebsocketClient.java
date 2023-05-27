package org.websocket;

import DTO.UplinkMessage;
import DTO.Update;
import com.fasterxml.jackson.core.JacksonException;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.json.JSONObject;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.WebSocket;
import java.nio.ByteBuffer;
import java.util.concurrent.CompletionStage;
import java.util.concurrent.CompletableFuture;

public class WebsocketClient implements WebSocket.Listener {
    private WebSocket server = null;
    private Update update;
    public boolean updateReady = false;

    public Update getUpdate() {
        updateReady = false;
        return update;
    }

    public void setUpdate(String data) {
        Update update = null;

        System.out.println("uplink data: " + data);
        double humid = hexstringToDouble(data.substring(1,5));
        double temp =  hexstringToDouble(data.substring(5, 9));
        int ox = 10 * (int) hexstringToDouble(data.substring(9, 13));
        System.out.println("temp: " + temp + " | ox: " + ox + " | humid: " + humid);
        update = new Update(temp, ox, humid);
        this.update = update;
        updateReady = true;
    }

    private double hexstringToDouble(String hex){
        System.out.println(hex);
        Long longHex = Long.parseLong(hex, 16);
        return longHex.doubleValue() / 10;
    }

    // Send down-link message to device
    // Must be in Json format according to https://github.com/ihavn/IoT_Semester_project/blob/master/LORA_NETWORK_SERVER.md
    public void sendDownLink(String jsonTelegram) {
        server.sendText(jsonTelegram,true);
    }

    // E.g. url: "wss://iotnet.teracom.dk/app?token=??????????????????????????????????????????????="
    // Substitute ????????????????? with the token you have been given
    public WebsocketClient(String url) {
        HttpClient client = HttpClient.newHttpClient();
        CompletableFuture<WebSocket> ws = client.newWebSocketBuilder()
                .buildAsync(URI.create(url), this);

        server = ws.join();
    }

    //onOpen()
    public void onOpen(WebSocket webSocket) {
        // This WebSocket will invoke onText, onBinary, onPing, onPong or onClose methods on the associated listener (i.e. receive methods) up to n more times
        webSocket.request(10);
        System.out.println("WebSocket Listener has been opened for requests.");
    }

    //onError()
    public void onError​(WebSocket webSocket, Throwable error) {
        System.out.println("A " + error.getCause() + " exception was thrown...");
        System.out.println("Message: " + error.getLocalizedMessage());
        webSocket.abort();
    };
    //onClose()
    public CompletionStage<?> onClose(WebSocket webSocket, int statusCode, String reason) {
        System.out.println("WebSocket closed!");
        System.out.println("Status:" + statusCode + " Reason: " + reason);
        return new CompletableFuture().completedFuture("onClose() completed.").thenAccept(System.out::println);
    };
    //onPing()
    public CompletionStage<?> onPing​(WebSocket webSocket, ByteBuffer message) {
        webSocket.request(1);
        System.out.println("Ping: Client ---> Server");
        System.out.println(message.asCharBuffer().toString());
        return new CompletableFuture().completedFuture("Ping completed.").thenAccept(System.out::println);
    };
    //onPong()
    public CompletionStage<?> onPong​(WebSocket webSocket, ByteBuffer message) {
        webSocket.request(1);
        System.out.println("Pong: Client ---> Server");
        System.out.println(message.asCharBuffer().toString());
        return new CompletableFuture().completedFuture("Pong completed.").thenAccept(System.out::println);
    };
    //onText()
    public CompletionStage<?> onText​(WebSocket webSocket, CharSequence data, boolean last) {
        String indented = (new JSONObject(data.toString())).toString(4);
        String dataJson = indented.substring(indented.indexOf('{') + 1);
        dataJson = dataJson.substring(0, dataJson.indexOf('}'));
        if(dataJson.contains("rx")) {
            String dataString = dataJson.substring(dataJson.indexOf("\"data\""));
            dataString = dataString.substring(dataString.indexOf(": "));
            dataString = dataString.substring(2, dataString.indexOf(","));
            setUpdate(dataString);
        }
        webSocket.request(99999);
        System.out.println(indented);
        return new CompletableFuture().completedFuture("onText() completed.").thenAccept(System.out::println);
    };

}