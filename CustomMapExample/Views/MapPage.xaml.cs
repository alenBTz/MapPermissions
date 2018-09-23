using System;
using CustomMapExample.ViewModels;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

namespace CustomMapExample.Views
{
    public partial class MapPage : ContentPage
    {
        MapViewModel vm = new MapViewModel();
        public MapPage()
        {
            InitializeComponent();
            BindingContext = vm;
        }
        protected async override void OnAppearing()
        {

            vm.IsMapVisible = false;
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
            if (status != PermissionStatus.Granted)
            {
                var result = await DependencyService.Get<Abstractions.IPermissions>().RequestLocationPermission();
                if (!result)
                    await Navigation.PopAsync();
                else
                {
                    vm.IsMapVisible = true;
                    await vm.InitializePage();
                }
            }
            else
            {
                vm.IsMapVisible = true;
                await vm.InitializePage();
            }
            base.OnAppearing();
        }
    }
}
