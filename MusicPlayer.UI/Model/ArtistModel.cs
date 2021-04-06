using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.UI.ViewModels
{
    public class ArtistModel : ModelBase
    {
        private string name;
        private string suname;
        private string country;

        public int Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }
        public string Surname { get => suname; set => SetProperty(ref suname, value); }
        public string Country { get => country; set => SetProperty(ref country, value); }
    }
}
