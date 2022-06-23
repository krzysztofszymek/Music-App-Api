using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_App_Api.Entities
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual User User { get; set; }
        public List<Song> Songs { get; set; }
    }
}
