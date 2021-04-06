using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.UI.ViewModels
{
    public class PlaylistModel : ModelBase
    {
        private string name;
        private UserModel user;

        public int Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }
        public UserModel User { get => user; set => SetProperty(ref user, value); }
    }
}
