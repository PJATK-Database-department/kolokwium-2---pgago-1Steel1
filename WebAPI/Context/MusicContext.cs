using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Context
{
    public class MusicContext: DbContext
    {
        public MusicContext(DbContextOptions<MusicContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Musician_Track> Musicians_Tracks { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<MusicLabel> MusicLabels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musician_Track>(opt => {
                opt.HasKey(r => new { r.IdMusician, r.IdTrack });
            });

            MusicLabel label1 = new MusicLabel()
            { IdMusicLabel = 1, Name = "Rock" };
            MusicLabel label2 = new MusicLabel()
            { IdMusicLabel = 2, Name = "Classic" };

            modelBuilder.Entity<MusicLabel>().HasData(
                new MusicLabel[]{ label1, label2});

            Musician musician1 = new Musician()
            {
                IdMusician = 1,
                FirstName = "Albert",
                LastName = "Papetty",
                NickName = "Musician 1"
            };

            modelBuilder.Entity<Musician>().HasData(
                new Musician[] { musician1 });

            Album album1 = new Album()
            {
                IdAlbum = 1,
                AlbumName = "My Album",
                IdMusicLabel = 1,
                PublishDate = DateTime.Today
            };

            modelBuilder.Entity<Album>().HasData(
                new Album[] { album1 });


            Track track1_1 = new Track()
            {
                IdTrack = 1,
                TrackName = "My Alboom Track1",
                Duration = 3.5F,
                IdMusicAlbum = 1

            };

            Track track1_2 = new Track()
            {
                IdTrack = 2,
                TrackName = "My Alboom Track2",
                Duration = 5.2F,
                IdMusicAlbum = 1

            };

            Track track1_3 = new Track()
            {
                IdTrack = 3,
                TrackName = "My Alboom Track3",
                Duration = 2.9F,
                IdMusicAlbum = 1

            };

            modelBuilder.Entity<Track>().HasData(
               new Track[] { track1_1, track1_2, track1_3 });


            Musician_Track musician_track1 = new Musician_Track()
            {
                IdMusician = 1,
                IdTrack = 1
            };

            Musician_Track musician_track2 = new Musician_Track()
            {
                IdMusician = 1,
                IdTrack = 2
            };

            Musician_Track musician_track3 = new Musician_Track()
            {
                IdMusician = 1,
                IdTrack = 3
            };

            modelBuilder.Entity<Musician_Track>().HasData(
               new Musician_Track[] { musician_track1, musician_track2, musician_track3 });

        }

    }



}
