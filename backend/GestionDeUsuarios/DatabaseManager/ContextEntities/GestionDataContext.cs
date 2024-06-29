using DatabaseManager.Auth.Models;
using DatabaseManager.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace DatabaseManager.ContextEntities
{

    public class GestionDataContext: DbContext
    {
        private bool useConfig = false;
        private IConfigurationRoot config;

        public GestionDataContext()
        {
            useConfig = true;
            config = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json", true, false).Build();
        }
      
        public GestionDataContext(DbContextOptions<GestionDataContext> options) : base(options){ }

        public DbSet<UserTodos> UserTodos { get; set; }
        public DbSet<Users> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(useConfig)
            optionsBuilder.UseOracle(config.GetConnectionString("oracle"));
            base.OnConfiguring(optionsBuilder);
           
        }


    }
}
