using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ChessByBird.FlickrProject;
using System.IO;

namespace ChessByBird
{
    class ChessByBird
    {

        static void Main()
        {
            //TODO: these will all be removed later
            string gameBoardState ="";
            string PhotoID = "";
            string assetPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\DigitalAssets\ChessGameboard.PNG");
   
            try
            {
<<<<<<< HEAD
                //Loop Check for getTweet()
                    //If it is the first move do not the getFlickr Pic
                        gameBoardState = FlickrClient.getFlickrPic(PhotoID);
                    //updatedGameBoardState = ProcessChess(chessMove, gameBoardState)
                    //assetPath = ProcessImage(updatedGameBoardState)
                    Uri imageUri = FlickrClient.postFlickrPic(assetPath, gameBoardState);
                //PostTweet(imageUri)                    
=======
                //post start up tweet, save its value for referencing

                Guid randomText = Guid.NewGuid();

                string dummyText = "System live! Random key: " + randomText.ToString();

                Twitter.TwitterClient.postTweet(0, dummyText);
                System.Threading.Thread.Sleep(5000); //wait for twitter to catch up
                long referentialID = Twitter.TwitterClient.getNewestTweetFromMe();

                //Loop Check for areNewTweets()
                   while (true)
                   {
                       long newestTweet = Twitter.TwitterClient.areNewTweets(referentialID);
                       if (newestTweet > 0)
                       {
                           Dictionary<String, String> myInformation = Twitter.TwitterClient.getTweetInfo(newestTweet); //dictionary[currentPlayer,otherPlayer,imageURL,moveString]

                           if (true)
                           { }
                           //If it is the first move do not the getFlickr Pic
                           gameBoardState = FlickrClient.getFlickrPic(PhotoID);
                           //updatedGameBoardState = ProcessChess(chessMove, gameBoardState)
                           //assetPath = ProcessImage(updatedGameBoardState)
                           Uri imageUri = FlickrClient.postFlickrPic(assetPath, gameBoardState);
                           //PostTweet(imageUri)
                       }
                       referentialID = newestTweet;
                       System.Threading.Thread.Sleep(30000); //wait 30 seconds, check again
                   }
                                        
>>>>>>> TwitterBranch
                //end loop
            }
            //Catch all issues
            catch {
                //PostTweet(Issue) 
<<<<<<< HEAD
=======
                Guid randomText = Guid.NewGuid();

                string dummyText = "An error occured, CBB is closing. Useless GUID: " + randomText.ToString();
                Twitter.TwitterClient.postTweet(0, dummyText);
>>>>>>> TwitterBranch
            }
        }
    }
}
