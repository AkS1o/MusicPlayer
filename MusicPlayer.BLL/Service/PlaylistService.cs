using AutoMapper;
using MusicPlayer.BLL.DTO;
using MusicPlayer.BLL.Interface;
using MusicPlayer.DAL.Entities;
using MusicPlayer.DAL.Interfaces;
using MusicPlayer.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.BLL.Service
{
    public class PlaylistService : IPlaylistService
    {
        private IUnitOfWork repositories;
        private IMapper mapper;
        public PlaylistService()
        {
            this.repositories = new UnitOfWork();

            IConfigurationProvider config = new MapperConfiguration(
                cfg =>
                {
                    // Entity to DTO
                    cfg.CreateMap<Playlist, PlaylistDTO>();

                    // DTO to Entity
                    cfg.CreateMap<PlaylistDTO, Playlist>();
                });

            mapper = new Mapper(config);
        }

        // Public Service Interface
        public IEnumerable<PlaylistDTO> GetAllPlaylists()
        {
            var result = repositories.PlaylistRepos.Get(includeProperties: $"{nameof(Playlist.User)}");
            return mapper.Map<IEnumerable<PlaylistDTO>>(result);
        }

        public void CreateNewPlaylist(PlaylistDTO playlistDTO)
        {
            repositories.PlaylistRepos.Insert(mapper.Map<Playlist>(playlistDTO));
            repositories.Save();
        }
    }
}
