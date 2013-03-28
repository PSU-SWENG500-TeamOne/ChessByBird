using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
//using ChessByBird.Chess;
//using ChessByBird.FlickrProject;


namespace ChessByBird
{
    class ChessByBird
    {

        static void Main()
        {
           
            
            //TODO: these will all be removed later
           // string gameBoardState ="";
           // string PhotoID = "";
          //  string assetPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\DigitalAssets\ChessGameboard.PNG");
   
            try
            {
                //How to do chess stuff
                String gameBoardState = "";
                String updatedGameBoardState = "";

                // ImagerClient arguments
                string whitePlayerName = "Zach";
                string blackPlayerName = "Joe";
                string assetPath = "";


                //Process newProcess = new Process();
                //String newBoard = newProcess.processChess(chessmove, gameBoardState);
                //System.Console.WriteLine(newBoard);
                //System.Console.WriteLine();
             
                //post start up tweet, save its value for referencing

                Guid randomText = Guid.NewGuid();

                string dummyText = "System live! Random key: " + randomText.ToString();

                Twitter.TwitterClient.postTweet(0, dummyText);
                System.Threading.Thread.Sleep(5000); //wait for twitter to catch up
                long referentialID = Twitter.TwitterClient.getNewestTweetFromMe();
                long newestTweet = 0;


                //Processing Loop
                    while (true)
                   {
                       newestTweet = Twitter.TwitterClient.areNewTweets(referentialID);
                       if (newestTweet > 0)
                       {
                           //grab information about the tweet
                           Console.WriteLine("Begin processing " + newestTweet.ToString());
                           Dictionary<String, String> myInformation = Twitter.TwitterClient.getTweetInfo(newestTweet); //dictionary[currentPlayer,otherPlayer,imageURL,moveString]
                           #region logging
                           Console.WriteLine("Data:");
                           Console.WriteLine("  Sender: " + myInformation["currentPlayer"].ToString());
                           Console.WriteLine("  Other Player: " + myInformation["otherPlayer"].ToString());
                           Console.WriteLine("  Move String: " + myInformation["moveString"].ToString());
                           Console.WriteLine("  Reference Image: " + myInformation["imageURL"].ToString());
                           #endregion

                           //Dictionary<String, String> dummyInformation = new Dictionary<String, String>();
                           //dummyInformation.Add("currentPlayer", "ZachCarsonTest");
                           //dummyInformation.Add("otherPlayer", "ZacharyACarson");
                           //dummyInformation.Add("imageURL", "8570458692");
                           //dummyInformation.Add("moveString", "e2 e4");

                           //grab the previous game board state
                           //new game board states are null
                           if (myInformation["imageURL"].ToString() == "new game")
                           {
                               gameBoardState = null;
                               Console.WriteLine();
                               Console.WriteLine("  New game, building a new board");
                           }
                           else
                           {
                              gameBoardState = FlickrProject.FlickrClient.getFlickrPic(myInformation["imageURL"].ToString());
                              Console.WriteLine();
                              Console.WriteLine("  Got previous state: " + gameBoardState);
                           }

                           //send previous game board state to processChess, with new move
                           updatedGameBoardState = Chess.Process.processChess(myInformation["moveString"].ToString(), gameBoardState);
                           Console.WriteLine();
                           Console.WriteLine("  Move is ok, new state is " + updatedGameBoardState);
                           
                           //send new boardstate to processImage
                           assetPath = ImageClient.ImageClient.processImage(updatedGameBoardState, myInformation["currentPlayer"], myInformation["otherPlayer"]);
                           //assetPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\DigitalAssets\ChessGameboard.PNG"); //temporary image
                           Console.WriteLine();
                           Console.WriteLine("  Image built");

                           //post the new image to Flickr, and get the URL
                           Uri imageUri = FlickrProject.FlickrClient.postFlickrPic(assetPath, updatedGameBoardState);
                           Console.WriteLine();
                           Console.WriteLine("  Uploaded. Image at " + imageUri.ToString());

                           //post link to Twitter to the important party
                           Twitter.TwitterClient.postTweet(newestTweet, "@" + myInformation["otherPlayer"].ToString() + " there is a new move for you from @" + myInformation["currentPlayer"].ToString() + " " + imageUri);
                           Console.WriteLine();
                           Console.WriteLine("  Tweeted!");

                           //update lastest tweet mark to reflect new changes
                           referentialID = newestTweet;
                           #region logging
                           Console.WriteLine("Done with " + newestTweet.ToString());
                           Console.WriteLine(); 
                           #endregion
                       }
                       else
                       {
                           Console.WriteLine("Nothing to process, sleeping");
                           Console.WriteLine();
                       }

                       System.Threading.Thread.Sleep(65000); //wait 65 seconds, check again. twitter has a rate limit of 15 per 15min window
                   }
                        
                //end loop
            }
            //Catch all issues
			catch (Exception ex)
            {
                //PostTweet(Issue) 
                Console.WriteLine();
                Console.WriteLine("ERROR OCCURED");
                Console.WriteLine();
                Console.WriteLine(ex.ToString());
                Console.WriteLine();
            }

            finally
            {
                 Guid randomText = Guid.NewGuid();

                string dummyText = "System shutting down "+ randomText.ToString();
                 Twitter.TwitterClient.postTweet(0, dummyText);
             }

        }
    }
}
