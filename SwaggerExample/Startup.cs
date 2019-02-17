using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace SwaggerExample
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
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Title = "Example Version 1",
                    Version = "v1"
                });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(option =>
            {
                var swaggerJsonBasePath = string.IsNullOrWhiteSpace(option.RoutePrefix) ? "." : "..";

                option.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Example Version 1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}