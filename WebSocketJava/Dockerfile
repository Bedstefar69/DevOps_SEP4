FROM openjdk:19-jdk

EXPOSE 4242

VOLUME /backend_volume

COPY /out/*.jar websocket.jar

# set the startup command to execute the jar
ENTRYPOINT ["java", "-jar", "/websocket.jar"]