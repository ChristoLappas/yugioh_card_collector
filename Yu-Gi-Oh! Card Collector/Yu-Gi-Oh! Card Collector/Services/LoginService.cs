using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yu_Gi_Oh__Card_Collector.Views;

namespace Yu_Gi_Oh__Card_Collector.Services
{
    public class LoginService
    {
        public async Task Log()
        {
            await Shell.Current.GoToAsync($"//{nameof(MainView)}");
        }

        public async Task RegisterPage()
        {
            await Shell.Current.GoToAsync(nameof(RegisterView));
        }
    }
}
