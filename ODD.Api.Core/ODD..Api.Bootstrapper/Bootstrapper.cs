
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ODD.Api.Application.AbstractFactory;
using ODD.Api.Application.Contract.Interfaces.Authentication;
using ODD.Api.Application.Contract.Services.User;
using ODD.Api.Application.Interfaces;
using ODD.Api.Application.Interfaces.Cryptography;
using ODD.Api.Application.Interfaces.WebServices;
using ODD.Api.Application.Services.User;
using ODD.Api.Infrastructure.AbstractFactory;
using ODD.Api.Infrastructure.Database.Context.SSMS;
using ODD.Api.Infrastructure.Utility.Helpers.Hash;
using ODD.Api.Infrastructure.Utility.Interfaces;
using ODD.Api.Infrastructure.Utility.Interfaces.Authentication;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Text;

namespace ODD.Api.Bootstrapper
{
    public class Bootstrapper
    {
            
        public static void Configure(WebApplicationBuilder builder, string ssmsConnectionString)
        {
            builder.Services.AddDbContext<SSMSDbContextEfCore>(x => x.UseSqlServer(ssmsConnectionString));

            #region Register business Services
            builder.Services.AddTransient<IUserService, UserService>();
            #endregion
           
           
            #region Register Public Service
            builder.Services.AddTransient<IApplicationSSMSEfCoreContext, SSMSDbContextEfCore>();
            builder.Services.AddTransient<ICryptography, HashMakerHelper>();
            builder.Services.AddScoped<IJwtAuthentication, JwtAuthentication>();
            builder.Services.AddHttpContextAccessor();
            #endregion
            builder.Services.AddTransient<IApplicationDapperContext, DapperSSMSDBHelper>();
            builder.Services.AddScoped<IDapperAbstractFactory, DapperConcreteFactory>();
            builder.Services.AddScoped<DapperSSMSDBHelper>();
            #region Jwt Authentication
            // Adding Authentication  
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

                        // Adding Jwt Bearer  
                        .AddJwtBearer(options =>
                        {
                            options.SaveToken = true;
                            options.RequireHttpsMetadata = false;
                            options.TokenValidationParameters = new TokenValidationParameters()
                            {
                                ValidateIssuer = true,
                                ValidateAudience = true,
                                ValidAudience = builder.Configuration["JwtConfig:audience"],
                                ValidIssuer = builder.Configuration["JwtConfig:issuer"],
                                ClockSkew = TimeSpan.Zero,
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:key"]))
                            };
                        });

            //Swagger BrearerToken
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TBS.Webapi.Core",
                    Version = "v1"
                });
                //x.SwaggerDoc("v2", new OpenApiInfo { Title = "webapi", Version = "v2" });
                options.DocInclusionPredicate((doc, apiDescription) =>
                {
                    if (!apiDescription.TryGetMethodInfo(out MethodInfo methodInfo)) return false;
                    var version = methodInfo.DeclaringType?.GetCustomAttributes<Microsoft.AspNetCore.Mvc.ApiVersionAttribute>(true).SelectMany(x => x.Versions);

                    return version.Any(x => $"v{x.ToString()}" == doc);
                });


                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter jwt bearer token"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
             new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type=ReferenceType.SecurityScheme,
                Id="Bearer"
            }
        },
            new string[]{}
        }



        });
            });
            #endregion

        }
    }
}