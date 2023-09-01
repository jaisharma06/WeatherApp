using UnityEngine;
using Toast;
using WeatherApp.Network;
using WeatherApp.Entities;

namespace WeatherApp
{
    public class WeatherManager : MonoBehaviour
    {
        [SerializeField] private string m_baseUrl = @"https://api.open-meteo.com/v1/forecast";
        [SerializeField] private CustomToast m_customToast;
        [SerializeField] private float m_customToastDuration = 7f;
        [SerializeField] private GameObject m_loadingScreen;

        [SerializeField] private bool m_showNativeToast = true;
        [SerializeField] private bool m_showCustomToast = true;

        private LocationManager _locationManager;
        private LocationFetcher _locationFetcher;
        private APIFetcher _apiFetcher;

        private void Awake()
        {
            Init();
        }

        private void OnEnable()
        {
            RegisterEvents();
        }

        private void OnDisable()
        {
            DeregisterEvents();
        }

#if UNITY_EDITOR
        private void Start()
        {
            //LocationFetchedSuccessfully(new Location(19.125f, 72.875f));
        }
#endif

        private void Init()
        {
            _locationManager = new LocationManager();
            _apiFetcher = new APIFetcher();
            _locationFetcher = new LocationFetcher();
            m_loadingScreen.SetActive(false);
        }

        private void RegisterEvents()
        {
            _locationManager.onLocationFetchSuccessful += LocationFetchedSuccessfully;
            _locationManager.onLocationFetchFailure += LocationFetchFailed;
            _locationFetcher.onLocationFetched += LocationFetchedSuccessfully;
            _apiFetcher.onApiFetchSuccessful += WeatherFetchedSuccessfully;
            _apiFetcher.onApiFetchFailed += APIFetchFailed;
        }

        private void DeregisterEvents()
        {
            _locationManager.onLocationFetchSuccessful -= LocationFetchedSuccessfully;
            _locationManager.onLocationFetchFailure -= LocationFetchFailed;
            _locationFetcher.onLocationFetched -= LocationFetchedSuccessfully;
            _apiFetcher.onApiFetchSuccessful -= WeatherFetchedSuccessfully;
            _apiFetcher.onApiFetchFailed -= APIFetchFailed;
        }

        private void LocationFetchedSuccessfully(Location location)
        {
            var url = $"{m_baseUrl}?latitude={location.latitude}&longitude={location.longitude}&timezone=IST&daily=temperature_2m_max";
            _apiFetcher.Get(url);
        }

        private void LocationFetchedSuccessfully(LocationEntity location)
        {
            var url = $"{m_baseUrl}?latitude={location.lat}&longitude={location.lon}&timezone=IST&daily=temperature_2m_max";
            _apiFetcher.Get(url);
        }

        private void LocationFetchFailed(string errorMessage)
        {
            ShowNativeToast($"Error - {errorMessage}");
            ShowCustomToast($"Error - {errorMessage}");
            m_loadingScreen.SetActive(false);
        }

        private void WeatherFetchedSuccessfully(string data)
        {
            var weatherData = JsonUtility.FromJson<WeatherData>(data);
            if (weatherData != null)
            {
                ShowNativeToast($"{weatherData}");
                ShowCustomToast($"{weatherData}");
            }
            else
            {
                ShowNativeToast($"{data}");
                ShowCustomToast($"{data}");
            }
            m_loadingScreen.SetActive(false);
        }

        private void APIFetchFailed(string errorMessage)
        {
            Debug.Log(errorMessage);
            ShowCustomToast($"{errorMessage}");
        }

        #region UIActions
        public void OnClickGetLocation()
        {
            m_loadingScreen.SetActive(true);
            //_locationManager.GetLocation();
            _locationFetcher.GetLocation();
        }

        private void ShowNativeToast(string message)
        {
            if (NativeToast.Instance != null && m_showNativeToast)
                NativeToast.Instance.ShowToast($"{message}");
        }

        private void ShowCustomToast(string message)
        {
            if (m_customToast != null && m_showCustomToast)
                m_customToast.Show($"{message}", m_customToastDuration);
        }
        #endregion
    }
}