using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SDS.Core.AplicationService;
using SDS.Core.AplicationService.Services;
using SDS.Core.DomainService;
using SDS.Core.Entity;
using SDS.Infrastructure.data;
using SDS.Infrastructure.data.Repositories;

namespace WebAPI
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
            //var serviceCollection = new ServiceCollection();///////////new imp
            services.AddScoped<IAvatarRepository, AvatarRepo>();
            services.AddScoped<IAvatarService, AvatarService>();
            services.AddScoped<IAvatarTypeRepository, AvatarTypeRepo>();
            services.AddScoped<IAvatarTypeService, AvatarTypeService>();
            services.AddScoped<IOwnerRepository, OwnerRepo>();
            services.AddScoped<IOwnerService, OwnerService>();

            services.AddControllers();

            // Register the Swagger generator using Swashbuckle.
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Nadia's First Try API",
                    Description = "This is just a tryout api for swagger.Enjoy!"
                });

            //// Register the Swagger generator, defining 1 or more Swagger documents
            //services.AddSwaggerGen(options => {
            //    options.SwaggerDoc("v1",
            //       new Microsoft.OpenApi.Models.OpenApiInfo
            //       {
            //           Title = "Nadia's First Try",
            //           Description = "This is just a tryout api for swagger.Enjoy!",
            //           Version = "v1"
            //       });
          });

            // Configure the default CORS policy.
            services.AddCors(options =>
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    })
            );



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
               
                app.UseDeveloperExceptionPage();

            }

           

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<IAvatarRepository>();
                var atrepo = scope.ServiceProvider.GetRequiredService<IAvatarTypeRepository>();
                var owrepo = scope.ServiceProvider.GetRequiredService<IOwnerRepository>();
                //repo.Create(new Avatar { Name = "Bunsy", Type ="Bunny", Color ="Blue"});
                //repo.Create(new Avatar { Name = "Chili", Type = "Magician", Color = "Pink" });

                IAvatarRepository avatarRepository = new AvatarRepo();
                IAvatarTypeRepository avatarTypeRepository = new AvatarTypeRepo();
                IOwnerRepository ownerRepository = new OwnerRepo();

                //new DBinitializer  = new DBinitializer();
                //d.InitData();

                DBinitializer.InitData();
                IAvatarService avatarService = new AvatarService(avatarRepository);
                IAvatarTypeService avatarTypeService = new AvatarTypeService(avatarTypeRepository);
                IOwnerService ownerService = new OwnerService(ownerRepository);

                //YOU DID GITHUB WIHT TERMINAL !!!


                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();
                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
                // specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    //c.RoutePrefix = string.Empty;
                });

               ////////////////////Swagger Result: add--> /swagger/index.html 


                // app.UseWelcomePage();

                app.UseHttpsRedirection();

                app.UseRouting();

                // Enable CORS 
                app.UseCors();

                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }
        }
    }
}


