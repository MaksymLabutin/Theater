﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Theater.WebApi.Auth;

namespace Theater.WebApi
{
    public class Startup
    {

        private const string ClientAppCors = "clientApp";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                  .AddJwtBearer(options =>
                  {
                      options.RequireHttpsMetadata = true;
                      options.TokenValidationParameters = new TokenValidationParameters
                      {
                          // укзывает, будет ли валидироваться издатель при валидации токена
                          ValidateIssuer = true,
                          // строка, представляющая издателя
                          ValidIssuer = AuthOptions.ISSUER,

                          // будет ли валидироваться потребитель токена
                          ValidateAudience = true,
                          // установка потребителя токена
                          ValidAudience = AuthOptions.AUDIENCE,
                          // будет ли валидироваться время существования
                          ValidateLifetime = true,

                          // установка ключа безопасности
                          IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                          // валидация ключа безопасности
                          ValidateIssuerSigningKey = true,
                      };
                  });

            services.AddCors((corsOptions) =>
            {
                corsOptions.AddPolicy(ClientAppCors, builder =>
                {
                    builder
                        .WithOrigins(Configuration.GetValue<string>("ClientAppUrl"))
                        .WithMethods("GET", "POST", "PUT")
                        .WithHeaders(HeaderNames.ContentType, "application/json", HeaderNames.Authorization, "Bearer")
                        .Build();
                });
            });
             
            //todo Add Postgre SQL

            services.AddMediatR(Assembly.GetExecutingAssembly());  
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
           
            app.UseCors(ClientAppCors);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); 
            });
        }
    }
}
