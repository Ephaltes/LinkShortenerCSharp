using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace LinkShortener.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://*:5050"); //Wenn die anwendung über die console gestartet wird sie �ber port 50 laufen sonst �ber die in hostsettings eingestellte
                    webBuilder.ConfigureKestrel((context, options) =>
                    {
                        options.AddServerHeader = false;
                    });
                }).ConfigureHostConfiguration(configHost =>
                {
                    configHost.SetBasePath(Directory.GetCurrentDirectory());
                    configHost.AddJsonFile("hostsettings.json", true);
                    configHost.AddCommandLine(args);
                    configHost.Build();
                });


    }
}