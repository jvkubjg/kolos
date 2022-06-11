using System;
using System.Collections.Generic;

namespace kolosMusic.DTO
{
    public class AlbumDTO
    {
        public int IdAlbum { get; set; }
        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }

        public MusicLabelDTO musicLabelDTO { get; set; }

        public ICollection<TrackDTO> TracksDto { get; set; }
    }
}
