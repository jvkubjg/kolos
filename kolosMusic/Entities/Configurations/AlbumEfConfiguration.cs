using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kolosMusic.Entities.Configurations
{
    public class AlbumEfConfiguration : IEntityTypeConfiguration<Album>
    {

        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasKey(e => e.IdAlbum).HasName("Album_pk");
            builder.Property(e => e.IdAlbum).UseIdentityColumn();


            builder.Property(e => e.AlbumName).IsRequired().HasMaxLength(30);
            builder.Property(e => e.PublishDate).IsRequired();
           


            builder.HasOne(e => e.IdMusicalLabelNavigation)
                 .WithMany(e => e.Albums)
                 .HasForeignKey(e => e.IdMusicLabel)
                 .HasConstraintName("IdMusicLabel_fk")
                 .OnDelete(DeleteBehavior.ClientSetNull);


            IEnumerable<Album> Albums = new List<Album>
            {
                new Album
                {

                    IdAlbum = 1,
                    AlbumName = "Name",
                    PublishDate = DateTime.Parse("1999-02-02"),
                    IdMusicLabel = 1
                }
          
            };

            builder.HasData(Albums);
            builder.ToTable("Albums");
        }
    }
}
