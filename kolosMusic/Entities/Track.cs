using System;
using System.Collections.Generic;

namespace kolosMusic.Entities
{
    public class Track
    {
        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public float Duration { get; set; }

        public int IdAlbum { get; set; }
        public Album IdAlbumNavigation { get; set; }

        public ICollection<MusicianTrack> musicianTracks { get; set; }

        public Track()
        {
            this.musicianTracks = new HashSet<MusicianTrack>();
        }
    }
}
