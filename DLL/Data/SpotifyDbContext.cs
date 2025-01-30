using DAL.Constants;
using DAL.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class SpotifyDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(AppDatabase.ConnectionString);
        }
    }
}
