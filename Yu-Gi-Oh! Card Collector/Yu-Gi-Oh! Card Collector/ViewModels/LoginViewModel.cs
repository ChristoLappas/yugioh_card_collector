using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yu_Gi_Oh__Card_Collector.Models;
using Yu_Gi_Oh__Card_Collector.Services;

namespace Yu_Gi_Oh__Card_Collector.ViewModels
{
    [INotifyPropertyChanged]
    public partial class LoginViewModel
    {
        private LoginService loginService;
        
        [ObservableProperty]
        private string email;
        [ObservableProperty]
        private string password;    
        [ObservableProperty]
        private List<User> users;
        public LoginViewModel(LoginService log)
        {
            loginService = log;
        }
        [RelayCommand]
        public async Task Login()
        {
            users = await YuGiOhDatabase.GetUsers();

            for (int i = 0; i < users.Count; i++)
            {
                if (email == users[i].Email && password == users[i].Password)
                {
                    LoginDetails.Id = users[i].Id;
                    LoginDetails.Name = users[i].Username;
                    LoginDetails.Email = users[i].Email;

                    await loginService.Log();                    

                }                
                     
            }
            
        }

        [RelayCommand]
        public async Task GoToRegister()
        {
            await loginService.RegisterPage();        
        }
    }
}
