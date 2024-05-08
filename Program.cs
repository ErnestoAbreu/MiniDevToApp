global using FastEndpoints;
global using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiniDevToApp.DataBases;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthenticationJwtBearer(s => s.SigningKey = builder.Configuration[ "JwtSigningKey" ])
    .AddAuthorization()
    .AddFastEndpoints()
    .SwaggerDocument();

builder.Services.AddDbContext<IdentityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnectionString")));
builder.Services.AddDbContext<ArticleDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ArticleConnectionString")));


var app = builder.Build();

app.UseAuthentication()
   .UseAuthorization()
   .UseFastEndpoints()
   .UseSwaggerGen();

app.MapGet("/", () => "Hello World!" );

app.Run();
