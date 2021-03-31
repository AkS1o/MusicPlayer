using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.UI.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        public int Id { get; set; }
        private string name;
        private string password;
        private string email;
        private string picture;
        private string wayToSongs;

        public string Name { get => name; set => SetProperty(ref name, value); }
        public string Password { get => password; set => SetProperty(ref password, value); }
        public string Email { get => email; set => SetProperty(ref email, value); }
        public string Picture { get => picture; set => SetProperty(ref picture, value); }
        public string WayToSongs { get => wayToSongs; set => SetProperty(ref wayToSongs, value); }
    }
}
