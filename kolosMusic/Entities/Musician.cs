using System;
using System.Collections.Generic;

namespace kolosMusic.Entities
{
    public class Musician
    {
       public int IdMusician { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }

        public ICollection<MusicianTrack> musicianTracks { get; set; }

        public Musician()
        {
            this.musicianTracks = new HashSet<MusicianTrack>();
        }
    }
}
