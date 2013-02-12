using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Json;

namespace ChessByBird.TwitterProject
{
    class TwitterClient
    {
        public static bool getTweet()
        {
            string urlJson = String.Format("http://www.twitter.com");
            WebClient serviceRequest = new WebClient();
            string responseJson = serviceRequest.DownloadString(new Uri(urlJson));

            dynamic JSONDoc = (JsonObject)JsonObject.Parse(responseJson);
            if (JSONDoc.Count > 0)
            {
                string nodeName = JSONDoc["nodeName"];
                string node = null;
            }

            return true;
        }

        public static bool postTweet()
        {
            return true;
        }


    }
}
