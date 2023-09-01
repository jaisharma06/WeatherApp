using System;

namespace WeatherApp
{
    [Serializable]
    public class LocationEntity
    {
        public float lon;
        public float lat;
        public string status;
    }
}