using System;
using System.ComponentModel.DataAnnotations;

namespace kolosMusic.DTO
{
    public class AlbumCreateDTO
    {
        [Required]
        public string AlbumName { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
        [Required]
        public int IDMusicLabel { get; set; }
    }
}
