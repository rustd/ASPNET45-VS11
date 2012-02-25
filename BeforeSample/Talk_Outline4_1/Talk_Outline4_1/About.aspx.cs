using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

namespace Talk_Outline4_1
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = "My .Ramblings - About";
            string desturl = "http://wsf.cdyne.com/WeatherWS/Weather.asmx/GetCityWeatherByZIP?ZIP=98101";
            WebClient client = new WebClient();
            System.Uri dest = new Uri(desturl);

            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
            
            client.DownloadStringAsync(dest);
        }

        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Result.ToLower().Contains("rain"))
            {
                currentWeather.Src = "~/Media/Images/rain.png";
            }
            if (e.Result.ToLower().Contains("cloud"))
            {
                currentWeather.Src = "~/Media/Images/cloudy.png";
            }
            if (e.Result.ToLower().Contains("sun"))
            {
                currentWeather.Src = "~/Media/Images/sunny.png";
            }
            else
            {
                currentWeather.Src = "~/Media/Images/cloudy.png";
            }
        }
    }
}