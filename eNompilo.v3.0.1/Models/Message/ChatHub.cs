using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;



namespace eNompilo.v3._0._1.Models.Message
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string receiverId, string message)
        {
            await Clients.User(receiverId).SendAsync("ReceiveMessage", message);
        }
    }


}
