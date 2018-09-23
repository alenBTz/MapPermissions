using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.CurrentActivity;
using System.Threading.Tasks;

namespace CustomMapExample.Droid
{
    [Activity(Label = "CustomMapExample", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public TaskCompletionSource<bool> permissionsResponse = new TaskCompletionSource<bool>();

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            Xamarin.FormsMaps.Init(this, bundle);
            CrossCurrentActivity.Current.Init(this, bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            switch (requestCode)
            {
                case 99:
                    {
                        // If request is cancelled, the result arrays are empty.
                        if (grantResults.Length > 0
                            && grantResults[0] == Permission.Granted)
                        {
                            permissionsResponse.SetResult(true);
                        }
                        else
                        {
                            permissionsResponse.SetResult(false);
                        }
                        return;
                    }

                    // other 'case' lines to check for other
                    // permissions this app might request.
            }
        }
    }
}

