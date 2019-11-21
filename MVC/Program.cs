using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MVC;
using ui.Services;

namespace ui
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var host = CreateWebHostBuilder(args).Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    //SignalR Event Receiver Service
                    var serviceContext = services.GetRequiredService<EventReceiverService>();
                    serviceContext.StartReceive();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception occured, message: {ex.Message}, stacktrace: {ex.StackTrace}");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
