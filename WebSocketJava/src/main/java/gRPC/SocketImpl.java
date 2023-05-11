package gRPC;

import grpc.websocket.*;
import io.grpc.stub.StreamObserver;
import org.websocket.WebsocketClient;

import java.net.URI;
import java.net.http.HttpClient;
import java.util.concurrent.CompletableFuture;

public class SocketImpl extends ProtoServiceGrpc.ProtoServiceImplBase {

    private WebsocketClient client;



    public SocketImpl(){
        //this.client = new WebsocketClient("wss://iotnet.teracom.dk/app?token=vnoVQQAAABFpb3RuZXQudGVyYWNvbS5ka44TEFZ6iw5hEImHN64AWw0=");
        System.out.println("SocketImpl running");
    };


    @Override
    public void checkStatus(Update update, StreamObserver<UpdateResponse> responseStreamObserver){
        System.out.println("Status update");
        System.out.println(update.getOx());


        UpdateResponse response = UpdateResponse.newBuilder().setResponse("response").build();
        responseStreamObserver.onNext(response);
        responseStreamObserver.onCompleted();
    }

    @Override
    public void getConnection(Connection connection, StreamObserver<ConnectionResponse> responseStreamObserver){
        System.out.println("Connected");

        String url = connection.getUrl();
        WebsocketClient client = new WebsocketClient(url);
        client.sendDownLink("idk");


        ConnectionResponse response = ConnectionResponse.newBuilder().setResponse("Connected").build();
        responseStreamObserver.onNext(response);
        responseStreamObserver.onCompleted();
    }

    @Override
    public void setConfig(NewConfig config, StreamObserver<ConfigResponse> configResponseStreamObserver){
        System.out.println("New Config");
        System.out.println(config.getOx());

        ConfigResponse response = ConfigResponse.newBuilder().setResponse("good stuff").build();

        configResponseStreamObserver.onNext(response);
        configResponseStreamObserver.onCompleted();

    }
}
