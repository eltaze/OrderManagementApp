using Microsoft.AspNetCore.SignalR;

namespace API.Hcon
{
    public class ConHub : Hub<IConHubClient>
    {
        public async Task SendMassage(string massage)
        {
            
            await Clients.All.SendOffersToUser(massage);
        }
    }
}
