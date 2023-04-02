using Microsoft.AspNetCore.Localization;
using System.Globalization;
using YouTubeVideoDownloader.DAL.Context;
using Microsoft.EntityFrameworkCore;
using YouTubeVideoDownloader.DAL.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (String.IsNullOrEmpty(connectionString))
{
    throw new ArgumentNullException(nameof(connectionString), "Connection string can not be null!");
}

builder.Services.AddDbContext<DownloaderContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);
builder.Services.AddRepositoryInDB();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDeveloperExceptionPage();

CultureInfo[] supportedCultures = new CultureInfo[] { new CultureInfo("ru") };

app.UseRequestLocalization(new RequestLocalizationOptions 
{
    DefaultRequestCulture = new RequestCulture("ru"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
