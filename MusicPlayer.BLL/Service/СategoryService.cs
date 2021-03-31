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
    public class СategoryService : IСategoryService
    {
        private IUnitOfWork repositories;
        private IMapper mapper;
        public СategoryService()
        {
            this.repositories = new UnitOfWork();

            IConfigurationProvider config = new MapperConfiguration(
                cfg =>
                {
                    // Entity to DTO
                    cfg.CreateMap<Сategory, СategoryDTO>();

                    // DTO to Entity
                    cfg.CreateMap<СategoryDTO, Сategory>();
                });

            mapper = new Mapper(config);
        }

        // Public Service Interface
        public IEnumerable<СategoryDTO> GetAllСategorys()
        {
            var result = repositories.СategoryRepos.Get();
            return mapper.Map<IEnumerable<СategoryDTO>>(result);
        }

        public void CreateNewСategory(СategoryDTO categoryDTO)
        {
            repositories.СategoryRepos.Insert(mapper.Map<Сategory>(categoryDTO));
            repositories.Save();
        }
    }
}