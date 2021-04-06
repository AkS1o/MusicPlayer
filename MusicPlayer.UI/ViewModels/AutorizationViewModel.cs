using AutoMapper;
using MusicPlayer.BLL.DTO;
using MusicPlayer.BLL.Interface;
using MusicPlayer.BLL.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MusicPlayer.UI.ViewModels
{
    public class AutorizationViewModel : ModelBase
    {
        private IUserService userService = new UserService();
        private ICollection<UserModel> users = new ObservableCollection<UserModel>();
        private IMapper mapper;
        public AutorizationViewModel()
        {
            IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, UserModel>();
                cfg.CreateMap<UserModel, UserDTO>();
            });
            mapper = new Mapper(config);
            LoadAllUsers();
        }

        public void LoadAllUsers()
        {
            var result = mapper.Map<IEnumerable<UserModel>>(userService.GetAllUsers());

            users.Clear();
            foreach (var b in result)
            {
                users.Add(b);
            }
        }

        private UserDTO userDTO = new UserDTO();
        public UserDTO UserDTO { get => userDTO; set => SetProperty(ref userDTO, value); }


        private TextBox borderpasword = new TextBox();
        public TextBox Borderpasword { get => borderpasword; set => SetProperty(ref borderpasword, value); }

        private TextBox borderEmail = new TextBox();
        public TextBox BorderEmail { get => borderEmail; set => SetProperty(ref borderEmail, value); }


        public bool DataValidation()
        {
            borderEmail.BorderBrush = null;
            borderpasword.BorderBrush = null;
            bool check = false;
            if (ExistenceEmail())
            {

                if (ExistencePassword())
                {

                }
                else
                {
                    borderpasword.BorderBrush = Brushes.Red;
                    check = true;
                }
            }
            else
            {
                borderEmail.BorderBrush = Brushes.Red;
                check = true;
            }
            return check;
        }

        public bool ExistenceEmail() 
        {
            foreach (var item in users)
            {
                if (item.Email == userDTO.Email)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ExistencePassword() 
        {
            foreach (var item in users)
            {
                if (item.Password == Sha256encrypt(userDTO.Password))
                {
                    return true;
                }
            }
            return false;
        }

        public static string Sha256encrypt(string phrase)
        {
            UTF8Encoding encoder = new UTF8Encoding();
            SHA256Managed sha256hasher = new SHA256Managed();
            byte[] hashedDataBytes = sha256hasher.ComputeHash(encoder.GetBytes(phrase));
            return Convert.ToBase64String(hashedDataBytes);
        }

        public void LoginUser()
        {
            if (DataValidation()) { return; }
            MessageBox.Show("user logon");
        }
    }
}
