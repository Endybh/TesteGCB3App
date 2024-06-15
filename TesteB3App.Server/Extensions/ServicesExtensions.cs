using MediatR;
using Microsoft.Extensions.Options;
using TesteB3App.Core.Application.Commands;
using TesteB3App.Core.Application.Handlers;
using TesteB3App.Core.Domain.Entities;
using TesteB3App.Core.Domain.Services;
using TesteB3App.Core.Dtos;
using TesteB3App.Core.Interfaces;
using TesteB3App.Core.Notification;

namespace TesteB3App.Server.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
        }
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<NotificationContext>();
            services.AddScoped<IIncomeService, IncomeService>();            
            services.AddScoped<IRequestHandler<SimulateIncomeCommand, SumulatedIncomeCdbDto>, SimulateIncomeCommandHandler>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        }
    }
}
