using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Music_App_Api.Entities;

namespace Music_App_Api
{
    public class MusicAppDBContext : DbContext
    {
        private readonly string _connectionString =
            "Server=(localdb)\\mssqllocaldb;Database=MusicAppDb;Trusted_Connection=True;";

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

            // Song ---------------------

            modelBuilder.Entity<Song>()
                .Property(p => p.Title)
                .IsRequired();

            modelBuilder.Entity<Song>()
                .Property(p => p.Author)
                .IsRequired();

            // Genre --------------------


        }
    }
}
