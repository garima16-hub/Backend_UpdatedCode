using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using _3DModels.Models;
using _3DModels.Repository;
using _3DModels.Services;
using _3DModels.Controllers;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using _3DModels.Repositories;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Reflection;
using System.Text;

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
            //services.AddScoped<UsersRepository>();
            //services.AddScoped<UsersService>();
            services.AddScoped<LoginController>();
            services.AddScoped<ModelRepository>();
            services.AddScoped<IModel, ModelRepository>();
            services.AddScoped<IModelAccessories, ModelAccessoriesRepository>();
            //services.AddScoped<ModelService>();
            services.AddScoped<ModelCoordinatorRepository>();
            services.AddScoped<ModelCoordinatorService>();
            services.AddScoped<ModelDesignerService>();
            services.AddScoped<ModelDesignerRepository>();
           

            services.AddScoped<UserRegistrationService>();
            services.AddScoped<PasswordHashingService>();
            
           

            // Register the UserRegistrationService with a scoped lifetime






            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());



            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero



                };
            });



            // Configure Swagger documentation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "3DModel API", Version = "v1" });
                c.SchemaFilter<BooleanSchemaFilter>();
            });
        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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