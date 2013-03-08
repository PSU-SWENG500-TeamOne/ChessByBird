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
    public class TwitterClient
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



        public static Dictionary<String,String> getTweetInfo(long tweetID)
        {
            try
            {
                Dictionary<String, String> usefulInfo = new Dictionary<String, String>(); //dictionary shall contain player1, player2, image url, move string
                TwitterService ts = buildService();
                string currentPlayer;
                string otherPlayer;
                string imageURL;
                string moveString;

                //gets 3 tweets: the one requested, the one before it (for the image url) and the one before that (for other player)
                var thatTweet = ts.GetTweet(new GetTweetOptions { Id = tweetID });
                currentPlayer = thatTweet.User.ScreenName.ToString();

                if (thatTweet.InReplyToStatusId.HasValue)
                {
                    var respondingTo = ts.GetTweet(new GetTweetOptions { Id = (long)thatTweet.InReplyToStatusId });
                    if (respondingTo.InReplyToStatusId.HasValue)
                    {
                        var previousMove = ts.GetTweet(new GetTweetOptions { Id = (long)respondingTo.InReplyToStatusId });
                        otherPlayer = respondingTo.User.ScreenName.ToString();
                    }
                    else
                    {
                        otherPlayer = "not found";
                    }
                }
                else
                {
                    otherPlayer = "not found";
                }

                if (thatTweet.Text.Contains("*"))
                {
                    int startIndex = thatTweet.Text.IndexOf("*");
                    int endIndex = thatTweet.Text.LastIndexOf("*");
                    moveString = thatTweet.Text.Substring(startIndex, endIndex - startIndex + 1);
                }
                else
                {
                    moveString = "not found";
                }

                if (thatTweet.Entities.Urls.Count > 0)
                {
                    imageURL = thatTweet.Entities.Urls[0].ExpandedValue;
                }
                else
                {
                    imageURL = "not found";
                }

                usefulInfo.Add("currentPlayer", currentPlayer);
                usefulInfo.Add("otherPlayer", otherPlayer);
                usefulInfo.Add("imageURL", imageURL);
                usefulInfo.Add("moveString", moveString);

                return usefulInfo;
            }
            catch (Exception)
            {
                throw new System.ArgumentException("Cannot get tweet information", "twitter");
            }
            
        }



        public static Boolean postTweet(long replyToMe, string theMessage)
        {
            try
            {
                Boolean sentSuccessfully = false;
                TwitterService ts = buildService(); 
                var statusSent = ts.SendTweet(new SendTweetOptions { InReplyToStatusId = (long)replyToMe, Status = theMessage });
                if (statusSent.Text.ToString() == theMessage)
                {
                    sentSuccessfully = true;
                }
                return sentSuccessfully;
            }
            catch (Exception)
            {
                throw new System.ArgumentException("Cannot send Twitter status", "twitter");
            }
 
            
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

        static void MainJunk()
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
