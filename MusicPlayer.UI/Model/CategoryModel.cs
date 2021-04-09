using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.UI.ViewModels
{
    public class CategoryModel : ModelBase
    {
        public string name;

        public int Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }
    }
}
