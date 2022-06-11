using System;
using System.Collections.Generic;
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

        public async Task<bool> AddAlbum(AlbumCreateDTO albumCreateDto)
        {
            // If you want to check is "same" object exsist
            var album = await _context.Albums.AnyAsync(d => d.AlbumName == albumCreateDto.AlbumName);

            if(album)
            {
                return false;
            }

            await _context.AddAsync(new Album
            {
                AlbumName = albumCreateDto.AlbumName,
                PublishDate = albumCreateDto.PublishDate,
                IdMusicLabel = albumCreateDto.IDMusicLabel
            });
            return await _context.SaveChangesAsync() > 0;

        }



        public async Task<bool> DeleteAlbum(int IdAlbum)
        {
            var album = await _context.Albums.FirstOrDefaultAsync(e => e.IdAlbum == IdAlbum);
            if (album == null)
            {
                return false;
            }

             _context.Albums.Remove(album);
            return await _context.SaveChangesAsync() > 0;

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

        public async Task<List<AlbumDTO>> GetAlbums()
        {
            return await _context
                .Albums
                .Select(a => new AlbumDTO
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
                })
                .ToListAsync();
        }

        public async Task<bool> UpdateAlbum(AlbumCreateDTO albumCreateDTO, int IdAlbum)
        {
            var album = await _context.Albums.FirstOrDefaultAsync(e => e.IdAlbum == IdAlbum);

            if(album == null)
            {
                return false;
            }

            album.AlbumName = albumCreateDTO.AlbumName;
            album.PublishDate = albumCreateDTO.PublishDate;
            album.IdMusicLabel = albumCreateDTO.IDMusicLabel;

            return await _context.SaveChangesAsync() > 0;

        }
    }
}
