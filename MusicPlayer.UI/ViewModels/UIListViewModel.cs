using AutoMapper;
using MusicPlayer.BLL.DTO;
using MusicPlayer.BLL.Interface;
using MusicPlayer.BLL.Service;
using MusicPlayer.UI.Commands;
using MusicPlayer.UI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicPlayer.UI.ViewModels
{
    public class UIListViewModel : ModelBase
    {
        private IMapper mapperTrack;
        private ITrackService trackService = new TrackService();
        private ICollection<TrackModel> tracks = new ObservableCollection<TrackModel>();
        private TrackModel selectedTrack;

        private IMapper mapperСategory;
        private IСategoryService сategoryService = new СategoryService();
        private ICollection<CategoryModel> categorys = new ObservableCollection<CategoryModel>();
        private CategoryModel selectedCategory;

        private IMapper mapperArtist;
        private IArtistService artistService = new ArtistService();
        private ICollection<ArtistModel> artists = new ObservableCollection<ArtistModel>();
        private ArtistModel selectedArtist;

        private IMapper mapperAlbum;
        private IAlbumService albumService = new AlbumService();
        private ICollection<AlbumModel> albums = new ObservableCollection<AlbumModel>();
        private AlbumModel selectedAlbum;

        private ICollection<MenuModel> menuItems = new ObservableCollection<MenuModel>();
        private MenuModel selectedMenuItem;

        public UIListViewModel()
        {
            IConfigurationProvider configArtist = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArtistDTO, ArtistModel>();

                cfg.CreateMap<ArtistModel, ArtistDTO>();
            });
            mapperArtist = new Mapper(configArtist);

            IConfigurationProvider configСategory = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<СategoryDTO, CategoryModel>();

                cfg.CreateMap<CategoryModel, СategoryDTO>();
            });
            mapperСategory = new Mapper(configСategory);

            IConfigurationProvider configAlbum = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AlbumDTO, AlbumModel>();

                cfg.CreateMap<AlbumModel, AlbumDTO>();
            });
            mapperAlbum = new Mapper(configAlbum);

            IConfigurationProvider configTrack = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AlbumDTO, AlbumModel>();
                cfg.CreateMap<ArtistDTO, ArtistModel>();
                cfg.CreateMap<СategoryDTO, CategoryModel>();
                cfg.CreateMap<TrackDTO, TrackModel>();

                cfg.CreateMap<AlbumModel, AlbumDTO>();
                cfg.CreateMap<ArtistModel, ArtistDTO>();
                cfg.CreateMap<CategoryModel, СategoryDTO>();
                cfg.CreateMap<TrackModel, TrackDTO>();
            });
            mapperTrack = new Mapper(configTrack);

            LoadMenu();
        }

        public void LoadAllTracks()
        {
            var result = mapperTrack.Map<IEnumerable<TrackModel>>(trackService.GetAllTracks());

            tracks.Clear();
            foreach (var b in result)
            {
                tracks.Add(b);
            }
        }

        public void LoadMenu()
        {
            menuItems.Clear();
            categorys.Clear();
            albums.Clear();
            artists.Clear();

            menuItems.Add(new MenuModel() { Name = "Artist" });
            menuItems.Add(new MenuModel() { Name = "Album" });
            menuItems.Add(new MenuModel() { Name = "Category" });
        }

        public void LoadSubMenu()
        {
            string item = selectedMenuItem.Name;

            if (item == "Category")
            {
                var result = mapperСategory.Map<IEnumerable<CategoryModel>>(сategoryService.GetAllСategorys());
                var results = result.GroupBy(x => x.Name).Select(x => x.First()).ToList();

                menuItems.Clear();
                categorys.Clear();

                foreach (var сategory in results)
                {
                    categorys.Add(new CategoryModel() { Name = сategory.Name });
                }
            }

            if (item == "Album")
            {
                var result = mapperAlbum.Map<IEnumerable<AlbumModel>>(albumService.GetAllAlbums());
                var results = result.GroupBy(x => x.Name).Select(x => x.First()).ToList();

                menuItems.Clear();
                albums.Clear();

                foreach (var albom in results)
                {
                    albums.Add(new AlbumModel() { Name = albom.Name });
                }
            }
            if (item == "Artist")
            {
                var result = mapperArtist.Map<IEnumerable<ArtistModel>>(artistService.GetAllArtists());
                var results = result.GroupBy(x => x.Name).Select(x => x.First()).ToList();

                menuItems.Clear();
                artists.Clear();

                foreach (var artis in results)
                {
                    artists.Add(new ArtistModel() { Name = artis.Name });
                }
            }
        }

        public void LoadArtistTrack()
        {
            string item = SelectedArtist.Name;

            var result = mapperTrack.Map<IEnumerable<TrackModel>>(trackService.GetAllTracks().Where(x => x.Artist.Name == item));

            tracks.Clear();
            foreach (var b in result)
            {
                tracks.Add(b);
            }
        }

        public void LoadAlbumTrack()
        {
            string item = SelectedAlbum.Name;

            var result = mapperTrack.Map<IEnumerable<TrackModel>>(trackService.GetAllTracks().Where(x => x.Album.Name == item));

            tracks.Clear();
            foreach (var b in result)
            {
                tracks.Add(b);
            }
        }

        public void LoadCategoryTrack()
        {
            string item = SelectedCategory.Name;

            var result = mapperTrack.Map<IEnumerable<TrackModel>>(trackService.GetAllTracks().Where(x => x.Category.Name == item));

            tracks.Clear();
            foreach (var b in result)
            {
                tracks.Add(b);
            }
        }

        // Binding Properties
        public IEnumerable<TrackModel> Tracks => tracks;
        public TrackModel SelectedTrack
        {     
            get { return selectedTrack; }
            set { SetProperty(ref selectedTrack, value); }
        }

        public IEnumerable<MenuModel> MenuItems => menuItems;
        public MenuModel SelectedMenuItem
        {
            get { return selectedMenuItem; }
            set { SetProperty(ref selectedMenuItem, value); }
        }

        public IEnumerable<AlbumModel> Albums => albums;
        public AlbumModel SelectedAlbum
        {
            get { return selectedAlbum; }
            set { SetProperty(ref selectedAlbum, value); }
        }

        public IEnumerable<ArtistModel> Artists => artists;
        public ArtistModel SelectedArtist
        {
            get { return selectedArtist; }
            set { SetProperty(ref selectedArtist, value); }
        }

        public IEnumerable<CategoryModel> Categorys => categorys;
        public CategoryModel SelectedCategory
        {
            get { return selectedCategory; }
            set { SetProperty(ref selectedCategory, value); }
        }
    }
}
