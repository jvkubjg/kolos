using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using kolosMusic.DTO;
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
            var album = await _serivce.GetAlbum(IdAlbum);

            if (album == null)
            {
                return NotFound();
            }
            return Ok(album);
        }

        [HttpPost]
        public async Task<IActionResult> PostAlbum([FromBody] AlbumCreateDTO albumCreateDto)
        {
            var isAlbumAdded = await _serivce.AddAlbum(albumCreateDto);

            if (!isAlbumAdded)
            {
                return BadRequest("Album cannot be added");
            }

            return StatusCode((int)HttpStatusCode.Created);

        }

        [HttpPut("{IdAlbum}")]
        public async Task<IActionResult> PutAlbum([FromRoute] int IdAlbum, [FromBody] AlbumCreateDTO albumCreateDto)
        {
            var isAlbumUpdated = await _serivce.UpdateAlbum(albumCreateDto, IdAlbum);
            if (!isAlbumUpdated)
            {
                return NotFound("Doctor cannot be updated");
            }

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAlbumsList()
        {
            IList<AlbumDTO> result = await _serivce.GetAlbums();

            return Ok(result);
        }

        [HttpDelete("{IdAlbum}")]
        public async Task<IActionResult> DeleteAlbum([FromRoute] int IdAlbum)
        {
            var doctor = await _serivce.DeleteAlbum(IdAlbum);

            if (!doctor)
            {
                return NotFound("Not found this album");
            }

            return NoContent();
        }


    }
}

