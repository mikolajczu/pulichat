# PuliChat
Real-time chat web application with authorization and <br />
authentication divided as follows: <br />
User ➔ Servers ➔ Channels ➔ Messages <br />

User can have multiple servers and multiple messages.
Channel can have one server and multiple messages.
Servers can have multiple users and channels.
Messages can have one channel and one user.

The user, when he connects to the server, is added to the group named 'servername'_'serverid'.

When user is sending a message:
1. Message is sent to the controller where its correctness is checked.
2. Controller returns JSON which is captured by SignalR.
3. SignalR sends a message to all users connected to the group.

Technologies: C#, ASP.NET CORE 6, SignalR, Razor Pages, CSS, JavaScript
