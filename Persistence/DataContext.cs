using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _config;

        public DataContext(
            DbContextOptions options,
            IConfiguration config) : base(options)
        {
            _config = config;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_config.GetConnectionString("DefaultConnection"));
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Activity> Activities { get; set; }
    }
}