﻿using AutoMapper;
using Microsoft.WindowsAPICodePack.Dialogs;
using MusicPlayer.BLL.DTO;
using MusicPlayer.BLL.Interface;
using MusicPlayer.BLL.Service;
using MusicPlayer.UI.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private Command loadTracksCmd;
        //private UIListViewModel uilistViewModel = new UIListViewModel();

        public ICommand LoadTracksCmd => loadTracksCmd;
        public MainViewModel()
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

            loadTracksCmd = new DelegateCommand(LoadAllTracks);
            select_dir_for_scan = new DelegateCommand(workWithAudoiFilesViewModel.Select_directory_for_scan_music);
        }

        private ITrackService trackService = new TrackService();
        private IMapper mapper;

        private ICollection<TrackViewModel> tracks = new ObservableCollection<TrackViewModel>();
        private TrackViewModel selectedTrack;

       

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
