using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Context
{
    public class Album
    {
        [Key]
        public int IdAlbum { get; set; }
        [Required]
        [MaxLength(30)]
        public string AlbumName { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
        [Required]
        public int IdMusicLabel { get; set; }
        public MusicLabel MusicLabel { get; set; }

        public List<Track> Tracks { get; set; } = new List<Track>();
    }
}
