using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notes.Application.Interfaces;

namespace Notes.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["MSSQL"];
            services.AddDbContext<NotesDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddScoped(provider =>
            {
                var dbContext = provider.GetService<NotesDbContext>();
                return dbContext == null ? throw new Exception("NotesDbContext not found in service provider.") : (INotesDbContext)dbContext;
            });


            return services;
        }
    }
}
