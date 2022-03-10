using RobotsOnMars.Engines;
using RobotsOnMars.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RobotsOnMars.Abstractions;

namespace RobotsOnMars
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            FollowRobotsOnMars(host.Services);

            //host.Run();
        }

        static void FollowRobotsOnMars(IServiceProvider services)
        {
            using IServiceScope serviceScope = services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;
            RobotsOnMarsService service = provider.GetRequiredService<RobotsOnMarsService>();
            service.FollowRobotsOnMars();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<IInputEngine, InputEngine>()
                    .AddSingleton<IMovementEngine, MovementEngine>()
                    .AddSingleton<IMarsEngine, MarsEngine>()
                    .AddSingleton<IRobotsEngine, RobotsEngine>()
                    .AddTransient<RobotsOnMarsService>();
            });
    }
}
