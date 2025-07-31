
using Microsoft.EntityFrameworkCore;
using OrderProcessService.Filters;
using OrderProcessService.Repository;
using Serilog;

namespace OrderProcessService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<OrderStagesDBContext>((options) =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("orderlocalconnstring"));
            });
            //builder.Services.AddSingleton<OrderRepo>();
            builder.Services.AddScoped<OrderStagesRepo>();
            builder.Services.AddScoped<OrderStageGetRepo>();
            builder.Services.AddControllers((options) =>{
                options.Filters.Add(new LogFilter());
            });//globla action filter
            builder.Services.AddScoped<OrderStageLogActionFilter>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularApp",
                    policy => policy.AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod());
            });
            //configuring the serilog package
            var logger = new LoggerConfiguration()
       .WriteTo
       .File(@"d:\anil\wheelfactory\wheelfactory.log", rollingInterval: RollingInterval.Day)
       .CreateLogger();
            builder.Services.AddSerilog(logger);
           
            var app = builder.Build();

            app.UseCors("AllowAngularApp");
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
