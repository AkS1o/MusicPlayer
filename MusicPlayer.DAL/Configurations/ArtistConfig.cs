using MusicPlayer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.DAL.Configurations
{
    internal class ArtistConfig : EntityTypeConfiguration<Artist>
    {
        public ArtistConfig()
        {
            this.HasKey(e => e.Id);
            this.Property(p => p.Name).HasMaxLength(30).IsRequired();
            this.Property(p => p.Suname).HasMaxLength(30).IsRequired();
            this.Property(p => p.Country).HasMaxLength(30).IsRequired();
        }
    }
}
