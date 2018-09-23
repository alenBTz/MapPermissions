using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;
using CustomMapExample.Abstractions;
using System.Diagnostics;

namespace CustomMapExample.ViewModels
{
    public class MapViewModel : INotifyPropertyChanged
    {
        public MapViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal async Task InitializePage()
        {
            var locator = CrossGeolocator.Current;
            var result = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
            CurrentLocationAddress = $"{result.Latitude} {result.Longitude}";
        }

        #region Properties

        /// <summary>
        /// Gets or sets the current location address.
        /// </summary>
        /// <value>The current location address.</value>
        public string CurrentLocationAddress
        {
            get => currentLocationAddress;

            set
            {
                currentLocationAddress = value;
                OnPropertyChanged(nameof(currentLocationAddress));
            }
        }
        private string currentLocationAddress = "Current location turned off";
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:CustomMapExample.ViewModels.MapViewModel"/> is map visible.
        /// </summary>
        /// <value><c>true</c> if is map visible; otherwise, <c>false</c>.</value>
        public bool IsMapVisible
        {
            get => isMapVisible;

            set
            {
                isMapVisible = value;
                OnPropertyChanged(nameof(IsMapVisible));
            }
        }
        private bool isMapVisible = false;

        /// <summary>
        /// Ons the property changed.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var trace =
            $"PropertyChanged Is Null: {(PropertyChanged == null ? "Yes" : "No")}";
            Debug.WriteLine(trace);

            var propertyChangedCallback = PropertyChanged;
            propertyChangedCallback?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}

