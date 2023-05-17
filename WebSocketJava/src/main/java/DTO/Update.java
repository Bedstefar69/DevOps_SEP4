package DTO;

public class Update {
        private double temp;
        private int ox;
        private double humid;

    public Update(double temp, int ox, double humid) {
        this.temp = temp;
        this.ox = ox;
        this.humid = humid;
    }

    public double getTemp() {
            return temp;
        }

        public void setTemp(double temp) {
            this.temp = temp;
        }

        public int getOx() {
            return ox;
        }

        public void setOx(int ox) {
            this.ox = ox;
        }

        public double getHumid() {
            return humid;
        }

        public void setHumid(double humid) {
            this.humid = humid;
        }
}
