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
   public class UIListViewModel : ViewModelBase
    {
        private ITrackService trackService = new TrackService ();
        private IMapper mapper;

        private ICollection<TrackViewModel> tracks = new ObservableCollection<TrackViewModel>();
        private TrackViewModel selectedTrack;

        public UIListViewModel()
        {
            IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArtistDTO, ArtistViewModel>();
                cfg.CreateMap<TrackDTO, TrackViewModel>();
                cfg.CreateMap<СategoryDTO, CategoryViewModel>();

                cfg.CreateMap<ArtistViewModel, ArtistDTO>();
                cfg.CreateMap<TrackViewModel, TrackDTO>();
                cfg.CreateMap<CategoryViewModel, СategoryDTO>();
            });
            mapper = new Mapper(config);

        }

        public void LoadAllTracks()
        {
            var result = mapper.Map<IEnumerable<TrackViewModel>>(trackService.GetAllTracks());

            tracks.Clear();
            foreach (var b in result)
            {
                tracks.Add(b);
            }
        }

        // Binding Properties
        public IEnumerable<TrackViewModel> Tracks => tracks;
        public TrackViewModel SelectedTrack
        {
            get { return selectedTrack; }
            set { SetProperty(ref selectedTrack, value); }
        }

    }
}
