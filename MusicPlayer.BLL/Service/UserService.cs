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
    public class UserService : IUserService
    {
        private IUnitOfWork repositories;
        private IMapper mapper;
        public UserService()
        {
            this.repositories = new UnitOfWork();

            IConfigurationProvider config = new MapperConfiguration(
                cfg =>
                {
                    // Entity to DTO
                    cfg.CreateMap<User, UserDTO>();

                    // DTO to Entity
                    cfg.CreateMap<UserDTO, User>();
                });

            mapper = new Mapper(config);
        }

        // Public Service Interface
        public IEnumerable<UserDTO> GetAllUsers()
        {
            var result = repositories.UserRepos.Get();
            return mapper.Map<IEnumerable<UserDTO>>(result);
        }

        public void CreateNewUser(UserDTO userDTO)
        {
            repositories.UserRepos.Insert(mapper.Map<User>(userDTO));
            repositories.Save();
        }
    }
}