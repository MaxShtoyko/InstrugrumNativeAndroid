﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Ins.Droid.Interfaces;
using Ins.Droid.Models;
using Ins.Droid.Services;
using MvvmCross.Core.ViewModels;

namespace Ins.Droid.ViewModels
{
    public class RegistrationPageViewModel:MvxViewModel
    {
        private IUserService _userService;

        private User _user;
        public User User
        {
            get => _user;
            set
            {
                if (SetProperty(ref _user, value))
                    RaisePropertyChanged(() => _user);
            }
        }

        public ICommand OnSignUp { get; private set; }
        
        public RegistrationPageViewModel(IUserService userService)
        {
            _userService = userService;
            _user = _userService.GetCurrentUser();

            OnSignUp = new MvxCommand(SignUpClicked);
        }

        void SignUpClicked()
        {
            ShowViewModel<TabPageViewModel>();
        }
    }
}