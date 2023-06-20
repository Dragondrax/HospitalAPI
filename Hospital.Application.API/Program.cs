using Hospital.Application.API.Configuration;
using Hospital.Application.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]
    
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.ResolveDependencies();
builder.Services.AddIdentityConfig(builder.Configuration);

builder.Services.AddApiConfig();

var app = builder.Build();


app.UseApiConfig(app.Environment);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
