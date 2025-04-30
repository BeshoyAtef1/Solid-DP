
using AutoMapper;
using Serilog;
using Serilog.Sinks.MSSqlServer;
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


            var app = builder.Build();

            app.UseMiddleware<GlobalErrorHandlerMiddleware>();
            app.UseMiddleware<TransactionMiddleware>();

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