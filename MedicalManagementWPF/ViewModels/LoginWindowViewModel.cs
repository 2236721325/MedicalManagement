using MedicalManagementWPF.Dtos;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicalManagementWPF.ViewModels
{
    public class LoginWindowViewModel : BindableBase
    {
        private string _title = "登录";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private UserLoginDto userLoginDto;
        public UserLoginDto UserLoginDto
        {
            get { return userLoginDto; }
            set { SetProperty(ref userLoginDto, value); }
        }
        private DelegateCommand _loginCommand;
        public DelegateCommand LoginCommand
        {
            get { return _loginCommand; }
            set { SetProperty(ref _loginCommand, value); }
        }


        public LoginWindowViewModel()
        {
            UserLoginDto = new UserLoginDto();
            LoginCommand = new DelegateCommand(() =>
            {

            });
        }
    }
}
