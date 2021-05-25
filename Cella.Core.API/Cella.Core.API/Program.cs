using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cella.Domain.Configuration;
using Cella.Models;

namespace CellaCrm.Core.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args)

             .ConfigureAppConfiguration((hostingContext, configBuilder) =>
              {
                  var config = configBuilder.Build();
                  var configSource = new EFConfigSource(opts =>
                      opts.UseSqlServer(config.GetConnectionString("DefaultConnection")));
                  configBuilder.Add(configSource);
              }).Build();

      
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
