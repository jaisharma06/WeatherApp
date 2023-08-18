namespace WeatherApp
{
    public class Location
    {
        public float longitude;
        public float latitude;

        public Location()
        {
            longitude = 0;
            latitude = 0;
        }

        public Location(float longitude, float latitude)
        {
            this.longitude = longitude;
            this.latitude = latitude;
        }

        public override string ToString()
        {
            return $"latitude: {latitude}, longitude: {longitude}";
        }
    }
}