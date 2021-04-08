using AutoMapper;
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
    public class MainViewModel : ModelBase
    {
        WorkWithAudoiFilesViewModel workWithAudoiFilesViewModel = new WorkWithAudoiFilesViewModel();    
        public ICommand Select_dir_for_scan => select_dir_for_scan;
        private Command select_dir_for_scan;
        private Command loadTracksCmd;
        public UIListViewModel uilistViewModel { get; } = new UIListViewModel();
        public RegistrationViewModel registrationViewModel { get; } = new RegistrationViewModel();
        public AutorizationViewModel autorizationViewModel { get; } = new AutorizationViewModel();
        public PlayingMusicModel playingMusicModel { get; } = new PlayingMusicModel();

        public ICommand LoadTracksCmd => loadTracksCmd;

        private Command openTheRegistrationWindow;
        public ICommand OpenTheRegistrationWindow => openTheRegistrationWindow;

        private Command wayToPictureCommand;
        public ICommand WayToPictureCommand => wayToPictureCommand;

        private Command wayToMusicCommand;
        public ICommand WayToMusicCommand => wayToMusicCommand;

        private Command addUserCommand;
        public ICommand AddUserCommand => addUserCommand;

        private Command openTheAutorizationWindow;
        public ICommand OpenTheAutorizationWindow => openTheAutorizationWindow;
       
        private Command loginUserCommand;
        public ICommand LoginUserCommand => loginUserCommand;

        private Command playmusic;
        public ICommand Playmusic => playmusic;

        private Command startOverSong;
        public ICommand StartOverSong => startOverSong;

        private Command onesongAhead;
        public ICommand OnesongAhead => onesongAhead;

        private Command onesongBack;
        public ICommand OnesongBack => onesongBack;

        private Command randomsong;
        public ICommand Randomsong => randomsong;

        public MainViewModel()
        {
            
            loadTracksCmd = new DelegateCommand(uilistViewModel.LoadAllTracks);
            select_dir_for_scan = new DelegateCommand(workWithAudoiFilesViewModel.Select_directory_for_scan_music);
            openTheRegistrationWindow = new DelegateCommand(registrationViewModel.OpenTheRegistrationWindow);
            wayToPictureCommand = new DelegateCommand(registrationViewModel.SelectDirectoryForwayToPicture);
            wayToMusicCommand = new DelegateCommand(registrationViewModel.SelectDirectoryForWayToMusic);
            addUserCommand = new DelegateCommand(registrationViewModel.СreatingAUser);
            openTheAutorizationWindow = new DelegateCommand(registrationViewModel.OpenTheAutorizationWindow);
            loginUserCommand = new DelegateCommand(autorizationViewModel.LoginUser);
            playmusic = new DelegateCommand(playingMusicModel.PlayMusic);
            startOverSong = new DelegateCommand(playingMusicModel.StartOverSong);
            onesongAhead = new DelegateCommand(playingMusicModel.OnesongAhead);
            onesongBack = new DelegateCommand(playingMusicModel.OnesongBack);
            randomsong = new DelegateCommand(playingMusicModel.Randomsong);
        }

      
    }
}
