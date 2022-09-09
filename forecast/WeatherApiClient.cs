using System.Net;

namespace weather
{
    public class WeatherApiClient
    {
        private const string URL = "https://api.met.no/weatherapi/locationforecast/2.0/";
        private const string USER_AGENT = "https://github.com/MikhailKrutichenko";

        public String getForecastResultXml(String lat, String lon)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(getRequstUrl(lat, lon));
            request.UserAgent = USER_AGENT;
            WebResponse response = request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string responseText = reader.ReadToEnd();
                return responseText;
            }
        }

        private String getRequstUrl(String lat, String lon)
        {
            string parameters = String.Format("classic.xml?lat={0}&lon={1}", lat, lon);
            return URL + parameters;
        }
    }
}
