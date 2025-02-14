
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Ordering.Application.Data;
using Ordering.Instrastructure.Data.Interceptors;

namespace Ordering.Instrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");
            services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
            services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                options.UseSqlServer(connectionString);
            });
            
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            return services;
        }

        // public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        // {
        //     using var scope = app.ApplicationServices.CreateScope();
        //     var services = scope.ServiceProvider;
        //     var dbContext = services.GetRequiredService<ApplicationDbContext>();
        //     dbContext.Database.Migrate();
        //
        //     return app;
        // }
    }
    
}
