using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using SDS.Core.AplicationService;
using SDS.Core.AplicationService.Services;
using SDS.Core.DomainService;
using SDS.Infrastructure.data;
using SDS.Infrastructure.data.Repositories;
using WebAPI.data;
using WebAPI.Data;
using WebAPI.Helpers;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;

        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            }

            );

            if (Environment.IsDevelopment())
            {
                services.AddDbContext<SDScontext>(opt => { opt.UseSqlite("Data Source=SDSApp.db"); }
                );
            }
            else
            {
                services.AddDbContext<SDScontext>(opt => { }
                    //opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection"))
                    );
            }
            // Create a byte array with random values. This byte array is used
            // to generate a key for signing JWT tokens.
            Byte[] secretBytes = new byte[40];
            Random rand = new Random();
            rand.NextBytes(secretBytes);

            //Add JWT based authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    //ValidAudience = "TodoApiClient",
                    ValidateIssuer = false,
                    //ValidIssuer = "TodoApi",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
                    ValidateLifetime = true, //validate the expiration and not before values in the token
                    ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                };
            });



            //var serviceCollection = new ServiceCollection();///////////new imp
            services.AddScoped<IAvatarRepository, AvatarRepo>();
            services.AddScoped<IAvatarService, AvatarService>();
            services.AddScoped<IAvatarTypeRepository, AvatarTypeRepo>();
            services.AddScoped<IAvatarTypeService, AvatarTypeService>();
            services.AddScoped<IOwnerRepository, OwnerRepo>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddTransient<IDBinitializer, DBinitializer>();
            

            services.AddControllers();

            //NEWtonsoftJson
            services.AddMvc().AddNewtonsoftJson();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddControllers().AddNewtonsoftJson(options =>
            {    // Use the default property (Pascal) casing
                
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.MaxDepth = 2;  // 100 pet limit per owner
                //   options.SerializerSettings.MaxDepth = 2;  // 100 pet limit per owner
            });


            // Register the AuthenticationHelper in the helpers folder for dependency
            // injection. It must be registered as a singleton service. The AuthenticationHelper
            // is instantiated with a parameter. The parameter is the previously created
            // "secretBytes" array, which is used to generate a key for signing JWT tokens,
            services.AddSingleton<IAuthenticationHelper>(new
                AuthenticationHelper(secretBytes));


            //services.AddDbContext<SDScontext>(
                 
            //opt =>
            //    {
            //        opt
            //            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            //            .UseLoggerFactory(loggerFactory)
            //            .UseSqlite("Data Source=SDSApp.db");

            //    }, ServiceLifetime.Transient);
           
            
            // In-memory database:
            //services.AddDbContext<sdsDBcontext>(opt => opt.UseInMemoryDatabase("TodoDb"));

            // Register the Swagger generator using Swashbuckle.
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Nadia's First Try API",
                    Description = "This is just a tryout api for swagger.Enjoy!"
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
          

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


            //services.AddAuthentication(
            //       CertificateAuthenticationDefaults.AuthenticationScheme)
            //   .AddCertificate();

        }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    // Initialize the database
                    var services = scope.ServiceProvider;
                    var ctx = scope.ServiceProvider.GetService<SDScontext>();
                    ctx.Database.EnsureDeleted();
                    ctx.Database.EnsureCreated();
                    var dbInitializer = services.GetService<IDBinitializer>();
                    dbInitializer.InitData(ctx);
                }
            }

            else
            {
                app.UseHsts();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<SDScontext>();
                    ctx.Database.EnsureCreated();
                }
            }
            



            
            //using (var scope = app.ApplicationServices.CreateScope())
            //{

            //    var ctx = scope.ServiceProvider.GetService<SDScontext>();
                
                
            //    //var context = scope.ServiceProvider.GetService<SQLDBContext>();
            //    //context.Database.EnsureDeleted();
            //    //context.Database.EnsureCreated();
            //    var repo = scope.ServiceProvider.GetRequiredService<IAvatarRepository>();
            //    var atrepo = scope.ServiceProvider.GetRequiredService<IAvatarTypeRepository>();
            //    var owrepo = scope.ServiceProvider.GetRequiredService<IOwnerRepository>();
            //    //repo.Create(new Avatar { Name = "Bunsy", Type ="Bunny", Color ="Blue"});
            //    //repo.Create(new Avatar { Name = "Chili", Type = "Magician", Color = "Pink" });


            //    new DBinitializer().InitData(ctx);
                //DBinitializer.InitData(ctx);
                //Console.WriteLine("avatar count = " + ctx.Avatars.Count());
                //Console.WriteLine("owner count = " + ctx.Owners.Count());
                //Console.WriteLine("avatar type count = " + ctx.AvatarTypes.Count());

              




                //YOU DID GITHUB WIHT TERMINAL !!!PARTYYY




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

                //Authentication
                app.UseAuthentication(); 

                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }
        }
    }



