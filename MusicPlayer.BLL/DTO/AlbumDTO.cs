using MusicPlayer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.BLL.DTO
{
    public class AlbumDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Picture { get; set; }
        public int ArtistId { get; set; }

        public ArtistDTO Artist { get; set; }
        public ICollection<TrackDTO> Tracks { get; set; }

    }
}
