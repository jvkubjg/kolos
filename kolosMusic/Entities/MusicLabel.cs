using System;
using System.Collections.Generic;

namespace kolosMusic.Entities
{
    public class MusicLabel
    {
       public int IdMusicLabel { get; set; }
       public string Name { get; set;  }


       public ICollection<Album> Albums { get; set; }

        public MusicLabel()
        {
            this.Albums = new HashSet<Album>();
        }

    }
}
