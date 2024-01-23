using Elastic.CommonSchema;
using ODD.Api.ActionFilters;
using ODD.Api.Bootstrapper;
using ODD.Api.Core.Middlewares;
using LoggerService.IOC;
using LoggerService.Services;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.IISIntegration;
using Captcha.Service.Generator;

var builder = WebApplication.CreateBuilder(args);
// Camel case json result
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.AddLoggerService("serilog");
builder.Services.AddCaptcha();
builder.Services.AddMemoryCache();
Bootstrapper.Configure(builder, builder.Configuration.GetConnectionString("SSMS"));

#region IOC
builder.Services.AddSingleton<ActionLogAttribute>();
builder.Services.AddSingleton<ModelValidationAttribute>();

//builder.Services.AddLoggerService(builder.Configuration.GetSection("LogProvider").Value);
#endregion
//Api cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("APICORS", options =>
    {
        options.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseAntiXssMiddleware();
app.UseCors("APICORS");
app.MapControllers();

app.Run();
