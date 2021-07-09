using API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API
{

    public class Startup
    {
        private readonly IConfiguration _config;

        public object CompatibilityVersion { get; private set; }

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(_config.GetConnectionString("DefaultConnection"));

            });
            services.AddControllers();
  
            services.AddCors(options => options.AddPolicy("AllowAccess_To_API",policy=>policy.
            AllowAnyOrigin().
            AllowAnyMethod().
            AllowAnyHeader()
            ));
           
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowAccess_To_API");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }

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
