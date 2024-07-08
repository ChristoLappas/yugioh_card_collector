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
    public partial class SettingsViewModel
    {
        [ObservableProperty]
        private bool dark;
        [ObservableProperty]
        private string name = LoginDetails.Name;
        [ObservableProperty]
        private string password;
        [ObservableProperty]
        private string password2;
        [ObservableProperty]
        private string currency;
        [ObservableProperty]
        private ImageSource profilePic;


        [RelayCommand]
        public async Task DarkMode()
        {
            if(dark == true)
                Application.Current.UserAppTheme = AppTheme.Dark;
            else if(dark == false)
                Application.Current.UserAppTheme = AppTheme.Light;

        }

        [RelayCommand]
        public async Task SaveSettings()
        {
            if (Currency == "€ Euro")
                Preferences.Default.Set("euro", true);
            else
                Preferences.Default.Set("euro", false);


            if (Password == Password2 && !string.IsNullOrWhiteSpace(Name))
            {
                await YuGiOhDatabase.UpdateUser(LoginDetails.Id, Name, Password);

                LoginDetails.Name = Name;
                
            }

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            string text = "Settings Saved!";
            ToastDuration duration = ToastDuration.Short;
            double fontSize = 17;
            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
        }
        //Set profile picture
        [RelayCommand]
        public async Task UploadImage()
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Pick a profile picture",
                FileTypes = FilePickerFileType.Images
            });

            if (result == null)
                return;

            var stream = await result.OpenReadAsync();

            ProfilePic = ImageSource.FromStream(() => stream);


        }
    }
}
