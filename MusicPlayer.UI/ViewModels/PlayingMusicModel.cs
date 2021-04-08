using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MusicPlayer.UI.ViewModels
{
    public class PlayingMusicModel : ModelBase
    {
        public PlayingMusicModel()
        {
            mediaElement.LoadedBehavior = MediaState.Pause;
        }
        private MediaElement mediaElement = new MediaElement();
        public MediaElement MediaElement { get => mediaElement; set => SetProperty(ref mediaElement, value); }
        private Uri music;
        public Uri Music { get => music; set => SetProperty(ref music, value); }
        private bool Isplay = true;
        private string Isplayingmusic;
        public void PlayMusic()
        {
            if (selectedTrack != null && Isplayingmusic != selectedTrack.Name) { Isplay = true; }
            if (Isplay)
            {
                if (selectedTrack != null && Isplayingmusic != selectedTrack.Name)
                {
                    mediaElement.Source = new Uri($"C:\\Users\\Kolotyuk\\Desktop\\song\\{selectedTrack.Name}.mp3", UriKind.Absolute);
                    Isplayingmusic = selectedTrack.Name;
                }
                mediaElement.LoadedBehavior = MediaState.Play;
                Isplay = false;
            }
            else
            {
                Isplay = true;
                mediaElement.LoadedBehavior = MediaState.Pause;
            }


        }
        public void StartOverSong()
        {
            if (Isplay != true)
            {
                mediaElement.LoadedBehavior = MediaState.Stop;
                mediaElement.LoadedBehavior = MediaState.Play;
            }
        }

        private TrackModel selectedTrack;

        public TrackModel SelectedTrack
        {
            get { return selectedTrack; }
            set { SetProperty(ref selectedTrack, value); }
        }

        private int selectedTrackindex;
        public int SelectedTrackindex { get => selectedTrackindex; set => SetProperty(ref selectedTrackindex, value); }
        private int IndexMusic;

        public void OnesongAhead()
        {
            IndexMusic = SelectedTrackindex += 1;
            SelectedTrack = null;
            SelectedTrackindex = IndexMusic;
            if (selectedTrack == null)
            {
                IndexMusic = SelectedTrackindex -= 1;
                SelectedTrack = null;
                SelectedTrackindex = IndexMusic;
                Isplay = true;
            }
            PlayMusic();
        }
        public void OnesongBack()
        {
            if (SelectedTrackindex - 1 >= 0)
            {
                IndexMusic = SelectedTrackindex -= 1;
                SelectedTrack = null;
                SelectedTrackindex = IndexMusic;
                PlayMusic();
            }
        }

        public void Randomsong()
        {
            Random random = new Random();
            IndexMusic = random.Next(0, SelectedTrackindex);
            SelectedTrack = null;
            SelectedTrackindex = IndexMusic;
            PlayMusic();
        }

    }
}
