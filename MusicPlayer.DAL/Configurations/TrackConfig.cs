using MusicPlayer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.DAL.Configurations
{
    internal class TrackConfig : EntityTypeConfiguration<Track>
    {
        public TrackConfig()
        {
            this.HasKey(e => e.Id);
            this.Property(p => p.Name).HasMaxLength(30).IsRequired();
            this.Property(p => p.Duration).HasMaxLength(30).IsRequired();
        }
    }
}
