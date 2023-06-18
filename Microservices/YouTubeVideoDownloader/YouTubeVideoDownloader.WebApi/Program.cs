using Gurrex.Web.SignalR.Hubs.Async;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using System.Globalization;
using YouTubeVideoDownloader.DAL.Context;
using YouTubeVideoDownloader.Registrators;
using YouTubeVideoDownloader.WebApi.ConfigurationSettings;
using YouTubeVideoDownloader.YouTubeDataOperations.Services.Registrator;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("Init main");
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddLocalization(options => options.ResourcesPath = "ManagerResources");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();


string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (String.IsNullOrEmpty(connectionString))
{
    throw new ArgumentNullException(nameof(connectionString), "Connection string can not be null!");
}

builder.Services.AddDbContext<DownloaderContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);

builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Trace);
builder.Host.UseNLog();

builder.Services.Configure<ServerSettings>(
    builder.Configuration.GetSection("ServerSettings")
);
builder.Services.AddUnitOfWork();
builder.Services.AddDownloaderServices();

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

app.MapHub<SenderInfoHubAsync>("/statusInfo");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
