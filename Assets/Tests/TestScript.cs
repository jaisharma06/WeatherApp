using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.TestTools;
using WeatherApp;
using WeatherApp.Entities;
using WeatherApp.Network;
using Toast;

public class TestScript
{
    [Test]
    public void WeatherAPITest()
    {
        APIFetcher apiFetcher = new APIFetcher();
        apiFetcher.onApiFetchSuccessful += (data) =>
        {
            var weatherData = JsonUtility.FromJson<WeatherData>(data);
            Assert.IsNotNull(weatherData);
        };
        apiFetcher.Get(@"https://api.open-meteo.com/v1/forecast?latitude=19.07&longitude=72.87&timezone=IST&daily=temperature_2m_max");
    }

    [Test]
    public void TestLocation()
    {
        LocationManager locationManager = new LocationManager();
        locationManager.onLocationFetchSuccessful += (data) =>
        {
            Assert.IsNotNull(data);
        };

        locationManager.onLocationFetchFailure += (error) =>
        {
            Assert.AreNotEqual(string.Empty, error);
        };
    }

    [Test]
    public void TestNativeToast()
    {
        Assert.IsNull(NativeToast.Instance);
    }
}
