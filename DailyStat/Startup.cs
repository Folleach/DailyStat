using System;
using Cassandra.Mapping;
using DailyStat.Repositories;
using log4net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DailyStat
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            Log.Info("Configure services...");
            MappingConfiguration.Global.Define<DailyStatMappings>();
            var settingsPath = Environment.GetEnvironmentVariable("FOLLEACH_DailyStatSettings"); 
            Log.Info($"Settings path: {settingsPath}");
            var settings = new Settings<DailyStatSettings>(settingsPath);
            
            services.AddSingleton(x => settings);
            services.AddSingleton(x => new CassandraCluster(
                login: settings.Get().CassandraUserName,
                password: settings.Get().CassandraPassword,
                keyspace: AppKeyspace,
                contactPoints: settings.Get().CassandraContactPoints));
            services.AddSingleton<EventRepository>();
            services.AddSingleton<ThingRepository>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UsePathBase("/dailyStat/api");

            app.UseCors(x =>
            {
                x.AllowAnyOrigin();
                x.AllowAnyMethod();
                x.AllowAnyHeader();
            });

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        public const string AppKeyspace = "dailyStat";
        private static readonly ILog Log = LogManager.GetLogger(typeof(Startup));
    }
}
