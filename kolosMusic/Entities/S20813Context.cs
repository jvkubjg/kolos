using System;
using System.Collections.Generic;
using System.Reflection;
using kolosMusic.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace kolosMusic.Entities
{
    public class S20813Context : DbContext
    {
        public S20813Context(DbContextOptions<S20813Context> options) : base(options)
        {
        }

        protected S20813Context()
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Musician> Musicians { get; set; }
        public virtual DbSet<MusicianTrack> MusicianTracks { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<MusicLabel> MusicLabels { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(AlbumEfConfiguration).GetTypeInfo().Assembly);
        }
    }
}
