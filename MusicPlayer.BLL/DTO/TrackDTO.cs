using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.BLL.DTO
{
    public class TrackDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ArtistId { get; set; }
        public int? AlbumId { get; set; }
        public string Duration { get; set; }
        public int? NumberOfAuditions { get; set; }
        public int? CategoryId { get; set; }

        public ArtistDTO Artist { get; set; }
        public AlbumDTO Album { get; set; }
        public СategoryDTO Category { get; set; }
        public ICollection<PlaylistDTO> Playlists { get; set; }
        
    }
}
