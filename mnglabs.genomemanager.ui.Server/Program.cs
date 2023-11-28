using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using mnglabs.genomemanager.ui.services.Data;
using mnglabs.genomemanager.ui.services.Service;
using AutoMapper;
using System;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.WithOrigins("https://localhost:7298")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
});
builder.Services.AddDbContext<DataManagerContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:Default"]);
    options.EnableDetailedErrors();
    options.EnableSensitiveDataLogging();
});
builder.Services.AddSingleton<StateContainer>();
builder.Services.AddScoped<IDataManagerRepository, DataManagerRepository>();
builder.Services.AddScoped<IVariantService, VariantService>();
builder.Services.AddScoped<IGMApplicationCacheManager, GMApplicationCacheManager>();
builder.Services.AddScoped<ICacheService, CacheService>();
builder.Services.AddMemoryCache();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();

app.Run();
