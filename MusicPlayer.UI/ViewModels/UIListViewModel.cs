using AutoMapper;
using MusicPlayer.BLL.DTO;
using MusicPlayer.BLL.Interface;
using MusicPlayer.BLL.Service;
using MusicPlayer.UI.Commands;
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
        private ITrackService trackService = new TrackService ();
        private IMapper mapper;

        private ICollection<TrackModel> tracks = new ObservableCollection<TrackModel>();
        private TrackModel selectedTrack;
        
        public UIListViewModel()
        {
            IConfigurationProvider config = new MapperConfiguration(cfg =>
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
            mapper = new Mapper(config);

        }

        public void LoadAllTracks()
        {
            var result = mapper.Map<IEnumerable<TrackModel>>(trackService.GetAllTracks());

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

    }
}
