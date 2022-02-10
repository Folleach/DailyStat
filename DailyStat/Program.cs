using System;
using System.IO;
using System.Reflection;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DailyStat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InitLog4Net();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        
        private static void InitLog4Net()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            var logConfigLocation = Environment.GetEnvironmentVariable("FOLLEACH_Log4NetConfig");
            Console.WriteLine($"Use the log config in: {logConfigLocation}");
            XmlConfigurator.Configure(logRepository, new FileInfo(logConfigLocation ?? "/home/folleach/settings/log4net.config"));
        }
    }
}