﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ChessByBird.FlickrProject;
using System.IO;
using ChessByBird.Chess;

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
                String assetPath = "";
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
                           Dictionary<String, String> dummyInformation = new Dictionary<String, String>();
                           #region logging
                           Console.WriteLine("Data:");
                           Console.WriteLine("  Sender: " + myInformation["currentPlayer"].ToString());
                           Console.WriteLine("  Other Player: " + myInformation["otherPlayer"].ToString());
                           Console.WriteLine("  Move String: " + myInformation["moveString"].ToString());
                           Console.WriteLine("  Reference Image: " + myInformation["imageURL"].ToString());
                           #endregion
                           dummyInformation.Add("currentPlayer", "ZachCarsonTest");
                           dummyInformation.Add("otherPlayer", "ZacharyACarson");
                           dummyInformation.Add("imageURL", "8570458692");
                           dummyInformation.Add("moveString", "e2 e4");

                           //grab the previous game board state
                           //new game board states are null
                           if (myInformation["imageURL"].ToString() == "new game")
                           {
                               gameBoardState = null;
                           }
                           else
                           {
                               //gameBoardState = FlickrClient.getFlickrPic(myInformation["imageURL"].ToString());
                               gameBoardState = FlickrClient.getFlickrPic(dummyInformation["imageURL"].ToString());
                           }

                           //send previous game board state to processChess, with new move
                           //updatedGameBoardState = Chess.Process.processChess(myInformation["moveString"].ToString(), gameBoardState);
                           string dummyGameBoard = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
                           updatedGameBoardState = Chess.Process.processChess(dummyInformation["moveString"].ToString(), dummyGameBoard);

                           //send new boardstate to processImage
                           //assetPath = ProcessImage(updatedGameBoardState);
                           assetPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\DigitalAssets\ChessGameboard.PNG"); //temporary image

                           //post the new image to Flickr, and get the URL
                           Uri imageUri = FlickrClient.postFlickrPic(assetPath, updatedGameBoardState);

                           //post link to Twitter to the important party
                           Twitter.TwitterClient.postTweet(newestTweet, "@" + dummyInformation["otherPlayer"].ToString() + " there is a new move for you from @" + dummyInformation["currentPlayer"].ToString() + " " + imageUri);

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
                       
                       System.Threading.Thread.Sleep(3000); //wait 3 seconds, check again
                   }
                        
                //end loop
            }
            //Catch all issues
            catch {
                //PostTweet(Issue) 

                Guid randomText = Guid.NewGuid();

                string dummyText = "An error occured, CBB is closing. Useless GUID: " + randomText.ToString();
                Twitter.TwitterClient.postTweet(0, dummyText);
            }
        }
    }
}
