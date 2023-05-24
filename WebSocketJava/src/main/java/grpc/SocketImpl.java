package grpc;

import com.fasterxml.jackson.core.*;
import com.fasterxml.jackson.databind.ObjectMapper;
import grpc.websocket.*;
import io.grpc.stub.StreamObserver;
import org.websocket.WebsocketClient;
import DTO.UplinkMessage;

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
        ConnectionResponse response = ConnectionResponse.newBuilder().setResponse("Connected").build();
        responseStreamObserver.onNext(response);
        responseStreamObserver.onCompleted();
    }


    @Override
    public void setConfig(NewConfig config, StreamObserver<ConfigResponse> configResponseStreamObserver) {
        System.out.println("New Config");
        String data = String.valueOf((int) config.getMaxHumid()) + (int) config.getMinHumid() + (int) config.getMaxTemp() + (int) config.getMinTemp() +config.getMaxOx() + config.getMinOx();
        System.out.println(data);

        UplinkMessage message = new UplinkMessage("tx","0004A30B00E7E7C1", 2, true, data);
        ObjectMapper mapper = new ObjectMapper();
        try {
            String messageToString = mapper.writeValueAsString(message);
            System.out.println(messageToString);
            client.sendDownLink(messageToString);
        }
        catch (JsonProcessingException e){
            System.out.println("oops");
        }


        ConfigResponse response = ConfigResponse.newBuilder().setResponse("good stuff").build();

        configResponseStreamObserver.onNext(response);
        configResponseStreamObserver.onCompleted();

    }


}