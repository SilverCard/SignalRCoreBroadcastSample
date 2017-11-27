using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using SignalRCoreBroadcastSample.Hubs;
using SignalRCoreBroadcastSample.Models;
using System;
using System.Threading.Tasks;

namespace SignalRCoreBroadcastSample
{
    public class Program
    {
        static IWebHost _MainHost;

        public static void Main(string[] args)
        {
            _MainHost = BuildWebHost(args);

            var hc = _MainHost.Services.GetService<IHubContext<MainHub, IMainHub>>();
            Task.Factory.StartNew(() => BroadcastLoop(hc));

            _MainHost.Run();
            

        }

        private static async Task BroadcastLoop(IHubContext<MainHub, IMainHub> ctx)
        {
            while (true)
            {
                await ctx.Clients.All.Broadcast(new Message
                {
                    TimeStamp = DateTime.Now,
                    MessageString = $"The current time is {DateTime.Now}."
                });
                await Task.Delay(1000);
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
