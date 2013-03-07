using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Configuration;
using TweetSharp;

namespace ChessByBird.Twitter
{
    class TwitterClient
    {
        public static long areNewTweets(long minimumLookup) //Returns the oldest tweet id after the minimum lookup. Returns 0 if none
        {
            long newTweet = 0;
            TwitterService ts = buildService();

            //build options to check for mentions
            var mentionsOptions = new TweetSharp.ListTweetsMentioningMeOptions();
            mentionsOptions.Count = 1;
            mentionsOptions.SinceId = minimumLookup;

            //get the mentions
            IEnumerable<TwitterStatus> mentions = ts.ListTweetsMentioningMe(mentionsOptions);
            List<TwitterStatus> listOfStuff = mentions.ToList();
            var theCount = listOfStuff.Count;
            listOfStuff.ForEach(                    //list only has 0-1 items in it, so forEach is ok
                x =>
                {
                    newTweet = x.Id;
                }
            );


            return newTweet;
        }



        public static Dictionary<String,String> getTweetInfo()
        {
            Dictionary<String,String> usefulInfo = new Dictionary<String,String>();

            return usefulInfo;
        }

        public static Boolean postTweet()
        {
            Boolean sentSuccessfully = false;

            return sentSuccessfully;
        }

        static TweetSharp.TwitterService buildService()
        {
            string tConsumerKey = "";
            string tConsumerSecret = "";
            string tAccessToken = "";
            string tAccessSecret = "";

            try
            {
                tConsumerKey = ConfigurationManager.AppSettings["TwitterConsumerKey"];
                tConsumerSecret = ConfigurationManager.AppSettings["TwitterConsumerSecret"];
                tAccessToken = ConfigurationManager.AppSettings["TwitterAccessToken"];
                tAccessSecret = ConfigurationManager.AppSettings["TwitterAccessSecret"];
            }
            catch (Exception)
            {
                throw new System.ArgumentException("Error with Twitter keys", "twitter");
            }

            //build twitter connection
            var twitService = new TweetSharp.TwitterService(tConsumerKey, tConsumerSecret, tAccessToken, tAccessSecret);
            return twitService;
        }

        static void Main()
        {

            areNewTweets(500328033800306680);
            
            
            
            
            
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            string tConsumerKey = "";
            string tConsumerSecret = "";
            string tAccessToken = "";
            string tAccessSecret = "";

            try
            {
                tConsumerKey = ConfigurationManager.AppSettings["TwitterConsumerKey"];
                tConsumerSecret = ConfigurationManager.AppSettings["TwitterConsumerSecret"];
                tAccessToken = ConfigurationManager.AppSettings["TwitterAccessToken"];
                tAccessSecret = ConfigurationManager.AppSettings["TwitterAccessSecret"];
            }
            catch (Exception)
            {
                throw new System.ArgumentException("Error with Twitter keys", "twitter");
            }

            //build twitter connection
            var twitService = new TweetSharp.TwitterService(tConsumerKey, tConsumerSecret, tAccessToken, tAccessSecret);

            



            
            
            //build options to check for mentions
            var mentionsOptions = new TweetSharp.ListTweetsMentioningMeOptions();
            mentionsOptions.Count = 20;
            mentionsOptions.SinceId = 300328033800306680;

            //get the mentions
            IEnumerable<TwitterStatus> mentions = twitService.ListTweetsMentioningMe(mentionsOptions);

            List<TwitterStatus> listOfStuff = mentions.ToList();
            listOfStuff.ForEach(
                x =>
                {
                    Console.WriteLine("Now gathering info about tweet #{0}.", x.Id);
                    Console.WriteLine("It is in response to tweet #{0}.", x.InReplyToStatusId);

                    var thatTweet = twitService.GetTweet(new GetTweetOptions { Id = (long)x.InReplyToStatusId });

                    Console.WriteLine("That tweet's text was {0}", thatTweet.Text);
                    Console.WriteLine("More importantly, heres the url it was referencing {0}", thatTweet.Entities.Urls[0].ExpandedValue);

                    string moveString = "not found";

                    if (x.Text.Contains("*"))
                    {
                        int startIndex = x.Text.IndexOf("*");
                        int endIndex = x.Text.LastIndexOf("*");
                        moveString = x.Text.Substring(startIndex, endIndex - startIndex + 1);
                    }
                    Console.WriteLine("The move attached to this tweet was {0}.", moveString);
                }
            );
            Console.WriteLine("End of new API stuff");
        }
    }
}
