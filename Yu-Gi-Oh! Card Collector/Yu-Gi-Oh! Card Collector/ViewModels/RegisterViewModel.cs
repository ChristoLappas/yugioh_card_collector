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
    public partial class RegisterViewModel
    {
        [ObservableProperty]
        private string user;
        [ObservableProperty]
        private string email;
        [ObservableProperty]
        private string password;
        [ObservableProperty]
        List<User> users;


        [RelayCommand]
        public async Task CreateUser()
        {
            if (user == null || email == null || password == null)
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                string text = "Some fields are empty!";
                ToastDuration duration = ToastDuration.Short;
                double fontSize = 17;
                var toast = Toast.Make(text, duration, fontSize);
                await toast.Show(cancellationTokenSource.Token);
            }
            else
            {
                await YuGiOhDatabase.AddUser(user, email, password);

                users = await YuGiOhDatabase.GetUsers();

                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                string text = "User successfully created!";
                ToastDuration duration = ToastDuration.Short;
                double fontSize = 17;
                var toast = Toast.Make(text, duration, fontSize);
                await toast.Show(cancellationTokenSource.Token);
            }

        }


    }
}
