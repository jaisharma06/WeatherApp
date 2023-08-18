using System.Threading.Tasks;
using UnityEngine;
using System;
#if  !UNITY_EDITOR && UNITY_ANDROID
using UnityEngine.Android;
#endif

namespace WeatherApp
{
    public class LocationManager
    {
        private const int SECOND = 1000;
        private float _waitTime;
        private int _maxTries;

        private int _remainingTries;


        public Action<Location> onLocationFetchSuccessful;
        public Action<string> onLocationFetchFailure;

        private Location _lastFetchedLocation = new Location();

        public LocationManager(float waitTime = 0.2f, int maxTries = 3)
        {
            _waitTime = waitTime;
            _maxTries = maxTries;
        }

        public void GetLocation()
        {
            _remainingTries = _maxTries;
#if !UNITY_EDITOR && UNITY_ANDROID
            RequestPermissionAndFetchLocation();
#else
            onLocationFetchFailure?.Invoke("Unable to fetch location for current platform");
#endif
        }

        private async void FetchLocation()
        {
#if UNITY_EDITOR || !UNITY_ANDROID
            onLocationFetchFailure?.Invoke("Unable to fetch location for current platform");
#endif

            if (!Input.location.isEnabledByUser)
            {
                return;
            }

            Input.location.Start();
            while (Input.location.status == LocationServiceStatus.Initializing && _remainingTries > 0)
            {
                await Task.Delay((int)(SECOND * _waitTime));
                _remainingTries--;
            }

            if (_remainingTries <= 0)
            {
                //Show timeout error
                onLocationFetchFailure?.Invoke("Timeout Error");
            }

            if (Input.location.status == LocationServiceStatus.Failed)
            {
                //Show error
                onLocationFetchFailure?.Invoke("Unable to fetch location");
            }
            else
            {
                _lastFetchedLocation.latitude = Input.location.lastData.latitude;
                _lastFetchedLocation.longitude = Input.location.lastData.longitude;
                onLocationFetchSuccessful?.Invoke(_lastFetchedLocation);
            }

            Input.location.Stop();
        }

#if !UNITY_EDITOR && UNITY_ANDROID
        private void RequestPermissionAndFetchLocation()
        {
            if (Permission.HasUserAuthorizedPermission(Permission.FineLocation))
            {
                FetchLocation();
                return;
            }

            PermissionCallbacks locationPermissionCallbacks = new PermissionCallbacks();
            locationPermissionCallbacks.PermissionGranted += LocationPermissionGranted;
            locationPermissionCallbacks.PermissionDenied += LocationPermissionDenied;
            locationPermissionCallbacks.PermissionDeniedAndDontAskAgain += LocationPermissionDeniedAndDontAskAgain;
            Permission.RequestUserPermission(Permission.FineLocation, locationPermissionCallbacks);
        }

        private void LocationPermissionGranted(string message)
        {
            FetchLocation();
        }

        private void LocationPermissionDenied(string message)
        {
            onLocationFetchFailure?.Invoke(message);
        }

        private void LocationPermissionDeniedAndDontAskAgain(string message)
        {
            onLocationFetchFailure?.Invoke(message);
        }
#endif
    }
}
