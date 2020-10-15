using System;
using SDS.Core.DomainService;
using SDSUI;
using SDS.Core.AplicationService.Services;
using SDS.Core.AplicationService;
using SDS.Infrastructure.data.Repositories;
using SDS.Core.Entity;
using System.Collections.Generic;
using System.Collections;
using Microsoft.Extensions.DependencyInjection;
using SDS.Infrastructure.data;

namespace SDS
{
    class Program
    {
        
        static void Main(string[] args)
        {

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IAvatarRepository, AvatarRepo>();
            serviceCollection.AddScoped<IAvatarService, AvatarService>();
            serviceCollection.AddScoped<IPrinter, NewPrinter>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var avatarRepo = serviceProvider.GetRequiredService<IAvatarRepository>();
            new DBinitializer(avatarRepo).InitData();
            var printer = serviceProvider.GetRequiredService<IPrinter>();
            printer.StartUI();


        }
    }
}
