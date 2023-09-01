using System;
using UnityEngine;
using WeatherApp.Network;

namespace WeatherApp
{
    public class LocationFetcher
    {
        private const string URL = @"http://ip-api.com/json/";

        private APIFetcher _apiFetcher;
        public Action<LocationEntity> onLocationFetched;
        public Action<string> onLocationFetchFailed;

        public LocationFetcher()
        {
            _apiFetcher = new APIFetcher();
            _apiFetcher.onApiFetchSuccessful += LocationFetched;
        }

        public void GetLocation()
        {
            _apiFetcher.Get(URL);
        }

        private void LocationFetched(string locationData)
        {
            var location = JsonUtility.FromJson<LocationEntity>(locationData);
#if UNITY_EDITOR
            Debug.Log(locationData);
#endif
            onLocationFetched?.Invoke(location);
            //if (location.status.Equals("success"))
            //{
            //}
            //else
            //{
            //    onLocationFetchFailed?.Invoke("Unable to fetch the location");
            //}
        }
    }
}
