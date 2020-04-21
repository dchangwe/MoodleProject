using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;
using Contracts;
using LoggerService;
using Microsoft.EntityFrameworkCore.SqlServer;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository;

namespace Moodle.Extensions
{
    public static class ServiceExtensions
    {
        //send requests from a different domain to our application
        public static void ConfigureCors(this IServiceCollection services) => 
            services.AddCors(options => { 
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()); });
        //configure an IIS integration to help deploy to IIS
        public static void ConfigureIISIntegration(this IServiceCollection services) => 
            services.Configure<IISOptions>(options => {

        });
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) => 
            services.AddDbContext<RepositoryContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b =>
            b.MigrationsAssembly("Moodle")));
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        public static IMvcBuilder AddCustomCSVFormatter(this IMvcBuilder builder) 
            => builder.AddMvcOptions(config => config.OutputFormatters.Add(new CSVOutputFormatter()));


    }
}
