package org.websocket.models;

public class LoRaWANMessage {
    public String cmd;
    public String EUI;
    public int port;
    public boolean ack;
    public String data;

    public LoRaWANMessage(String cmd, String EUI, int port, boolean ack, String data) {
        this.cmd = cmd;
        this.EUI = EUI;
        this.port = port;
        this.ack = ack;
        this.data = data;
    }

    public String getData() {
        return data;
    }

    public void setData(String data) {
        this.data = data;
    }

    public String getCmd() {
        return cmd;
    }

    public void setCmd(String cmd) {
        this.cmd = cmd;
    }

    public String getEUI() {
        return EUI;
    }

    public void setEUI(String EUI) {
        this.EUI = EUI;
    }

    public int getPort() {
        return port;
    }

    public void setPort(int port) {
        this.port = port;
    }

    public boolean isAck() {
        return ack;
    }

    public void setAck(boolean ack) {
        this.ack = ack;
    }
}
