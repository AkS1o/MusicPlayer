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
    public class TrackService : ITrackService
    {
        private IUnitOfWork repositories;
        private IMapper mapper;
        public TrackService()
        {
            this.repositories = new UnitOfWork();

            IConfigurationProvider config = new MapperConfiguration(
                cfg =>
                {
                    // Entity to DTO
                    cfg.CreateMap<Album, AlbumDTO>();
                    cfg.CreateMap<Artist, ArtistDTO>();
                    cfg.CreateMap<Сategory, СategoryDTO>();
                    cfg.CreateMap<Track, TrackDTO>();

                    // DTO to Entity
                    cfg.CreateMap<AlbumDTO, Album>();
                    cfg.CreateMap<ArtistDTO, Artist>();
                    cfg.CreateMap<СategoryDTO, Сategory>();
                    cfg.CreateMap<TrackDTO, Track>();
                });

            mapper = new Mapper(config);
        }

        // Public Service Interface
        public IEnumerable<TrackDTO> GetAllTracks()
        {
            var result = repositories.TrackRepos.Get(includeProperties: $"{nameof(Track.Artist)}, {nameof(Track.Album)}, {nameof(Track.Categories)}");
            return mapper.Map<IEnumerable<TrackDTO>>(result);
        }

        public void CreateNewTrack(TrackDTO trackDTO)
        {
            repositories.TrackRepos.Insert(mapper.Map<Track>(trackDTO));
            repositories.Save();
        }
    }
}
