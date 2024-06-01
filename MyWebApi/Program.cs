using MyWebApi.Configuration;
using MyWebApi.Extensions;
using MyWebApi.Services;
using MyWebApi.Services.LoggerService.Concrete.FileLogger;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine(builder.Environment.ContentRootPath);

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("MongoDatabase"));
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped(typeof(IDatabaseService<>), typeof(MongoService<>));
builder.Services.AddLoggerService(cfg =>
{
    cfg.AddConsoleLogger();
    cfg.AddFileLogger(() => new FileLoggerConfiguration
    {
        Path = builder.Environment.ContentRootPath
    });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
