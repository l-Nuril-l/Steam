﻿using Microsoft.Win32;
using Steam.BLL.Services;
using Steam.Infrastructure;
using Steam.Views.MainViewClilds;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Steam.ViewModels.MainViewModelChilds
{
    class EditUserViewModel : BaseNotifyPropertyChanged
    {
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
            ass = s;
            Logo = Environment.CurrentDirectory + "\\Images\\back.png";
            ChangePicture = new RelayCommand(x =>
            {
                System.Windows.Forms.OpenFileDialog theDialog = new System.Windows.Forms.OpenFileDialog();
                theDialog.Title = "Open";
                theDialog.Filter = "All|*.*";
                if (theDialog.ShowDialog() == DialogResult.OK)
                {
                    Image ImageFromFile = Image.FromFile(theDialog.FileName);
                    Bitmap bmp = new Bitmap(ImageFromFile);
                    ImageConverter converter = new ImageConverter();
                    Photo = (byte[])converter.ConvertTo(bmp, typeof(byte[]));
                    AvatarPath = theDialog.FileName;
                }
            });
            Save = new RelayCommand(x =>
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