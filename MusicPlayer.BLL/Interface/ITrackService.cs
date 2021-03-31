using MusicPlayer.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.BLL.Interface
{
    public interface ITrackService
    {
        IEnumerable<TrackDTO> GetAllTracks();
        void CreateNewTrack(TrackDTO trackDTO);
    }
}
