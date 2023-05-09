using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Context
{
    public class Track
    {
        [Key]
        public int IdTrack { get; set; }
        [MaxLength(20)]
        [Required]
        public string TrackName { get; set; }
        [Required]
        public float Duration { get; set; }
        
        public int? IdMusicAlbum { get; set; }
        Album MusicAlbum { get; set; }

        public List<Musician_Track> Musicians_Tracks { get; set; } = new List<Musician_Track>();
    }
}
