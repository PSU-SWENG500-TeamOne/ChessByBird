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
            string urlJson = String.Format("http://www.flickr.com/services/rest/?method=flickr.test.echo&format=json&api_key=f9530d496325c2983a4fe9b9e51b1e86");
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
