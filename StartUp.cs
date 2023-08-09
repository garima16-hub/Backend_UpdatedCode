using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using _3DModels.Models;
using _3DModels.Repository;
using _3DModels.Services;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using AutoMapper;
using _3DModels.Controllers;
using _3DModels.Repositories;
using Microsoft.Extensions.Logging;
using System.Configuration;


namespace _3DModels
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
            services.AddControllers();
            services.AddLogging();

            // AutoMapper Configuration

            services.AddAutoMapper(typeof(Startup).Assembly);
            services.AddAutoMapper(ConfigureAutoMapper);





            // Configure the database context
            services.AddDbContext<ModelDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("dbconn")));








            // Configure CORS
            services.AddCors(options =>
            {
                options.AddPolicy("default", builder =>
                {
                    builder.AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowAnyOrigin();
                });
            });



            // Add repository and service dependencies
            services.AddScoped<OrdersRepository>();
            services.AddScoped<OrdersService>();
            // services.AddScoped<ModelAccessoriesService>();
            // services.AddScoped<UsersRepository>();
            // services.AddScoped<UsersService>();
            services.AddScoped<LoginController>();
            services.AddScoped<ModelRepository>();
            services.AddScoped<IModel, ModelRepository>();
            services.AddScoped<IModelAccessories, ModelAccessoriesRepository>();
            // services.AddScoped<ModelService>();
            services.AddScoped<ModelCoordinatorRepository>();
            services.AddScoped<ModelCoordinatorService>();
            services.AddScoped<ModelDesignerService>();
            services.AddScoped<ModelDesignerRepository>();
            services.AddScoped<UsersService>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IInventoryService, InventoryService>();


            services.AddScoped<UserRegistrationService>();
            services.AddScoped<PasswordHashingService>();

            // Register the AuthService with a singleton lifetime (if it's not expected to have per-request state)
            // var jwtSecret = Configuration["ApplicationSettings:JWT_Secret"].ToString();
            //var key = Encoding.UTF8.GetBytes(jwtSecret);
            // services.AddSingleton<AuthService>(_ => new AuthService(jwtSecret));

            // Configure JWT authentication
            var jwtSecret = Configuration["Jwt:Key"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = key
                    };
                });
            // Configure JWT authentication for Swagger UI
            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description = "Enter 'Bearer {token}'",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            };




            // Configure Swagger documentation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "3DModel API", Version = "v1" });
                c.OperationFilter<RouteParameterOperationFilter>();
                c.AddSecurityDefinition("Bearer", securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            { securityScheme, new[] { "Bearer" } }
        });

                // Add XML comments to the Swagger documentation

            });
        }


        public void ConfigureAutoMapper(IMapperConfigurationExpression cfg)
        {
            // Assuming you have a CreateMap method to define the mapping between ModelDTO and Model.
            cfg.CreateMap<ModelDTO, Model>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable Swagger UI
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "3DModel API V1");

            });


            app.UseRouting();

            // Enable CORS
            app.UseCors("default");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}