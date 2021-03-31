using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.UI.ViewModels
{
    public class PlaylistViewModel : ViewModelBase
    {
        public int Id { get; set; }
        private string name;
        private int userId;
        private UserViewModel user;

        public string Name { get => name; set => SetProperty(ref name, value); }
        public int UserId { get => userId; set => SetProperty(ref userId, value); }
        public UserViewModel User { get => user; set => SetProperty(ref user, value); }
    }
}
