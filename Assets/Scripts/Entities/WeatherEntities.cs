using System.Collections.Generic;
using System;

namespace WeatherApp.Entities
{
    [Serializable]
    public class Daily
    {
        public List<string> time;
        public List<double> temperature_2m_max;

        public override string ToString()
        {
            return ($"Daily:-" +
                $"\nTime: {string.Join(",", time)}" +
                $"\nTemperature(2m Max): {string.Join(",", temperature_2m_max)}");
        }
    }

    [Serializable]
    public class DailyUnits
    {
        public string time;
        public string temperature_2m_max;

        public override string ToString()
        {
            return ($"Daily Units:-" +
                $"\nTime: {time}" +
                $"\nTemperature(2m Max): {temperature_2m_max}");

        }
    }

    [Serializable]
    public class WeatherData
    {
        public double latitude;
        public double longitude;
        public double generationtime_ms;
        public int utc_offset_seconds;
        public string timezone;
        public string timezone_abbreviation;
        public double elevation;
        public DailyUnits daily_units;
        public Daily daily;

        public override string ToString()
        {
            return ($"Latitude: {latitude}" +
                        $"\nLongitude: {longitude}" +
                        $"\nGeneration(ms): {generationtime_ms}" +
                        $"\nUTC-Offset(seconds): {utc_offset_seconds}" +
                        $"\nTimezone: {timezone}" +
                        $"\nTimezone Abbreviation: {timezone_abbreviation}" +
                        $"\nElevation: {elevation}" +
                        $"\n{daily_units}" +
                        $"\n{daily}");
        }
    }
}