using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace PuliChat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task JoinServer(string serverName)
        {
            // Add the user to the group for their server
            await Groups.AddToGroupAsync(Context.ConnectionId, serverName);
        }

        public async Task LeaveServer(string serverName)
        {
            try
            {
                // Remove the user from the group
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, serverName);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task SendMessage(string[] message, string serverName) =>
            await Clients.Group(serverName).SendAsync("receiveMessage", message);

    }
}
