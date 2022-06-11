using System;
using System.Threading.Tasks;
using kolosMusic.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolosMusic.Controllers
{
    [ApiController]
    [Route("api/album")]
    public class AlbumController : ControllerBase
    {

        private readonly IAlbumService _serivce;

        public AlbumController(IAlbumService albumService)
        {
            _serivce = albumService;
        }

        [HttpGet("{IdAlbum}")]
        public async Task<IActionResult> GetAlbum([FromRoute] int IdAlbum)
        {
            var album =  await _serivce.GetAlbum(IdAlbum);

            if(album == null)
            {
               return NotFound();
            }
            return Ok(album);
        }
    }
}
