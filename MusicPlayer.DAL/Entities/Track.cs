using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.DAL.Entities
{
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public int AlbumId { get; set; }
        public string Duration { get; set; }
        public int NumberOfAuditions { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual Album Album { get; set; }
        public virtual ICollection<Playlist> Playlists { get; set; }
        public virtual ICollection<Сategory> categories { get; set; }
    }
}
