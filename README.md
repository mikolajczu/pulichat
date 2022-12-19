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

Application have 3 themes: purple (default), green, blue

### Sneak peak
<img src="https://user-images.githubusercontent.com/74252181/208483849-35dd376b-f5f9-429e-a516-b7d5b31ca07d.png" height="320px" />
<img src="https://user-images.githubusercontent.com/74252181/208484197-8439dd72-4888-4361-8b59-5be5943c77fb.png" height="320px" />

Technologies: C#, ASP.NET CORE 6, SignalR, Razor Pages, CSS, JavaScript
