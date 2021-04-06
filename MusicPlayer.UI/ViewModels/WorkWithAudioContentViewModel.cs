using AutoMapper;
using Microsoft.WindowsAPICodePack.Dialogs;
using MusicPlayer.BLL.DTO;
using MusicPlayer.BLL.Interface;
using MusicPlayer.BLL.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MusicPlayer.UI.ViewModels
{
    public class WorkWithAudoiFilesViewModel : ModelBase
    {
        private ITrackService trackService = new TrackService();
        private IСategoryService сategoryService = new СategoryService();
        private ICollection<CategoryModel> categorys = new ObservableCollection<CategoryModel>();
        private IArtistService artistService = new ArtistService();
        private ICollection<ArtistModel> artists = new ObservableCollection<ArtistModel>();
        private IMapper mapper;
        public WorkWithAudoiFilesViewModel()
        {
            IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArtistDTO, ArtistModel>();
                cfg.CreateMap<TrackDTO, TrackModel>();
                cfg.CreateMap<СategoryDTO, CategoryModel>();

                cfg.CreateMap<ArtistModel, ArtistDTO>();
                cfg.CreateMap<TrackModel, TrackDTO>();
                cfg.CreateMap<CategoryModel, СategoryDTO>();
            });
            mapper = new Mapper(config);

            //LoadAllArtists();
            //LoadAllCategorys();
        }
        public void LoadAllArtists()
        {
            var result = mapper.Map<IEnumerable<ArtistModel>>(artistService.GetAllArtists());

            artists.Clear();
            foreach (var b in result)
            {
                artists.Add(b);
            }
        }

        public void LoadAllCategorys()
        {
            var result = mapper.Map<IEnumerable<CategoryModel>>(сategoryService.GetAllСategorys());

            categorys.Clear();
            foreach (var b in result)
            {
                categorys.Add(b);
            }
        }
        private void Skan(string sourceDir)
        {
            Task.Run(() =>
            {
                string[] picList = Directory.GetFiles(sourceDir, "*.mp3");
                foreach (string f in picList)
                {
                    string fName = f.Substring(sourceDir.Length + 1);
                    File.Copy(Path.Combine(sourceDir, fName), Path.Combine("D:\\Music_for_project", fName), true);
                    Meda_data_analys("D:\\Music_for_project\\" + fName);
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

            //int? categoryId = null;
            //foreach (var item in categorys)
            //{
            //    if (item.Name == genres)
            //        categoryId = item.Id;
            //}

            //int? artistId = null;
            //foreach (var item in artists)
            //{
            //    if (item.Name == artist)
            //        artistId = item.Id;
            //}

            TrackDTO trackDTO = new TrackDTO();
            trackDTO.Duration = new TimeSpan(ts.Hours, ts.Minutes, ts.Seconds).ToString();
            trackDTO.Name = title;
            //trackDTO.ArtistId = artistId;
            //trackDTO.Artist = new ArtistDTO(){Name = artist};
            //trackDTO.Album = new AlbumDTO() { Name = album };
            //trackDTO.Categories.Add(new СategoryDTO() {Name = genres });
            trackService.CreateNewTrack(trackDTO);
        }
    }
}
