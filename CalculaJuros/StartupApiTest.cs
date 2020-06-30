using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculaJuros.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace CalculaJuros
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "CalculaJuros API",
                    Description = "Projeto ASP.NET Core Web API que realiza o cálculo de juros compostos aplicando a formula: Valor Final = Valor Inicial * (1 + juros) ^ Tempo",
                    Contact = new OpenApiContact
                    {
                        Name = "Júnior Schröder",
                        Email = string.Empty,
                        Url = new Uri("https://www.linkedin.com/in/juniorschroder/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under MIT",
                        Url = new Uri("https://opensource.org/licenses/MIT"),
                    }
                });
            });
            services.Add(new ServiceDescriptor(typeof(IJurosService), new JurosService()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Calcula Juros v 1.0");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
