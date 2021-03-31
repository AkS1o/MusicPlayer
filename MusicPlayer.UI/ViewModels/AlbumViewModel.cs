using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.UI.ViewModels
{
    public class AlbumViewModel : ViewModelBase
    {
        public int Id { get; set; }
        private string name;
        private string picture;
        private int artistId;
        private ArtistViewModel artist;

        public string Name { get => name; set => SetProperty(ref name, value); }
        public string Picture { get => picture; set => SetProperty(ref picture, value); }
        public int ArtistId { get => artistId; set => SetProperty(ref artistId, value); }

        public ArtistViewModel Artist { get => artist; set => SetProperty(ref artist, value); }
    }
}
