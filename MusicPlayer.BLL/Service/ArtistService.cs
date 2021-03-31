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
    public class ArtistService : IArtistService
    {
        private IUnitOfWork repositories;
        private IMapper mapper;
        public ArtistService()
        {
            this.repositories = new UnitOfWork();

            IConfigurationProvider config = new MapperConfiguration(
                cfg =>
                {
                    // Entity to DTO
                    cfg.CreateMap<Artist, ArtistDTO>();

                    // DTO to Entity
                    cfg.CreateMap<ArtistDTO, Artist>();
                });

            mapper = new Mapper(config);
        }

        // Public Service Interface
        public IEnumerable<ArtistDTO> GetAllArtists()
        {
            var result = repositories.ArtistRepos.Get();
            return mapper.Map<IEnumerable<ArtistDTO>>(result);
        }

        public void CreateNewArtist(ArtistDTO artistDTO)
        {
            repositories.ArtistRepos.Insert(mapper.Map<Artist>(artistDTO));
            repositories.Save();
        }
    }
}
