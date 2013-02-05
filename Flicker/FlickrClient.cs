using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net;
using System.Json;


namespace ChessByBird.FlickerProject
{
    class FlickrClient
    {
         
        Image newImage = Image.FromFile("SampImage.jpg");

        public static bool getFlickerPic()
        {
            string urlJson = String.Format("https://www.flickr.com");
            WebClient serviceRequest = new WebClient();
            string responseJson = serviceRequest.DownloadString(new Uri(urlJson));
            return true;
        }

        public static bool postFlickerPic()
        {
            return true;
        }
    }
}
