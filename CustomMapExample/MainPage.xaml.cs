using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomMapExample.Abstractions;
using CustomMapExample.Views;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

namespace CustomMapExample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async Task NavigateButton_OnClicked(object obj)
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Location);
            if (status != PermissionStatus.Granted)
            {
                var result = await DependencyService.Get<Abstractions.IPermissions>().RequestLocationPermission();
                if (!result)
                    Console.WriteLine("Prihvati permisije papak jedan");
                else
                    await Navigation.PushAsync(new MapPage());
            }
            else
                await Navigation.PushAsync(new MapPage());

            //await Navigation.PushAsync(new MapPage());

        }

    }
}
