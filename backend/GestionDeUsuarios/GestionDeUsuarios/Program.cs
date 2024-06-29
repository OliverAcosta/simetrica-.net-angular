
using Commons.Authentication.Token;
using DatabaseManager.Auth.Models;
using DatabaseManager.ContextEntities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GestionDeUsuarios
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var config = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json", true, false).Build();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<GestionDataContext>(options =>
            {
                options.UseOracle(config.GetConnectionString("oracle"));
               
            });
            
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            })
          .AddJwtBearer(options => {
              options.SaveToken = false;
              options.RequireHttpsMetadata = false;
              options.TokenValidationParameters = TokenUtility.TokenValidationParameters;
          });

            builder.Services.AddIdentity<AppUser, AppRoles>()
                           .AddEntityFrameworkStores<GestionDataContext>()
                           .AddDefaultTokenProviders();
            var app = builder.Build();

            
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
