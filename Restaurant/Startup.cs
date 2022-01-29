using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Restaurant.BL.Interfaces;
using Restaurant.BL.Services;
using Restaurant.DL.Interfaces;
using Restaurant.DL.Repositories;
using Restaurant.Host.Extensions;
using Serilog;
using ILogger = Serilog.ILogger;

namespace Restaurant.Host
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
            services.AddSingleton(Log.Logger);

            // Repositories
            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<ITableRepository, TableRepository>();

            // Services
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<ITableService, TableService>();

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Restaurant", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant v1"));
            }

            app.ConfigureExceptionHandler(logger);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
