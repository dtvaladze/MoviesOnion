using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Movies.Domain.Repositories;
using Movies.Persistence.Repositories;
using System.Reflection;

namespace Movies.Persistence
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), sqlOptions =>
            {
                sqlOptions.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            }));
           
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
        public static IApplicationBuilder ConfigurePersistence(this IApplicationBuilder app, MovieDbContext db)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<MovieDbContext>();
                db.Database.EnsureCreated();
                db.Database.Migrate();

                UserSeeder.SeedUsers(dbContext);
            }

            return app;
        }
    }
}
