using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Cella.Domain.Configuration;
using WarehouseCrm.Web.Helpers;
using Cella.Models;

namespace Warehouse.Web {
    public class Program {
        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args)
                .ConfigureAppConfiguration((hostingContext, configBuilder) =>
                {
                    var config = configBuilder.Build();
                    var configSource = new EFConfigSource(opts =>
                        opts.UseSqlServer(config.GetConnectionString("DefaultConnection")));
                    configBuilder.Add(configSource);
                }).Build();
            
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger("app");
                try
                {
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    await SeedRoles.SeedAsync(userManager, roleManager);
                   await SeedUsers.SeedAdminUser(userManager, roleManager);
                    
          //          logger.LogInformation("Finished Seeding Default Data");
        //            logger.LogInformation("Application Starting");
                }
                catch (Exception ex)
                {
                    logger.LogWarning(ex, "An error occurred seeding the DB");
                }
            }
            host.Run();
        }
   
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                     webBuilder.UseStartup<Startup>();
                });
    }
}
