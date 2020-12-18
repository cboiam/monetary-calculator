using ImplementationDiscovery.Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MonetaryCalculator.Domain;
using MonetaryCalculator.Infra.Data;
using System.Reflection;

namespace MonetaryCalculator.Host
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(ICommand).Assembly);
            services.RegisterImplementationsOf(typeof(IMapper<,>)).AsScoped();
            services.RegisterDataDependencies(Configuration);
            services.AddControllers();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(options => 
            {
                options.RouteTemplate = "{documentName}/swagger.json";
            });

            app.UseSwaggerUI(options => 
            {
                options.RoutePrefix = string.Empty;
                options.SwaggerEndpoint("/v1/swagger.json", "MonetaryCalculator.Host v1");
            });

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
