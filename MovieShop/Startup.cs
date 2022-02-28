using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Infrastructure.Repositories;
using ApplicationCore.Contracts.Repositories;

namespace MovieShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }
        public void ConfigureServices(IServiceCollection service)
        {
            service.AddControllers();
            service.AddDbContext<MovieShopDbContext>(option => {
                option.UseSqlServer(Configuration.GetConnectionString("MovieShopDB"));
            });
            service.AddScoped<IGenreRepository, GenreRepository>();
            service.AddScoped<IMovieRepository, MovieRepository>();
            //service.AddScoped<IGenreService, GenreService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints => {

                endpoints.MapGet("/", async context =>
                 {
                     await context.Response.WriteAsync("MOVIE SHOP PROJECT HOME PAGE");
                 });

               
                endpoints.MapControllers();
            });

        }
    }
}
