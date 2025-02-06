using DAL.Constants;
using DAL.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class SpotifyDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<MusicEntity> Music { get; set; }
        public DbSet<UserMusicEntity> UserMusic { get; set; }
        public DbSet<AlbumEntity> Albums { get; set; }
        public DbSet<UserAlbumEntity> UserAlbums { get; set; }
        public DbSet<ArtistEntity> Artists { get; set; }
        public DbSet<UserArtistEntity> UserArtists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(AppDatabase.ConnectionString);
        }
    }
}
