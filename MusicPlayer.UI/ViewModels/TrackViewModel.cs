using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.UI.ViewModels
{
    public class TrackViewModel : ViewModelBase
    {
        private string name;
        private string duration;
        private int numberOfAuditions;
        private string categoryName;
        private ArtistViewModel artist;
        private AlbumViewModel album;

        public int Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }
        public string Duration { get => duration; set => SetProperty(ref duration, value); }
        public int NumberOfAuditions { get => numberOfAuditions; set => SetProperty(ref numberOfAuditions, value); }
        public string CategoryName { get => categoryName; set => SetProperty(ref categoryName, value); }

        public ArtistViewModel Artist { get => artist; set => SetProperty(ref artist, value); }
        public AlbumViewModel Album { get => album; set => SetProperty(ref album, value); }
    }
}
