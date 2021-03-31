using MusicPlayer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.BLL.DTO
{
    public class ArtistDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Suname { get; set; }
        public string Country { get; set; }
        public ICollection<AlbumDTO> Albums { get; set; }
        public ICollection<TrackDTO> Tracks { get; set; }
    }
}
