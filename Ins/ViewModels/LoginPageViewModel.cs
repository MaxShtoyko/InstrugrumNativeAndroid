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
using Ins.Models;
using Ins.Services;
using MvvmCross.Core.ViewModels;

namespace Ins.ViewModels
{
    public class LoginPageViewModel:MvxViewModel
    {
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

        public ICommand OnLogIn { get; private set; }
        public ICommand OnSignUp { get; private set; }

        public LoginPageViewModel()
        {
            _user = UserService.getCurrentUser();

            DataBaseService.createDataBase();
            OnLogIn = new MvxCommand(LogInClicked);
            OnSignUp = new MvxCommand(SignUpClicked);
        }

        void SignUpClicked()
        {
            ShowViewModel<RegistrationViewModel>();
        }

        void LogInClicked()
        {
            if (UserService.IsCorrect(User)){

                if (!DataBaseService.InDataBase(User)){
                    DataBaseService.insertIntoTableUser(User);
                }            
                else
                {
                    DataBaseService.updateTableUser(User);
                }
                ShowViewModel<TabbedViewModel>();

            }
            else {

            }
        }

        
    }
}