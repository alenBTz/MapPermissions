using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomMapExample.Abstractions
{
    public interface IPermissions
    {
        void CheckLocationPermissions();
        Task<bool> RequestLocationPermission();
    }
}

