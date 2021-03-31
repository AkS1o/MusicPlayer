using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.BLL.DTO
{
    public class СategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TrackDTO> Tracks { get; set; }
    }
}
