using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kolosMusic.Entities.Configurations
{
    public class MusicLableEfConfiguration : IEntityTypeConfiguration<MusicLabel>
    {
        public void Configure(EntityTypeBuilder<MusicLabel> builder)
        {
            builder.HasKey(e => e.IdMusicLabel).HasName("MusicLabel_pk");
            builder.Property(e => e.IdMusicLabel).UseIdentityColumn();

            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);



            IEnumerable<MusicLabel> MusicLabels = new List<MusicLabel>
            {
                new MusicLabel
                {
       IdMusicLabel = 1,
       Name = "Asd"
                }
            };

            builder.HasData(MusicLabels);
            builder.ToTable("MusicLabels");
        }
    }
}
