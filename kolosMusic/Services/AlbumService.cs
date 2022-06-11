using System;
using System.Linq;
using System.Threading.Tasks;
using kolosMusic.DTO;
using kolosMusic.Entities;
using Microsoft.EntityFrameworkCore;

namespace kolosMusic.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly S20813Context _context;

        public AlbumService(S20813Context context)
        {
            _context = context;
        }

        public async Task<AlbumDTO> GetAlbum(int IdAlbum)
        {
            return await _context.Albums.Select(a => new AlbumDTO
            {
                IdAlbum = a.IdAlbum,
                AlbumName = a.AlbumName,
                PublishDate = a.PublishDate,

                musicLabelDTO = new MusicLabelDTO
                {
                    Name = a.IdMusicalLabelNavigation.Name,
                    IdMusicLabel = a.IdMusicalLabelNavigation.IdMusicLabel
                },

                TracksDto = a.Tracks.Select(t => new TrackDTO
                {
                    TrackId = t.IdTrack,
                    TrackName = t.TrackName,
                    Duration = t.Duration
                }).OrderBy(e => e.Duration).ToList()

            }).FirstOrDefaultAsync(a => a.IdAlbum == IdAlbum);


        }
    }
}
