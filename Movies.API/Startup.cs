using FluentValidation;
using MediatR;
using Microsoft.OpenApi.Models;
using Movies.Application.Commands;
using Movies.Application.Queries;
using Movies.Domain.Entities;
using Movies.Domain.Services;
using Movies.Infrastructure.Services;
using Movies.Persistence;
using Movies.Persistence.Services;

namespace Movies.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.IgnoreNullValues = true; })
                .AddNewtonsoftJson(option => option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.Configure<IMDBApiConfig>(Configuration.GetSection("IMDBApi"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Movies Api", Version = "v1" });
            });

            services.AddMemoryCache();
            
            services.AddHttpClient<IIMDBApiService, IMDBApiService>(client =>
            {
                var imdbApiConfig = Configuration.GetSection("IMDBApi").Get<IMDBApiConfig>();
                client.BaseAddress = new Uri(imdbApiConfig.ApiBaseUrl);
            });

            services.AddScoped<IIMDBApiService, IMDBApiService>();

            // Configure Persistance Services
            services.AddPersistence(Configuration);

            // Configure Application Services
            services.AddScoped<IMovieService, MovieService>();

            // Configure MediatR
            services.AddMediatR(typeof(Startup).Assembly);
            services.AddTransient<IRequestHandler<AddToWatchlistCommand, Unit>, AddToWatchlistHandler>();
            services.AddTransient<IRequestHandler<MarkAsWatchedCommand, Unit>, MarkAsWatchedHandler>();
            services.AddTransient<IRequestHandler<GetWatchlistQuery, IEnumerable<WatchlistItem>>, GetWatchlistHandler>();
            services.AddTransient<IRequestHandler<SearchMovieQuery, Task<Movie>>, SearchMovieHandler>();

            // Configure FluentValidation
            services.AddValidatorsFromAssembly(typeof(Startup).Assembly);

            // Configure Controllers
            services.AddControllers();


            

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movies");
            });

           
            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
