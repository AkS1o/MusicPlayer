using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.DAL.Entities
{
    public class Сategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
