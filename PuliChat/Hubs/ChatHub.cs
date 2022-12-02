using Microsoft.AspNetCore.SignalR;
using PuliChat.Entities.Models;

namespace PuliChat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string[] message) =>
            await Clients.All.SendAsync("receiveMessage", message);
    }
}
