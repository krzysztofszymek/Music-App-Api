using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_App_Api.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Song> Songs { get; set; }
    }
}
