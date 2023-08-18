using System;
using System.Collections;
using System.Net;
using System.Net.Http;
using UnityEngine;
using UnityEngine.Networking;

namespace WeatherApp.Network
{
    public class APIFetcher
    {
        public Action<string> onApiFetchSuccessful;


        private Coroutine _getCoroutine;
        public async void Get(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await (httpClient.GetStringAsync(url));
                onApiFetchSuccessful?.Invoke(response);
            }
        }
    }
}
