using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StudentsManagement.Core.Shared;
using StudentsManagement.Persistence;

namespace WebStudentsManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var dataService = scope.ServiceProvider.GetService<IPersistenceContext>();
                if (dataService != null)
                {
                    dataService.InitializeData(scope.ServiceProvider);
                }

                var authService = scope.ServiceProvider.GetService<IAuthentication>();
                if (authService != null)
                {
                    authService.InitializeData(scope.ServiceProvider);
                }
            }
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
