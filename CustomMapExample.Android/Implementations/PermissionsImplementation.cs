using Android.Support.V4.Content;
using CustomMapExample.Abstractions;
using CustomMapExample.Droid.Implementations;
using Xamarin.Forms;
using Plugin.CurrentActivity;
using Android;
using Android.Content.PM;
using Android.Support.V4.App;
using System;
using System.Threading.Tasks;

//The dialog box shown by the system describes the permission group your app needs access to; it does not list the specific permission.
//For example, if you request the READ_CONTACTS permission, the system dialog box just says your app needs access to the device's contacts. 
//The user only needs to grant permission once for each permission group. 
//If your app requests any other permissions in that group (that are listed in your app manifest), the system automatically grants them. 
//When you request the permission, the system calls your onRequestPermissionsResult() callback method and passes PERMISSION_GRANTED, 
//the same way it would if the user had explicitly granted your request through the system dialog box.

/*Note: 
 * Your app still needs to explicitly request every permission it needs,
 even if the user has already granted another permission in the same group. 
 * In addition, the grouping of permissions into groups may change in future Android releases. 
 * Your code should not rely on the assumption that particular permissions are or are not in the same group.*/

/*
If the user denies a permission request, your app should take appropriate action. 
For example, your app might show a dialog explaining why it could not perform the user's requested action that needs that permission.

When the system asks the user to grant a permission, the user has the option of telling the system not to ask for that permission again. 
In that case, any time an app uses requestPermissions() to ask for that permission again, the system immediately denies the request. 
The system calls your onRequestPermissionsResult() callback method and passes PERMISSION_DENIED, 
the same way it would if the user had explicitly rejected your request again. 
The method also returns false if a device policy prohibits the app from having that permission. 
This means that when you call requestPermissions(), you cannot assume that any direct interaction with the user has taken place.*/

[assembly: Dependency(typeof(PermissionsImplementation))]
namespace CustomMapExample.Droid.Implementations
{
    public class PermissionsImplementation : IPermissions
    {
        readonly int CURRENT_LOCATION_REQUEST_CODE = 99;

        Task<bool> IPermissions.RequestLocationPermission()
        {
            var currentActivity = CrossCurrentActivity.Current.Activity;
            ((MainActivity)currentActivity).permissionsResponse = new TaskCompletionSource<bool>();

            ActivityCompat.RequestPermissions(currentActivity, new String[] { Manifest.Permission.AccessFineLocation},
                            CURRENT_LOCATION_REQUEST_CODE);
            return ((MainActivity)currentActivity).permissionsResponse.Task;
        }

        public void CheckLocationPermissions()
        {
        //    var currentActivity = CrossCurrentActivity.Current.Activity;
        //    if (ContextCompat.CheckSelfPermission(currentActivity, Manifest.Permission.AccessFineLocation)
        //        != Permission.Granted)
        //    {

        //        if (ActivityCompat.ShouldShowRequestPermissionRationale(currentActivity, Manifest.Permission.AccessFineLocation))
        //        {
        //            // Show an explanation to the user *asynchronously* -- don't block
        //            // this thread waiting for the user's response! After the user
        //            // sees the explanation, try again to request the permission.
        //        }
        //        else
        //        {
        //            // No explanation needed; request the permission
        //            ActivityCompat.RequestPermissions(currentActivity,
        //                                              new String[] { Manifest.Permission.AccessFineLocation, 
        //                Manifest.Permission.AccessCoarseLocation },
        //                    CURRENT_LOCATION_REQUEST_CODE);

                   
        //        }
        //    }
        //    else
        //    {
        //        // Permission has already been granted
        //    }


        //    //CrossCurrentActivity.Current.Activity.RequestPermissions(new string[2],0);

        //        ////returns true if the user has previously denied the request, 
        //        ////and returns false if a user has denied a permission and selected the Don't ask again option in the permission request dialog, 
        //        ////or if a device policy prohibits the permission
        //        //CrossCurrentActivity.Current.Activity.ShouldShowRequestPermissionRationale(Manifest.Permission.AccessFineLocation);
        }
    }
}

