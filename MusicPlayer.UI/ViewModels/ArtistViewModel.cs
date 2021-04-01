using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.UI.ViewModels
{
    public class ArtistViewModel : ViewModelBase
    {
        private string name;
        private string suname;
        private string country;

        public int Id { get; set; }

        public string Name
        {
            get => name;
            set
            {
                SetProperty(ref name, value);
                OnPropertyChanged(nameof(FullName));
            }
        }
        public string Surname
        {
            get => suname;
            set
            {
                SetProperty(ref suname, value);
                OnPropertyChanged(nameof(FullName));
            }
        }

        public string Country {get => country; set => SetProperty(ref country, value);}
        public string FullName => $"{Name} {Surname}";
        
    }
}
