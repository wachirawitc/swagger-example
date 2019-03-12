using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using SwaggerExample.Infrastructures;
using SwaggerExample.Infrastructures.Headers;
using SwaggerExample.ViewModel;
using Swashbuckle.AspNetCore.SwaggerGen;

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
            services.AddMvc(options =>
                {
                    options.Filters.Add(new ProducesResponseTypeAttribute(typeof(ErrorViewModel), 400));
                    options.Filters.Add(new ProducesResponseTypeAttribute(typeof(ErrorViewModel), 500));
                })
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddApiVersioning();

            services.AddVersionedApiExplorer(options => options.GroupNameFormat = "'v'VVV");

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<ImeiOperationFilter>();
                options.EnableAnnotations();
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
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

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    string url = $"{swaggerJsonBasePath}/swagger/{description.GroupName}/swagger.json";

                    option.SwaggerEndpoint(url, description.GroupName.ToUpperInvariant());
                }
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}