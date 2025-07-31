
using Consul;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OrderService.Extensions;
using System.Text;

namespace WheelFactoryServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            

            builder.Services.AddConsulConfig(builder.Configuration);
            // Add services to the container.
            // adding jwt token validation middlware
            //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer((options) =>
            //    {
            //        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
            //        {

            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ValidateIssuerSigningKey = true,
            //            ValidIssuer = "wheelfactory",//builder.Configuration["Jwt:issuer"],
            //            ValidAudience = builder.Configuration["Jwt:audience"],
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            //        };
            //    });
            //jwt validation ends
            builder.Services.AddControllers();
            builder.Services.AddCors();
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
            //app.UseCors(policy =>
            //{
            //    policy.AllowAnyOrigin()
            //          .AllowAnyMethod()
            //          .AllowAnyHeader();
            //});
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseConsul(builder.Configuration);
            app.MapControllers();

            app.Run();
        }
    }
}
