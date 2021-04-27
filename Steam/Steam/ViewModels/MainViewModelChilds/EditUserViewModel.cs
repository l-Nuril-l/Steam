﻿using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Steam.BLL.Services;
using Steam.Infrastructure;
using Steam.Views.MainViewClilds;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Steam.ViewModels.MainViewModelChilds
{
    class EditUserViewModel : BaseNotifyPropertyChanged
    {
        public string exc;
        public string Exc
        {
            get => exc;
            set
            {
                exc = value;
                Notify();
            }

        }
        public string elipseColor;
        public string ElipseColor
        {
            get => elipseColor;
            set
            {
                elipseColor = value;
                Notify();
            }

        }
        bool IsChecked;
        public ICommand CheckCmd { get => new RelayCommand<object>(Check); }
        public ICommand  SavePswCmd { get => new RelayCommand<object>(Savea); }
        string oldpsw { get; set; }
        private void Check(object o)
        {
            oldpsw = (o as PasswordBox).Password;
            if (BCrypt.Net.BCrypt.Verify(oldpsw, Account.CurrentAccount.PassHash))
            {
                IsChecked = true;
                ElipseColor = "Green";
            }
            else
            {
                IsChecked = false;
                ElipseColor = "Red";
            }

        }
        private void Savea(object o)
        {
            Exc = "";
            if (IsChecked)
                Account.CurrentAccount.PassHash = BCrypt.Net.BCrypt.HashPassword((o as PasswordBox).Password);
            else
            {
                if ((o as PasswordBox).Password != "")
                    Exc = "Check password";
            }

           

            ass.CreateOrUpdate(Account.CurrentAccount);
            oldpsw = "";
            (o as PasswordBox).Password = "";
        }


        byte[] Photo;
        public string logo;
        public string Logo
        {
            get => logo;
            set
            {
                logo = value;
                Notify();
            }
        }
        public string psw;
        public string Psw
        {
            get => psw;
            set
            { 
                psw = value;
                Notify();
            }
        }
        public string avatarPath;
        public string AvatarPath
        {
            get => avatarPath;
            set
            {
                avatarPath = value;
                Notify();
            }
        }
        public string country;
        public string Country
        {
            get => country;
            set
            {
                country = value;
                Notify();
            }
        }
        public string realName;
        public string RealName
        {
            get => realName;
            set
            {
                realName = value;
                Notify();
            }
        }
        public string profileName;
        public string ProfileName
        {
            get => profileName;
            set
            {
                profileName = value;
                Notify();
            }
        }
        public string more;
        public string More
        {
            get => more;
            set
            {
                more = value;
                Notify();
            }
        }
        public string email;
        public string Email
        {
            get => email;
            set
            {
                email = value;
                Notify();
            }
        }
        public EditUserViewModel(AccountService s)
        {
            ElipseColor = "Red";
            ass = s;
            Logo = Environment.CurrentDirectory + "\\Images\\back.png";
            ChangePicture = new Infrastructure.RelayCommand(x =>
            {
                System.Windows.Forms.OpenFileDialog theDialog = new System.Windows.Forms.OpenFileDialog();
                theDialog.Title = "Open";
                theDialog.Filter = "All|*.*";
                if (theDialog.ShowDialog() == DialogResult.OK)
                {
                    System.Drawing.Image ImageFromFile = System.Drawing.Image.FromFile(theDialog.FileName);
                    Bitmap bmp = new Bitmap(ImageFromFile);
                    ImageConverter converter = new ImageConverter();
                    Photo = (byte[])converter.ConvertTo(bmp, typeof(byte[]));
                    AvatarPath = theDialog.FileName;
                }
            });
            Save = new Infrastructure.RelayCommand(x =>
            {
                if (Photo != null)
                    Account.CurrentAccount.Avatar = Photo;

                if (Country != null)
                    Account.CurrentAccount.Country = Country;

                if (Email != null)
                    Account.CurrentAccount.Email = Email;

                if (More != null)
                    Account.CurrentAccount.More = More;

                if (ProfileName != null)
                    Account.CurrentAccount.ProfileName = ProfileName;

                if (RealName != null)
                    Account.CurrentAccount.RealName = RealName;

                
                ass.CreateOrUpdate(Account.CurrentAccount);
                Switcher.Switch(new ProfileView());
            });
        }
        AccountService ass;
        public ICommand ChangePicture { get; set; }
        public ICommand Save { get; set; }
    }
}
