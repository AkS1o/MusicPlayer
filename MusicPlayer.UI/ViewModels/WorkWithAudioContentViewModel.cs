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
        private IAlbumService albumService = new AlbumService();
        private ICollection<AlbumModel> albums = new ObservableCollection<AlbumModel>();
        private IMapper mapper;
        public WorkWithAudoiFilesViewModel()
        {
            IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArtistDTO, ArtistModel>();
                cfg.CreateMap<TrackDTO, TrackModel>();
                cfg.CreateMap<СategoryDTO, CategoryModel>();
                cfg.CreateMap<AlbumDTO, AlbumModel>();

                cfg.CreateMap<ArtistModel, ArtistDTO>();
                cfg.CreateMap<TrackModel, TrackDTO>();
                cfg.CreateMap<CategoryModel, СategoryDTO>();
                cfg.CreateMap<AlbumModel, AlbumDTO>();
            });
            mapper = new Mapper(config);
     
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

        public void LoadAllAlboms()
        {
            var result = mapper.Map<IEnumerable<AlbumModel>>(albumService.GetAllAlbums());

            albums.Clear();
            foreach (var b in result)
            {
                albums.Add(b);
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
                    Meda_data_analys("D:\\Music_for_project\\" + fName,fName);
                }
            });
        }
        public void Select_directory_for_scan_music()
        {
            LoadAllArtists();
            LoadAllCategorys();
            LoadAllAlboms();
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

        public void Meda_data_analys(string path, string trackName)
        {
            int? categocyId = null;
            int? artistId = null;
            int? albomId = null;

            bool isNewCategory = true;
            bool isNewArtist = true;
            bool isNewAlbom = true;

            bool isTrackHaveArtist = true;
            bool isTrackHaveCategory = true;
            bool isTrackHaveAlbom = true;

            AlbumModel albumViewModel = new AlbumModel();
            ArtistModel artistViewModel = new ArtistModel();
            CategoryModel categoryViewModel = new CategoryModel();

            СategoryDTO categoryDTO = new СategoryDTO();
            AlbumDTO albumDTO = new AlbumDTO();
            ArtistDTO artistDTO = new ArtistDTO();
            TrackDTO trackDTO = new TrackDTO();

            TagLib.File tagFile = TagLib.File.Create(path);
            string album = tagFile.Tag.Album;
            //string title = tagFile.Tag.Title;
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

            if (artist == null || artist == "")
            {
                isTrackHaveArtist = false;
                artist = "No artist";
            }
            else
            {
                artistDTO = new ArtistDTO();
                artistDTO.Name = artist;
                artistService.CreateNewArtist(artistDTO);
                ArtistModel result = mapper.Map<ArtistModel>(artistDTO);
                artists.Add(result);
            }
            if (genres == null || genres == "")
            {
                isTrackHaveCategory = false;
                genres = "No category";
            }
            else
            {
                categoryDTO = new СategoryDTO();
                categoryDTO.Name = genres;
                сategoryService.CreateNewСategory(categoryDTO);
                CategoryModel result = mapper.Map<CategoryModel>(categoryDTO);
                categorys.Add(result);

            }
            if (album == null || album == "")
            {
                isTrackHaveAlbom = false;
                album = "No album";
            }
            else
            {
                albumDTO = new AlbumDTO();
                albumDTO.Name = album;
                albumService.CreateNewAlbum(albumDTO);
                AlbumModel result = mapper.Map<AlbumModel>(albumDTO);
                albums.Add(result);
            }

            foreach (CategoryModel item in categorys)
            {
                if (item.Name == genres)
                {
                    isNewCategory = false;
                    categoryViewModel = item;
                    categocyId = item.Id;
                }
            }

            foreach (ArtistModel item in artists)
            {
                if (item.Name == artist)
                {
                    isNewArtist = false;
                    artistViewModel = item;
                    artistId = item.Id;
                }
            }

            foreach (AlbumModel item in albums)
            {
                if (item.Name == album)
                {
                    isNewAlbom = false;
                    albumViewModel = item;
                    albomId = item.Id;
                }
            }

            trackDTO.Duration = new TimeSpan(ts.Hours, ts.Minutes, ts.Seconds).ToString();
            trackName = trackName.Remove(trackName.Length - 4);
            trackDTO.Name = trackName;
            if (isNewCategory == false)
            {
                СategoryDTO result = mapper.Map<СategoryDTO>(categoryViewModel);
                trackDTO.Category = result;
                trackDTO.CategoryId = categocyId;
            }
            else
            {
                //categoryDTO = new СategoryDTO();
                //categoryDTO.Name = genres;
                //сategoryService.CreateNewСategory(categoryDTO);
                trackDTO.Category = categoryDTO;
                trackDTO.CategoryId = categoryDTO.Id;
            }
            if (isNewAlbom == false)
            {
                AlbumDTO result = mapper.Map<AlbumDTO>(albumViewModel);
                trackDTO.Album = result;
                trackDTO.AlbumId = albomId;
            }
            else
            {
                //albumDTO = new AlbumDTO();
                //albumDTO.Name = album;
                //albumService.CreateNewAlbum(albumDTO);
                trackDTO.Album = albumDTO;
                trackDTO.AlbumId = albumDTO.Id;
            }
            if (isNewArtist == false)
            {
                ArtistDTO result = mapper.Map<ArtistDTO>(artistViewModel);
                trackDTO.Artist = result;
                trackDTO.ArtistId = artistId;
            }
            else
            {
                //artistDTO = new ArtistDTO();
                //artistDTO.Name = artist;
                //artistService.CreateNewArtist(artistDTO);
                trackDTO.Artist = artistDTO;
                trackDTO.ArtistId = artistDTO.Id;
            }
            trackService.CreateNewTrack(trackDTO);

            //categoryDTO.Tracks.Add(trackDTO);
            //сategoryService.UpdateCategory(categoryDTO);
            //сategoryService.SaveCategory();
            //artistDTO.Tracks.Add(trackDTO);
            //artistService.UpdateArtist(artistDTO);
            //artistService.SaveArtist();
            //albumDTO.Tracks.Add(trackDTO);
            //albumService.UpdateAlbum(albumDTO);
            //albumService.SaveAlbum();
            //artistDTO.Albums.Add(albumDTO);
            //artistService.UpdateArtist(artistDTO);
            //artistService.SaveArtist();
            //albumDTO.Artist = artistDTO;
            //albumService.UpdateAlbum(albumDTO);
            //albumService.SaveAlbum();
        }
    }
}
