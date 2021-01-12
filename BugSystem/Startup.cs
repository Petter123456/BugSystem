using BugSystem.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BugSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddSwaggerGen(); 

            var server = Configuration["DBSERVER"] ?? "bugsDb";
            var port = Configuration["DBPORT"] ?? "1433";
            var user = Configuration["DBUSER"] ?? "SA";
            var password = Configuration["DBPASSWORD"] ?? "myPass123";
            var database = Configuration["Database"] ?? "bugsDb";

            services.AddDbContext<BugsContext>(options =>
            {
                options.UseSqlServer($"Server={server},{port};Initial Catalog={database};User ID = {user}; Password={password}");
            //options.UseSqlServer(Configuration.GetConnectionString("MyNewDatabase"));

        });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();





            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "Bugs V1");
                c.RoutePrefix = string.Empty;
            });

      

            app.UseHttpsRedirection();

            app.UseRouting();

            PrepDb.PrepPopulation(app); 

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
