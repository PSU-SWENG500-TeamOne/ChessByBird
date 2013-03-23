using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Configuration;
using System.Text.RegularExpressions;
using TweetSharp;

namespace ChessByBird.Twitter
{
    public class TwitterClient
    {
        /// <summary>
        /// Checks for any new tweets after a value
        /// </summary>
        /// <param name="minimumLookup">Nothing before this value will be returned</param>
        /// <param name="maximumLookup">Optional Maximum tweet. Can be skipped</param>
        /// <returns>Tweet ID of the newest tweet</returns>
        public static long areNewTweets(long minimumLookup, long maximumLookup = 9223372036854775800) //Returns the oldest tweet id after the minimum lookup. Returns 0 if none
        {
            long newTweet = 0;
            TwitterService ts = buildService();

            //build options to check for mentions
            var mentionsOptions = new TweetSharp.ListTweetsMentioningMeOptions();
            mentionsOptions.Count = 1;
            mentionsOptions.SinceId = minimumLookup;
            mentionsOptions.MaxId = maximumLookup;

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

        /// <summary>
        /// Gets the newest tweet that ChessByBird has posted, as this is where the system left off
        /// </summary>
        /// <param></param>
        /// <returns>Tweet ID of the newest tweet</returns>
        public static long getNewestTweetFromMe()
        {
            long newestTweet = 0;
            TwitterService ts = buildService();

            IEnumerable<TwitterStatus> myTweets = ts.ListTweetsOnUserTimeline(new ListTweetsOnUserTimelineOptions { ScreenName = "ChessByBird", Count=1});
            List<TwitterStatus> listOfStuff = myTweets.ToList();           
            listOfStuff.ForEach(                    //list only has 0-1 items in it, so forEach is ok
                x =>
                {
                    newestTweet = x.Id;
                }
            );

            //Console.WriteLine(newestTweet.ToString());

            return newestTweet;
        }

        /// <summary>
        /// Get the players, move string, and the URL of the photo
        /// </summary>
        /// <param name="tweetID">Tweet ID of the tweet in question</param>
        /// <returns>Dictionary of keys: dictionary[currentPlayer,otherPlayer,imageURL,moveString]</returns>
        public static Dictionary<String,String> getTweetInfo(long tweetID)
        {
            try
            {
                Dictionary<String, String> usefulInfo = new Dictionary<String, String>(); //dictionary shall contain statusCode, player1, player2, image url, move string
                TwitterService ts = buildService(); ;
                string currentPlayer;
                string otherPlayer;
                string imageURL;
                string moveString;

                //gets 3 tweets: the one requested, the one before it (for the image url) and the one before that (for other player)
                var thatTweet = ts.GetTweet(new GetTweetOptions { Id = tweetID });
                currentPlayer = thatTweet.User.ScreenName.ToString();
                if (thatTweet.Text.ToUpper().Contains("NEW GAME"))
                {
                    otherPlayer = thatTweet.Entities.Mentions[1].ScreenName; //first mention is @chessbybird, 2nd is other player;
                    imageURL = "new game";
                }
                else
                {
                    if (thatTweet.InReplyToStatusId.HasValue)
                    {
                        var respondingTo = ts.GetTweet(new GetTweetOptions { Id = (long)thatTweet.InReplyToStatusId });
                        if (respondingTo.InReplyToStatusId.HasValue)
                        {
                            var previousMove = ts.GetTweet(new GetTweetOptions { Id = (long)respondingTo.InReplyToStatusId });
                            otherPlayer = previousMove.User.ScreenName.ToString();
                        }
                        else
                        {
                            otherPlayer = "not found";
                        }

                        if (respondingTo.Entities.Urls.Count > 0)
                        {
                            string tempURL = respondingTo.Entities.Urls[0].ExpandedValue;

                            Match match = Regex.Match(tempURL, "photos/[^/]+/(?<imgID>[0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                            if (match.Success)
                            {
                                imageURL = match.Groups["imgID"].Value;
                            }
                            else
                            {
                                imageURL = "not found";
                            }
                        }
                        else
                        {
                            imageURL = "not found";
                        }
                    }
                    else
                    {
                        otherPlayer = "not found";
                        imageURL = "not found";
                    }
                }
                
                if (thatTweet.Text.Contains("*"))
                {
                    int startIndex = thatTweet.Text.IndexOf("*");
                    int endIndex = thatTweet.Text.LastIndexOf("*");
                    if (startIndex == endIndex)
                    {
                        moveString = "not found";
                    }
                    else
                    {
                        moveString = thatTweet.Text.Substring(startIndex, endIndex - startIndex + 1);
                        moveString = moveString.Trim(new Char[] { '*' });
                    }
                }
                else
                {
                    moveString = "not found";
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


        /// <summary>
        /// Posts a tweet to the ChessByBird timeline
        /// </summary>
        /// <param name="replyToMe">Tweet ID of what will be responded to. If 0, ignored</param>
        /// <param name="theMessage">Full text of the tweet to post. Be sure to include a @mention for proper delivery</param>
        /// <returns>Boolean of successful post</returns>
        public static Boolean postTweet(long replyToMe, string theMessage)
        {
            try
            {
                Boolean sentSuccessfully = false;
                TwitterService ts = buildService(); 

                if (replyToMe == 0) //new tweet, nonreply
                {
                    TwitterStatus statusSent = ts.SendTweet(new SendTweetOptions { Status = theMessage });
                    System.Threading.Thread.Sleep(5000); //wait for twitter to catch up
                    if (statusSent.Text.ToString() == theMessage)
                    {
                        sentSuccessfully = true;
                    }
                    return sentSuccessfully;
                }
                else
                {
                    TwitterStatus statusSent = ts.SendTweet(new SendTweetOptions { InReplyToStatusId = (long)replyToMe, Status = theMessage });
                    System.Threading.Thread.Sleep(5000); //wait for twitter to catch up
                    sentSuccessfully = true;
                    return sentSuccessfully;
                }
            }
            catch (Exception)
            {
                throw new System.ArgumentException("Cannot send Twitter status", "twitter");
            }
 
            
        }


        /// <summary>
        /// Builds the twitter service using the API keys in the Config file
        /// </summary>
        /// <param></param>
        /// <returns>Working instance of TwitterService</returns>
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


        /// <summary>
        /// Junk function for testing during development
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        static void Mainjunk()
        {

            areNewTweets(500328033800306680);

            postTweet(313438042620821505, "OK @zacharyacarson, i'm making a new game against @zachcarsontest");
            
            
            
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
