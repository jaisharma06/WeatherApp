using System;
using System.Net.Http;
using UnityEngine;

namespace WeatherApp.Network
{
    public class APIFetcher
    {
        public Action<string> onApiFetchSuccessful;
        public Action<string> onApiFetchFailed;


        public async void Get(string url)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var response = await (httpClient.GetAsync(url));
                    if (response.IsSuccessStatusCode)
                    {
                        string resonseData = await response.Content.ReadAsStringAsync();
                        onApiFetchSuccessful?.Invoke(resonseData);
                    }
                    else
                    {
                        onApiFetchFailed?.Invoke($"Response Code: {(int)response.StatusCode}, Error: Failed to fetch api");
                    }

                }
            }
            catch(Exception e)
            {
                Debug.Log(e.Message);
                onApiFetchFailed?.Invoke($"Error: Failed to fetch api");
            }
        }
    }
}
