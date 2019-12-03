using System;
using Autofac;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using VideoDB.WebApi.Middleware;
using VideoDB.WebApi.Validators;

namespace Evo.WebApi
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
            services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo()
                    {
                        Title = "Evo API",
                        Version = "v1",
                        Contact = new OpenApiContact
                        {
                            Name = "Aaron Rinn",
                            Url = new Uri("https://gitlab.com/arinn1204/evo_dotnet")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "MIT",
                            Url = new Uri("https://gitlab.com/arinn1204/evo_dotnet/blob/master/LICENSE")
                        }
                    });
                })
                .AddControllers()
                .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<VideoValidator>());
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(GetType().Assembly)
                .Where(w => w.IsPublic && !w.IsInterface)
                .AsImplementedInterfaces();

            var mappingConfig = new MapperConfiguration(cfg => cfg.AddMaps(GetType().Assembly));
            var mapper = new Mapper(mappingConfig);
            builder.RegisterInstance<IMapper>(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseSwagger()
                .UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Evo API v1"); })
                .UseHttpsRedirection()
                .UseRouting()
                .UseEndpoints(endpoint => endpoint.MapControllers())
                .UseMiddleware(typeof(ErrorHandlingMiddleware));
        }
    }
}