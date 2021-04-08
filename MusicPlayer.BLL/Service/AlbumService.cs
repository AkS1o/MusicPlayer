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
    public class AlbumService : IAlbumService
    {
        private IUnitOfWork repositories;
        private IMapper mapper;
        public AlbumService()
        {
            this.repositories = new UnitOfWork();

            IConfigurationProvider config = new MapperConfiguration(
                cfg =>
                {
                    // Entity to DTO
                    cfg.CreateMap<Album, AlbumDTO>();
                    cfg.CreateMap<Artist, ArtistDTO>();
                    cfg.CreateMap<Track, TrackDTO>();
                    cfg.CreateMap<Сategory, СategoryDTO>();

                    // DTO to Entity
                    cfg.CreateMap<AlbumDTO, Album>();
                    cfg.CreateMap<ArtistDTO, Artist>();
                    cfg.CreateMap<TrackDTO, Track>(); 
                    cfg.CreateMap<СategoryDTO, Сategory>();
                });

            mapper = new Mapper(config);
        }

        // Public Service Interface
        public IEnumerable<AlbumDTO> GetAllAlbums()
        {
            var result = repositories.AlbumRepos.Get(includeProperties: $"{nameof(Album.Artist)}");
            return mapper.Map<IEnumerable<AlbumDTO>>(result);
        }

        public void CreateNewAlbum(AlbumDTO albumDTO)
        {
            repositories.AlbumRepos.Insert(mapper.Map<Album>(albumDTO));
            repositories.Save();
        }
    }
}
