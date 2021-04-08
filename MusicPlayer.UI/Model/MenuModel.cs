using MusicPlayer.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.UI.Model
{
    public class MenuModel : ModelBase
    {
        private string name;

        public string Name { get => name; set => SetProperty(ref name, value); }
    }
}
