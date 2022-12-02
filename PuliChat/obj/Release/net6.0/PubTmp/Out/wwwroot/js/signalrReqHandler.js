var connection = new signalR.HubConnectionBuilder()
    .withUrl('/Home/Index')
    .build();

connection.on('receiveMessage', addMessageToChat);

connection.start()
    .catch(error => {
        console.error(error.message);
    });

function sendMessageToHub(message, channelId, userRole, userImage) {
    connection.invoke('sendMessage', message, channelId, userRole, userImage);
}