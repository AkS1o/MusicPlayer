using Microsoft.WindowsAPICodePack.Dialogs;
using MusicPlayer.BLL.DTO;
using MusicPlayer.BLL.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.UI.ViewModels
{
    public class WorkWithAudoiFilesViewModel : ViewModelBase
    {
        private void Skan(string sourceDir)
        {
            Task.Run(() =>
            {
                string[] picList = Directory.GetFiles(sourceDir, "*.mp3");
                foreach (string f in picList)
                {
                    string fName = f.Substring(sourceDir.Length + 1);
                    File.Copy(Path.Combine(sourceDir, fName), Path.Combine("D:\\Music_for_project", fName), true);
                    //Meda_data_analys("D:\\Music_for_project\\" + fName);
                }
            });
        }
        public void Select_directory_for_scan_music()
        {
            string sourceDir = null;
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = @"C:\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                sourceDir = dialog.FileName;
            }
            if (sourceDir != null)
                Skan(sourceDir);
        }

        public void Meda_data_analys(string path)
        {
            TagLib.File tagFile = TagLib.File.Create(path);
            string album = tagFile.Tag.Album;
            string title = tagFile.Tag.Title;
            string[] qwe = tagFile.Tag.Artists;
            string artist = null;
            foreach (var item in qwe)
            {
                artist += item + " ";
            }
            string[] qwe2 = tagFile.Tag.Genres;
            string genres = null;
            foreach (var item in qwe2)
            {
                genres += item + " ";
            }
            TagLib.File f = TagLib.File.Create(path, TagLib.ReadStyle.Average);
            var duration = (int)f.Properties.Duration.TotalSeconds;
            var ts = TimeSpan.FromSeconds(duration);
        }
    }
}
