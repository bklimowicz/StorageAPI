using Microsoft.EntityFrameworkCore;
using MyWebApi.Configuration;
using MyWebApi.DataAccess;
using MyWebApi.Extensions;
using MyWebApi.Hubs;
using MyWebApi.Services;
using MyWebApi.Services.LoggerService.Concrete.FileLogger;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine(builder.Environment.ContentRootPath);

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("MongoDatabase"));
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped(typeof(IDatabaseService<>), typeof(MongoService<>));
builder.Services.AddDbContext<LogsContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("TestDb")));
builder.Services.AddLoggerService(cfg =>
{
    cfg.AddConsoleLogger();
    cfg.AddFileLogger(() => new FileLoggerConfiguration
    {
        Path = builder.Environment.ContentRootPath
    });
    cfg.AddDatabaseLogger(builder.Services.BuildServiceProvider().GetService<LogsContext>()!);
});
builder.Services.AddSignalR(options => { options.MaximumParallelInvocationsPerClient = 1; });
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

app.MapHub<TestHub>("/maphub");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.MapControllers();

app.Run();