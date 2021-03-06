﻿using Ins.Core.Interfaces;
using Ins.Core.Models;
using MvvmCross.Core.ViewModels;

namespace Ins.Core.ViewModels
{
    public class FacebookPageViewModel: MvxViewModel
    {
        private IUserService _userService;
        private User _currentUser;

        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                if (SetProperty(ref _currentUser, value))
                    RaisePropertyChanged(() => _currentUser);
            }
        }

        public FacebookPageViewModel(IUserService userService)
        {
            _userService = userService;
            _currentUser = _userService.GetCurrentUser();
        }
    }
}