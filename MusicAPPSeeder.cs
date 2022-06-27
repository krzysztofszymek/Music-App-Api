using Music_App_Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_App_Api
{
    public class MusicAPPSeeder
    {
        private readonly MusicAppDBContext _dbContext;

        public MusicAPPSeeder(MusicAppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Users.Any())
                {
                    var genres = GetGenres();
                    _dbContext.Genres.AddRange(genres);

                    var songs = GetSongs(genres);


                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<User> GetUsers()
        {
            var users = new List<User>()
            {
                new User() {
                    Login = "Test",
                    Email = "test@test.com",
                    Password = "test123"
                }
            };
            return users;
        }

        private IEnumerable<Song> GetSongs(IEnumerable<Genre> genres)
        {
            var songs = new List<Song>(){
                new Song()
                {
                    Title = "New Song",
                    Author = "New Author",
                    ReleaseDate = new DateTime(1, 1, 2020),
                    Genres = 
                }
            }
            return songs;
        }

        private IEnumerable<Genre> GetGenres()
        {
            var genres = new List<Genre>()
            {
                new Genre(){ Name = "Pop" },
                new Genre(){ Name = "Rock" },
                new Genre(){ Name = "Jazz" },
                new Genre(){ Name = "Vocals" },
                new Genre(){ Name = "Dubstep" }
            };
            return genres;
        }
    }
}
