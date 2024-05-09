
using BackEnd.Model;
using BackEnd.UOF;
using businessLogic.BL;
using businessLogic.Model;
using DataBack.Data;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;

namespace API.Hcon
{
    public class BackGroundServices : IHostedService, IDisposable
    {
        private readonly IConfiguration config;
        private Timer? timer;
        private IHubContext<ConHub, IConHubClient> _messageHub;
        private readonly OrderContext _context;
        private readonly IServiceScopeFactory scopeFactory;

        public BackGroundServices(IConfiguration Cofig,
            IHubContext<ConHub, IConHubClient> messageHub,
             IServiceScopeFactory scopeFactory
            )
        {
            config = Cofig;
            _messageHub = messageHub;           
            this.scopeFactory = scopeFactory;
            
        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            int fromsec = int.Parse(config.GetSection("Timer").Value);
            timer =new Timer(SendMessage,null,TimeSpan.Zero,TimeSpan.FromSeconds(fromsec));
            return Task.CompletedTask;
        }

        private async void SendMessage(object? state)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var uof = scope.ServiceProvider.GetRequiredService<ProductBL>();
                var result = await uof.All() ;
                if (result == null || result.Count ==0)
                {
                    await _messageHub.Clients.All.SendOffersToUser
                        ("No product found in our database wait for update");
                }
                else
                {
                    string xb = JsonSerializer.Serialize<List<ProductsUI>>(result) ;
                    await _messageHub.Clients.All.SendOffersToUser(xb);
                }
            }
               
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;

        }
        public void Dispose()
        {
            timer?.Dispose();
        }
    }
}
