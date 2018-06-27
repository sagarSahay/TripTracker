using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace TripTracker.BackService
{
    using Data;
    using Microsoft.EntityFrameworkCore;

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
            //services.AddTransient<Models.Repository>();
            services.AddMvc();
            services.AddDbContext<TripContext>(options => options.UseSqlite("Data Source= SagarTrips.db"));
            services.AddSwaggerGen(options =>
                                   options.SwaggerDoc("v1", new Info { Title = "TripTracker", Version = "V1" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(options =>
                             options.SwaggerEndpoint("/swagger/v1/swagger.json","trip Tracker v1")
                            );
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            TripContext.SeedData(app.ApplicationServices);
        }
    }
}
