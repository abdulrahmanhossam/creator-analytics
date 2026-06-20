using CreatorAnalytics.Core.Interfaces;
using CreatorAnalytics.Infrastructure.Data;
using CreatorAnalytics.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Add support for Controllers
builder.Services.AddControllers();

// 2. Configure Entity Framework Core to use SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Tell the DI container to scan the API project and register any Validators it finds
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddScoped<IChannelRepository, ChannelRepository>();
builder.Services.AddScoped<IVideoRepository, VideoRepository>();
builder.Services.AddScoped<IVideoAnalyticRepository, VideoAnalyticRepository>();

// 3. Add OpenAPI documentation 
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

// 4. Enable Authorization middleware
app.UseAuthorization();

// 5. Tell the app to route HTTP requests to our Controller classes
app.MapControllers();

app.Run();