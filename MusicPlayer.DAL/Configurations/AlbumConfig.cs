using MusicPlayer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.DAL.Configurations
{
    internal class AlbumConfig : EntityTypeConfiguration<Album>
    {
        public AlbumConfig()
        {
            this.HasKey(e => e.Id);
            this.Property(p => p.Name).HasMaxLength(30).IsRequired();
        }
    }
}
