
using UserService.Model;
using UserService.Repository;
using Microsoft.EntityFrameworkCore;
namespace UserService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string constring = builder.Configuration.GetConnectionString("userdbconnstring");
            builder.Services.AddControllers();
            builder.Services.AddScoped<IUserRepository,UserRepository>();
            builder.Services.AddDbContext<UserContext>((options) =>
            {
                 options.UseSqlServer(constring);
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
