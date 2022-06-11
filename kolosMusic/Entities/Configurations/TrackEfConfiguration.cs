using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kolosMusic.Entities.Configurations
{
    public class TrackEfConfiguration : IEntityTypeConfiguration<Track>
    {
     

        public void Configure(EntityTypeBuilder<Track> builder)
        {
            builder.HasKey(e => e.IdTrack).HasName("Track_pk");
            builder.Property(e => e.IdTrack).UseIdentityColumn();


            builder.Property(e => e.TrackName).IsRequired().HasMaxLength(20);
            builder.Property(e => e.Duration).IsRequired();


            builder.HasOne(e => e.IdAlbumNavigation)
                 .WithMany(e => e.Tracks)
                 .HasForeignKey(e => e.IdAlbum)
                 .HasConstraintName("IdMusicAlbum_fk")
                 .OnDelete(DeleteBehavior.ClientSetNull);

            IEnumerable<Track> Tracks = new List<Track>
            {
                new Track
                {
                    IdTrack = 1,
                    TrackName = "Name",
                    Duration = 1.1f,
                    IdAlbum = 1
                },
                 new Track
                {
                    IdTrack = 2,
                    TrackName = "Name",
                    Duration = 1.9f
                },

            };

            builder.HasData(Tracks);
            builder.ToTable("Tracks");

        }
    }
}
