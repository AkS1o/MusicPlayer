using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.UI.ViewModels
{
    public class AlbumModel : ModelBase
    {
        private string name;
        private string picture;
        private ArtistModel artist;

        public int Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }
        public string Picture { get => picture; set => SetProperty(ref picture, value); }
        public ArtistModel Artist { get => artist; set => SetProperty(ref artist, value); }
    }
}
