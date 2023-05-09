using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Context;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AlbumsController : ControllerBase
    {

        private readonly ILogger<AlbumsController> _logger;
        private readonly MusicContext _ctx;

        public AlbumsController(ILogger<AlbumsController> logger, MusicContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        [HttpGet]
        public IEnumerable<Album> Get()
        {            
            return _ctx.Albums.ToList();
        }


        [HttpGet("{id}")]
        public ActionResult<Album> Get(int id)
        {

            Album album= _ctx.Albums.FirstOrDefault(al=>al.IdAlbum==id);
            album.Tracks = _ctx.Tracks.Where(tr => tr.IdMusicAlbum == id).OrderBy(tr => tr.Duration).ToList();

            if (album == null) return NotFound();
            else return album;            
        }

    }
}
