using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Context
{
    public class Musician_Track
    {
        
        [Key]
        [Required]
        public int IdTrack { get; set; }
        public Track Track { get; set; }
        
        [Key]
        [Required]
        public int IdMusician { get; set; }
        public Musician Musician { get; set; }

    }
}
