/* SIGNALR REAL-TIME CHAT */

let prevUser;
let textInput;
let chat;
let channel1;

function initialize(channel, prevUserT) {
    channel1 = channel;
    textInput = document.getElementById('text');
    chat = document.getElementById('ChannelContent');
    prevUser = prevUserT;
}

function clearInputField() {
    textInput.value = "";
}

function sendMessage(message) {
    if (message.length != 0) {
        sendMessageToHub(message);
    }
}

function addMessageToChat(message) {
    console.log("Received message");
    if (message[5] != channel1) return;

    let userName = message[0];
    let messageDate = message[1];
    let messageText = message[2];
    let userImage = message[3];
    let userRole = message[4];

    let container = document.createElement('div');
    container.className = "container_text";

    if (prevUser != userName) {
        let senderImage = document.createElement('p');
        senderImage.className = "userImage";

        let image = document.createElement('img');
        image.className = "profile-picture";
        image.src = "data:image/png;base64," + userImage;

        senderImage.appendChild(image);

        let sender = document.createElement('p');
        if (userRole == "OWNER")
            sender.style.color = "darkgoldenrod";
        else if (userRole == "ADMIN")
            sender.style.color = "darkred";
        else if (userRole == "GUEST")
            sender.style.color = "darkkhaki";
        sender.className = "userSender";
        sender.innerHTML = userName;

        container.appendChild(senderImage);
        container.appendChild(sender);
    }

    let text = document.createElement('p');
    text.className = "userMess";
    text.innerHTML = messageText;

    let date = document.createElement('p');
    date.className = "userDate";
    date.innerHTML = messageDate;

    prevUser = userName;
    container.appendChild(date);
    container.appendChild(text);
    chat.appendChild(container);
    updateScroll();
}
