using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace eNompilo.v3._0._1.Models.Family_Planning
{

    public class MessageHub : Hub
    {
        public async Task SendMessage(string user, string message, string practitionerId)
        {
            await Clients.Group(practitionerId).SendAsync("ReceiveMessage", user, message);
        }

        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }
    }

}
