using AutoMapper;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using MusicPlayer.BLL.DTO;
using MusicPlayer.BLL.Interface;
using MusicPlayer.BLL.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MusicPlayer.UI.ViewModels
{
    public class RegistrationViewModel : ModelBase
    {

        private IUserService userService = new UserService();
        private ICollection<UserModel> users = new ObservableCollection<UserModel>();
        private IMapper mapper;
        public RegistrationViewModel()
        {
            UserDTO.Picture = "\\Assets\\NoPhoto.png";
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

        private Frame loginFrame = new Frame();
        public Frame LoginFrame { get => loginFrame; set => SetProperty(ref loginFrame, value); }

        public void OpenTheRegistrationWindow()
        {
            while (loginFrame.NavigationService.RemoveBackEntry() != null) ;
            loginFrame.Content = null;
            loginFrame.NavigationService.Navigate(new PageRegistration());
        }

        public void OpenTheAutorizationWindow()
        {
            while (loginFrame.NavigationService.RemoveBackEntry() != null) ;
            loginFrame.Content = null;
            loginFrame.NavigationService.Navigate(new PageAutorization());

        }

        private string picture = "\\Assets\\NoPhoto.png";
        public string Picture { get => picture; set => SetProperty(ref picture, value); }

        public void SelectDirectoryForwayToPicture()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            dialog.InitialDirectory = @"C:";
            dialog.Title = "Please select an image file to encrypt.";

            if (dialog.ShowDialog() == true)
            {
                Picture = dialog.FileName;
                UserDTO.Picture = Picture;
            }
        }

        private string musicPath;
        public string MusicPath { get => musicPath; set => SetProperty(ref musicPath, value); }

        private UserDTO userDTO = new UserDTO();
        public UserDTO UserDTO { get => userDTO; set => SetProperty(ref userDTO, value); }

        public void SelectDirectoryForWayToMusic()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = @"C:\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                MusicPath = dialog.FileName;
                UserDTO.WayToSongs = MusicPath;
            }
        }

        private TextBox textEmailborder = new TextBox();
        public TextBox TextEmailborder { get => textEmailborder; set => SetProperty(ref textEmailborder, value); }

        public bool NameValidation()
        {
            if (userDTO.Name == null) { return true; }
            Regex regex = new Regex(@".{2,}");
            Match match = regex.Match(userDTO.Name);
            return match.Success;
        }

        public bool EmailValidation()
        {
            if (userDTO.Email == null) { return true; }
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(userDTO.Email);
            return match.Success;
        }

        public bool PasswordValidation()//Это регулярное выражение будет обеспечивать соблюдение следующих правил: • По крайней мере, одна заглавная английская буква • По крайней мере одна строчная английская буква • По крайней мере одна цифра • По крайней мере один специальный символ • Минимальная длина 8
        {
            if (userDTO.Password == null) { return true; }
            Regex regex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            Match match = regex.Match(userDTO.Password);
            return match.Success;
        }

        public bool InputCheck()//перевірка на заповненість зміних
        {
            bool check = false;
            if (userDTO.Name == null) { borderName.BorderBrush = Brushes.Red; check = true; }
            if (userDTO.Password == null) { borderpasword.BorderBrush = Brushes.Red; check = true; }
            if (userDTO.Email == null) { borderEmail.BorderBrush = Brushes.Red; check = true; }
            if (userDTO.WayToSongs == null) { borderWayToSongs.BorderBrush = Brushes.Red; check = true; }
            return check;
        }

        public bool ExistenceUserInDatabase() //перевірка чи існує юзер с таким імейлом 
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

        private TextBox borderEmail = new TextBox();
        public TextBox BorderEmail { get => borderEmail; set => SetProperty(ref borderEmail, value); }

        private TextBox borderName = new TextBox();
        public TextBox BorderName { get => borderName; set => SetProperty(ref borderName, value); }

        private TextBox borderpasword = new TextBox();
        public TextBox Borderpasword { get => borderpasword; set => SetProperty(ref borderpasword, value); }

        private TextBox borderWayToSongs = new TextBox();
        public TextBox BorderWayToSongs { get => borderWayToSongs; set => SetProperty(ref borderWayToSongs, value); }

        public bool DataValidation()
        {
            borderEmail.BorderBrush = null;
            borderName.BorderBrush = null;
            borderpasword.BorderBrush = null;
            borderWayToSongs.BorderBrush = null;


            bool check = false;

            if (InputCheck())
            {
                check = true;
            }
            if (!NameValidation())
            {
                borderName.BorderBrush = Brushes.Red;
                check = true;
            }
            if (!EmailValidation())
            {
                check = true;
                borderEmail.BorderBrush = Brushes.Red;
            }
            if (!PasswordValidation())
            {
                borderpasword.BorderBrush = Brushes.Red;
                check = true;
            }
            else
            {
                UserDTO.Password = Sha256encrypt(UserDTO.Password);
            }
            if (ExistenceUserInDatabase())
            {
                borderEmail.BorderBrush = Brushes.Red;
                check = true;
            }
            return check;
        }

        public static string Sha256encrypt(string phrase)
        {
            UTF8Encoding encoder = new UTF8Encoding();
            SHA256Managed sha256hasher = new SHA256Managed();
            byte[] hashedDataBytes = sha256hasher.ComputeHash(encoder.GetBytes(phrase));
            return Convert.ToBase64String(hashedDataBytes);
        }

        public void СreatingAUser()
        {        
            if (DataValidation()) { return; }        
            userService.CreateNewUser(userDTO);
            MessageBox.Show("user create");
        }

    }
}
