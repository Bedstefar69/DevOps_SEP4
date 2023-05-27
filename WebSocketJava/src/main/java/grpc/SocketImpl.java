package grpc;

import com.fasterxml.jackson.core.*;
import com.fasterxml.jackson.databind.ObjectMapper;
import grpc.websocket.*;
import io.grpc.stub.StreamObserver;
import org.websocket.WebsocketClient;
import DTO.UplinkMessage;

public class SocketImpl extends ProtoServiceGrpc.ProtoServiceImplBase {

    private WebsocketClient client = null;

    public SocketImpl() {
        System.out.println("SocketImpl running");
    }


    @Override
    public void checkStatus(grpc.websocket.Update request, StreamObserver<UpdateResponse> responseObserver) {
        UpdateResponse response;
        System.out.println("Checking for updates");
        if(client.updateReady) {
            DTO.Update tempUpdate = client.getUpdate();
            response = UpdateResponse.newBuilder()
                    .setTemp(tempUpdate.getTemp()).setOx(tempUpdate.getOx()).setHumid(tempUpdate.getHumid()).build();
        }
        else{
            response = UpdateResponse.newBuilder().setTemp(999.9).setHumid(999.9).setOx(999).build();
            }
           responseObserver.onNext(response);
           responseObserver.onCompleted();
        }


    @Override
    public void getConnection(Connection connection, StreamObserver<ConnectionResponse> responseStreamObserver) {
        System.out.println("Connection Request fra MAIN");

        ConnectionResponse response;
        String url = connection.getUrl();
        if (client == null) {
            client = new WebsocketClient(url);
            response = ConnectionResponse.newBuilder().setResponse("Connected").build();
            System.out.println("new client connected");
        }
        else{
            response = ConnectionResponse.newBuilder().setResponse("Already Connected").build();
            System.out.println("Client already connected");
        }
        responseStreamObserver.onNext(response);
        responseStreamObserver.onCompleted();
    }


    @Override
    public void setConfig(NewConfig config, StreamObserver<ConfigResponse> configResponseStreamObserver) {
        String responseText;
        System.out.println("New Config");
        String data = String.valueOf((int) config.getMaxHumid()) + (int) config.getMinHumid() + (int) config.getMaxTemp() + (int) config.getMinTemp() +config.getMaxOx() + config.getMinOx();
        System.out.println("Incoming data from front-end: " + data);
        UplinkMessage message = new UplinkMessage("tx","0004A30B00E7E7C1", 2, true, data);
        ObjectMapper mapper = new ObjectMapper();
        try {
            String messageToString = mapper.writeValueAsString(message);
            System.out.println(messageToString);
            client.sendDownLink(messageToString);
            responseText = "Message received and sent to IoT device";
        }
        catch (JsonProcessingException e){
            System.out.println("Json Error");
            responseText = "Error";
        }


        ConfigResponse response = ConfigResponse.newBuilder().setResponse(responseText).build();

        configResponseStreamObserver.onNext(response);
        configResponseStreamObserver.onCompleted();

    }


}