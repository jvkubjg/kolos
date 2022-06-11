using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using kolosMusic.DTO;

namespace kolosMusic.Services
{
    public interface IAlbumService
    {
        Task<AlbumDTO> GetAlbum(int IdAlbum);
        Task<bool> DeleteAlbum(int IdAlbum);
        Task<bool> AddAlbum(AlbumCreateDTO albumCreateDto);
        Task<bool> UpdateAlbum(AlbumCreateDTO albumCreateDTO, int IdAlbum);
        Task<List<AlbumDTO>> GetAlbums();
    }
}
