
using AutoMapper;
using MediatR;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using WebApplication1.Data;
using WebApplication1.Middlewares;
using WebApplication1.Services;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<CategoryService>();
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddScoped<GlobalErrorHandlerMiddleware>();
            builder.Services.AddScoped<Context>();
            builder.Services.AddScoped<TransactionMiddleware>();

            //builder.Logging.AddConsole();
            //builder.Logging.AddDebug();
            //builder.Logging.ClearProviders();
            
            Serilog.Log.Logger = new LoggerConfiguration()
                .Enrich.WithEnvironmentName()
                .Enrich.WithMachineName()
                .WriteTo.Seq("http://localhost:5341")
                .WriteTo.MSSqlServer(
                    connectionString: @"Data source=.\sqlexpress;initial catalog = Intake45;integrated security = true; trust server certificate = true",
                    //restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning,
                    sinkOptions: new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true }
                ).CreateLogger();

            builder.Host.UseSerilog();

            builder.Services.AddMemoryCache();

            builder.Services.AddStackExchangeRedisCache(opts =>
            {
                opts.Configuration = "redis-17821.c281.us-east-1-2.ec2.redns.redis-cloud.com:17821,User=default,Password=opG4Zy9xf6AA2UhLMzI93QPDmBAkwNgN";
                opts.InstanceName = "RedisDB";
            });
            
            builder.Services.AddMediatR(opts =>
                opts.RegisterServicesFromAssembly(typeof(Program).Assembly));

            var app = builder.Build();

            app.UseMiddleware<GlobalErrorHandlerMiddleware>();
           // app.UseMiddleware<TransactionMiddleware>();

            MapperService.Mapper = app.Services.GetService<IMapper>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}