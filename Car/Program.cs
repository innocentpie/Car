using Car.Data;
using Car.Services;
using Car.Services.Implementation.DB;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Car
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

            builder.Services.AddDbContext<WebApiDbContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("SQLite"));
                options.UseLazyLoadingProxies();
            }, ServiceLifetime.Singleton);

            builder.Services.AddSingleton<ICustomerService, CustomerServiceDB>();
            builder.Services.AddSingleton<IWorkService, WorkServiceDB>();
			builder.Services.AddSerilog(
	            config =>
		            config
			            .MinimumLevel.Information()
			            .WriteTo.Console()
			            .WriteTo.File("log.txt"));

			builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

			app.UseCors(o => o.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

			app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
