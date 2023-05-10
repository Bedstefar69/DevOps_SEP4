package gRPC;

import grpc.websocket.ProtoServiceGrpc;
import grpc.websocket.Update;
import grpc.websocket.UpdateResponse;
import io.grpc.stub.StreamObserver;
import org.websocket.WebsocketClient;

public class SocketImpl extends ProtoServiceGrpc.ProtoServiceImplBase {

    private WebsocketClient client;



    public SocketImpl(){
        //this.client = new WebsocketClient("wss://iotnet.teracom.dk/app?token=vnoVQQAAABFpb3RuZXQudGVyYWNvbS5ka44TEFZ6iw5hEImHN64AWw0=");
        System.out.println("SocketImpl running");
    };


    @Override
    public void checkStatus(Update update, StreamObserver<UpdateResponse> responseStreamObserver){
        System.out.println("we got a hit");
        System.out.println(update.getOx());


        UpdateResponse response = UpdateResponse.newBuilder().setResponse("response").build();
        responseStreamObserver.onNext(response);
        responseStreamObserver.onCompleted();
    }

}
