using System;
using System.Collections.Generic;

namespace kolosMusic.Entities
{
    public class Album
    {
        public int IdAlbum { get; set; }
        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }

        public int IdMusicLabel { get; set; }
        public MusicLabel IdMusicalLabelNavigation { get; set; }

        public ICollection<Track> Tracks { get; set; }

        public Album()
        {
            this.Tracks = new HashSet<Track>();
        }
    }
}
