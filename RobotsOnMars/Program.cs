using RobotsOnMars.Engines;
using RobotsOnMars.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RobotsOnMars.Abstractions;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddSingleton<IInputEngine, InputEngine>()
        .AddSingleton<IMovementEngine, MovementEngine>()
        .AddSingleton<IMarsEngine, MarsEngine>()
        .AddSingleton<IRobotsEngine, RobotsEngine>()
        .AddTransient<RobotsOnMarsService>()
        )
    .Build();

FollowRobotsOnMars(host.Services);

await host.RunAsync();

//namespace RobotsOnMars
//{
//public class Program
//{
static void FollowRobotsOnMars(IServiceProvider services)
{
    using IServiceScope serviceScope = services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;
    RobotsOnMarsService service = provider.GetRequiredService<RobotsOnMarsService>();
    service.FollowRobotsOnMars();
}
//}
//}
