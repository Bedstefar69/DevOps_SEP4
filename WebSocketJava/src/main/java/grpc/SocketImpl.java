package grpc;

import grpc.websocket.*;
import io.grpc.stub.StreamObserver;
import org.websocket.WebsocketClient;

public class SocketImpl extends ProtoServiceGrpc.ProtoServiceImplBase {

    private WebsocketClient client;
    private DTO.Update update;


    public SocketImpl() {
        System.out.println("SocketImpl running");
    }


    @Override
    public void checkStatus(grpc.websocket.Update request, StreamObserver<UpdateResponse> responseObserver) {
        System.out.println("Checking for updates");
        if(client.updateReady){
           DTO.Update tempUpdate = client.getUpdate();
           UpdateResponse response = UpdateResponse.newBuilder()
               .setTemp(tempUpdate.getTemp()).setOx(tempUpdate.getOx()).setHumid(tempUpdate.getHumid()).build();

           responseObserver.onNext(response);
           responseObserver.onCompleted();
        }


    }

    @Override
    public void getConnection(Connection connection, StreamObserver<ConnectionResponse> responseStreamObserver) {
        System.out.println("Connected");

        String url = connection.getUrl();
        client = new WebsocketClient(url);
        client.sendDownLink("idk");


        ConnectionResponse response = ConnectionResponse.newBuilder().setResponse("Connected").build();
        responseStreamObserver.onNext(response);
        responseStreamObserver.onCompleted();
    }


    @Override
    public void setConfig(NewConfig config, StreamObserver<ConfigResponse> configResponseStreamObserver) {
        System.out.println("New Config");
        System.out.println(config.getOx());

        ConfigResponse response = ConfigResponse.newBuilder().setResponse("good stuff").build();

        configResponseStreamObserver.onNext(response);
        configResponseStreamObserver.onCompleted();

    }


}