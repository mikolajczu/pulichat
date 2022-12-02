/* SIGNALR REAL-TIME CHAT */

class Message {
    constructor(username, text) {
        this.userName = username;
        this.text = text;
    }
}

// userName is declared in razor page.
const username = userName;
const userrole = userRole;
const userimage = userImage;
let textInput;
let chat;
let channel1l;
const messagesQueue = [];

function initialize(channel) {
    channel1 = channel;
    textInput = document.getElementById('text');
    chat = document.getElementById('ChannelContent');
}

function clearInputField() {
    messagesQueue.push(textInput.value);
    textInput.value = "";
}

function sendMessage() {
    let text = messagesQueue.shift() || "";
    if (text.trim() === "") return;

    let message = new Message(username, text);
    sendMessageToHub(message, channel1, userrole, String(userimage));
}

function addMessageToChat(message, channelId, userRole, userImage) {
    if (channelId != channel1) return;

    let container = document.createElement('div');
    container.className = "container_text";

    let senderImage = document.createElement('p');
    senderImage.className = "userImage";

    let image = document.createElement('img');
    image.className = "profile-picture";
    image.src = "data:image/png;base64," + String(userImage);

    senderImage.appendChild(image);

    let sender = document.createElement('p');
    if (userRole == "OWNER")
        sender.style.color = "darkgoldenrod";
    else if (userRole == "ADMIN")
        sender.style.color = "darkred";
    else if (userRole == "GUEST")
        sender.style.color = "darkkhaki";
    sender.className = "userSender";
    sender.innerHTML = message.userName;

    let text = document.createElement('p');
    text.className = "userMess";
    text.innerHTML = message.text;

    container.appendChild(senderImage);
    container.appendChild(sender);
    container.appendChild(text);
    chat.appendChild(container);
    updateScroll();
}
