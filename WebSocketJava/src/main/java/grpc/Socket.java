package grpc;
import io.grpc.Server;
import io.grpc.ServerBuilder;
import java.io.IOException;
import java.util.concurrent.ExecutionException;

public class Socket {


    public static void main(String[] args) throws IOException, InterruptedException, ExecutionException {

        Server server = ServerBuilder.forPort(4242).addService(new SocketImpl()).build();
        server.start();
        server.awaitTermination();

    }
}
