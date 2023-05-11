FROM openjdk:19-jdk

VOLUME /backend_volume

COPY /out/*.jar websocket.jar

# set the startup command to execute the jar
ENTRYPOINT ["java", "-jar", "/websocket.jar"]