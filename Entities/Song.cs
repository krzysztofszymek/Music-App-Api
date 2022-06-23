﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music_App_Api.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public virtual Playlist Playlist { get; set; }
        public virtual List<Genre> Genres { get; set; }
    }
}