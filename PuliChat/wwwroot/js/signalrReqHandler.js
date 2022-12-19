var connection = new signalR.HubConnectionBuilder()
    .withUrl('/Home/Index')
    .build();

connection.on('receiveMessage', addMessageToChat);

connection.start()
    .then(function () {
        console.log("Connected to SignalR hub");

        // Join a group named by the server name when the user joins a given server
        connection.invoke("JoinServer", serverName)
            .then(function () {
                console.log("Successfully joined group: " + serverName);
            })
            .catch(function (error) {
                console.error("Error joining group: " + error);
            });
    })
    .catch(function (error) {
        console.error("Error connecting to SignalR hub: " + error);
    });

function sendMessageToHub(message) {
    connection.invoke('sendMessage', message, serverName);
}