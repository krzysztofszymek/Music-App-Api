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
                    _dbContext.Songs.AddRange(songs);

                    //var playlists = GetPlaylists(songs);
                    //_dbContext.Playlists.AddRange(playlists);

                    var users = GetUsers();
                    _dbContext.Users.AddRange(users);

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
                    Password = "test123",
                    Playlists = new List<Playlist>()
                }
            };
            return users;
        }

        //private IEnumerable<Playlist> GetPlaylists(IEnumerable<Song> songs)
        //{
        //    var playlists = new List<Playlist>()
        //    {
        //        new Playlist()
        //        {
        //            Name = "Test Playlist",
        //            UserId = 1,
        //            Songs = new List<Song>()
        //            {
        //                songs.ElementAt(0)
        //            }
        //        }
        //    };
        //    return playlists;
        //}

        private IEnumerable<Song> GetSongs(IEnumerable<Genre> genres)
        {
            var songs = new List<Song>(){
                new Song()
                {
                    Title = "New Song",
                    Author = "New Author",
                    ReleaseDate = DateTime.Now,
                    Genres = new List<Genre>()
                    {
                        genres.ElementAt(4),
                        genres.ElementAt(3)
                    }
                }
            };
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
