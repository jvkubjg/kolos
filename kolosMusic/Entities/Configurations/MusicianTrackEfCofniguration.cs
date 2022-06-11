using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kolosMusic.Entities.Configurations
{
    public class MusicianTrackEfCofniguration : IEntityTypeConfiguration<MusicianTrack>
    {
        public void Configure(EntityTypeBuilder<MusicianTrack> builder)
        {
            builder.HasKey(e => new { e.IdMusician, e.IdTrack }).HasName("MusicianTrack_pk");

            builder.HasOne(e => e.IdMusicianNavigation)
                .WithMany(e => e.musicianTracks)
                .HasForeignKey(e => e.IdMusician)
                .HasConstraintName("MusicianTrack_Musician")
                .OnDelete(DeleteBehavior.ClientSetNull);

           builder.HasOne(e => e.IdTrackNavigation)
                .WithMany(e => e.musicianTracks)
                .HasForeignKey(e => e.IdTrack)
                .HasConstraintName("MusicianTrack_Track")
                .OnDelete(DeleteBehavior.ClientSetNull);

            IEnumerable < MusicianTrack > musicianTracks = new List<MusicianTrack>
            {
                new MusicianTrack
                {
                    IdTrack = 1,
                    IdMusician = 1
                }
            };

            builder.HasData(musicianTracks);
            builder.ToTable("MusicianTracks"); 

        }
    }
}
