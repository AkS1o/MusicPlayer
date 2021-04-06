using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.UI.ViewModels
{
    public class TrackModel : ModelBase
    {
        private string name;
        private string duration;
        private int numberOfAuditions;
        private string categoryName;
        private ArtistModel artist;
        private AlbumModel album;
        private CategoryModel category;

        public int Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }
        public string Duration { get => duration; set => SetProperty(ref duration, value); }
        public int NumberOfAuditions { get => numberOfAuditions; set => SetProperty(ref numberOfAuditions, value); }
        public string CategoryName { get => categoryName; set => SetProperty(ref categoryName, value); }

        public ArtistModel Artist { get => artist; set => SetProperty(ref artist, value); }
        public AlbumModel Album { get => album; set => SetProperty(ref album, value); }
        public CategoryModel Category { get => category; set => SetProperty(ref category, value); }
    }
}
