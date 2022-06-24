using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Music_App_Api.Entities;
using Microsoft.Extensions.Configuration;

namespace Music_App_Api
{
    public class MusicAppDBContext : DbContext
    {
        public IConfiguration Configuration { get; }

        public MusicAppDBContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User ---------------------

            modelBuilder.Entity<User>()
                .Property(p => p.Login)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(p => p.Email)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(p => p.Password)
                .IsRequired();


            // Playlist -----------------

            modelBuilder.Entity<Playlist>()
                .Property(p => p.Name)
                .IsRequired();

            modelBuilder.Entity<Playlist>()
                .HasOne(p => p.User)
                .WithMany(u => u.Playlists)
                .HasForeignKey(k => k.UserId);

            // Song ---------------------

            modelBuilder.Entity<Song>()
                .Property(p => p.Title)
                .IsRequired();

            modelBuilder.Entity<Song>()
                .Property(p => p.Author)
                .IsRequired();

            // Genre --------------------

            modelBuilder.Entity<Genre>()
                .Property(g => g.Name)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Configuration["ConnectionStrings:ApiContext"];
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
