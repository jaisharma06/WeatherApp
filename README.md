# Weather App
> Provides the user details about the weather condition based on the location

## Table of Contents
- [Weather App](#weather-app)
  - [General Information](#general-information)
  - [Contact](#contact)
    - [@jaisharma06](#jaisharma06)
  - [Architecture](#architecture)

## General Information

### Architecture
><p><b>WeatherManager</b> - Handles all the UI parts and interacts with all the required components. This is the main class of the project. It interacts with the LocationManager to get the device's location and also uses the APIFetcher to get the data from the weather API.</p>

><p><b>LocationManager</b> - It asks for the location permission from the user and provides the location if permission is granted else it throws an error.</p>

><p><b>APIFetcher</b> - Provides utility method for fetching the api data.</p>

><p><b>CustomToast</b> - Custom toast class for the application to show toast messages.</p>

><p><b>NativeToast</b> - Toast class to show native Android toasts to the user.</p>

## Scenes
>**Scene_WeatherApp** - Main scene of the application to show weather data. It contains a button that can be tapped to show the weather information toast on the screen.

## Contact
Created by -

### [@jaisharma06](https://github.com/jaisharma06)</br>
Name - Jai Prakash</br>
Email - [jai.sharma06@live.com](mailto:jai.sharma06@live.com)</br>
Phone - +91-8447490922

*Build Link - [WeathrApp](https://github.com/jaisharma06/WeatherApp/raw/master/Builds/Android/WeatherApp.apk)*
</br>*Package Link(Custom Toast) - [CustomToast](https://github.com/jaisharma06/WeatherApp/raw/master/Builds/Packages/CustomToast.unitypackage)*
</br>*Package Link(Native Toast) - [NativeToast](https://github.com/jaisharma06/WeatherApp/raw/master/Builds/Packages/NativeToast.unitypackage)*

feel free to contact :smiley:!
