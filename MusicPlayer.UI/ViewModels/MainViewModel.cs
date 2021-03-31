using Microsoft.WindowsAPICodePack.Dialogs;
using MusicPlayer.UI.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicPlayer.UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        WorkWithAudoiFilesViewModel workWithAudoiFilesViewModel = new WorkWithAudoiFilesViewModel();
        public ICommand Select_dir_for_scan => select_dir_for_scan;
        private Command select_dir_for_scan;

        public MainViewModel()
        {
            select_dir_for_scan = new DelegateCommand(workWithAudoiFilesViewModel.Select_directory_for_scan_music);
        }
    }
}
