using MusicPlayer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.DAL.Configurations
{
    internal class PlaylistConfig : EntityTypeConfiguration<Playlist>
    {
        public PlaylistConfig()
        {
            this.HasKey(e => e.Id);
            this.Property(p => p.Name).HasMaxLength(30).IsRequired();
        }
    }
}
