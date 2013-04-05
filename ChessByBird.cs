﻿/*******************************************************************************
 *  Penn State University Software Engineering Graduate Program
 *  Authors: Team 1: Zachary Carson, Aaron Eugene, Steve Haggerty, Joseph Oakes
 *  Date: Spring 2013
 *  Course: SWENG 500 Software Engineering Studio
 *  Professor: Mohamad Kassab
 *  Project: Chess By Bird Capstone group project
*******************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using ChessByBird.ImagingProject;
using ChessByBird.FlickrProject;
using ChessByBird.TwitterProject;

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


            //How to do chess stuff
            String gameBoardState = "";
            String updatedGameBoardState = "";

            // ImagerClient arguments
            //string whitePlayerName = "Zach";
            //string blackPlayerName = "Joe";
            string assetPath = "";

            //Process newProcess = new Process();
            //String newBoard = newProcess.processChess(chessmove, gameBoardState);
            //System.Console.WriteLine(newBoard);
            //System.Console.WriteLine();

            //post start up tweet, save its value for referencing
            Guid randomText = Guid.NewGuid();

            string dummyText = "System live! Random key: " + randomText.ToString();

            TwitterClient.postTweet(0, dummyText);
            System.Threading.Thread.Sleep(5000); //wait for twitter to catch up
            long referentialID = TwitterClient.getNewestTweetFromMe();
            long newestTweet = 0;


            //Processing Loop
            while (true)
            {
                try
                {
                    newestTweet = TwitterClient.areNewTweets(referentialID);
                    if (newestTweet > 0)
                    {
                        //grab information about the tweet
                        Console.WriteLine("Begin processing " + newestTweet.ToString());
                        Dictionary<String, String> myInformation = TwitterClient.getTweetInfo(newestTweet); //dictionary[currentPlayer,otherPlayer,imageURL,moveString]
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
                            gameBoardState = FlickrClient.getFlickrPic(myInformation["imageURL"].ToString());
                            Console.WriteLine();
                            Console.WriteLine("  Got previous state: " + gameBoardState);
                        }

                        //send previous game board state to processChess, with new move
                        updatedGameBoardState = ChessClient.Process.processChess(myInformation["moveString"].ToString(), gameBoardState);
                        bool whitesTurn = ChessClient.Process.IsWhiteMove(updatedGameBoardState);
                        Console.WriteLine();
                        Console.WriteLine("  Move is ok, new state is " + updatedGameBoardState);
                        if (whitesTurn)
                        {
                            Console.WriteLine("  and it is White's turn");
                        }
                        else
                        {
                            Console.WriteLine("  and it is Black's turn");
                        }

                        //send new boardstate to processImage
                        if (whitesTurn)
                        {
                            assetPath = ImagerClient.processImage(updatedGameBoardState, myInformation["otherPlayer"], myInformation["currentPlayer"]);
                        }
                        else
                        {
                            assetPath = ImagerClient.processImage(updatedGameBoardState, myInformation["currentPlayer"], myInformation["otherPlayer"]);
                        }

                        Console.WriteLine();
                        Console.WriteLine("  Image built");

                        //post the new image to Flickr, and get the URL
                        Uri imageUri = FlickrClient.postFlickrPic(assetPath, updatedGameBoardState);
                        Console.WriteLine();
                        Console.WriteLine("  Uploaded. Image at " + imageUri.ToString());

                        //post link to Twitter to the important party
                        TwitterClient.postTweet(newestTweet, "@" + myInformation["otherPlayer"].ToString() + " there is a new move for you from @" + myInformation["currentPlayer"].ToString() + " " + imageUri);
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
                //Catch all issues
                catch (Exception ex)
                {
                    //report the error
                    Console.WriteLine();
                    Console.WriteLine("ERROR OCCURED");
                    Console.WriteLine();
                    Console.WriteLine(ex.ToString());
                    Console.WriteLine();

                    //report to the user that something screwed up
                    TwitterClient.TwitterClient.postTweet(newestTweet, "Something went wrong, please wait a few minutes and try again");
                    //increment the counter to get away from the erroneous tweet
                    referentialID = newestTweet;
                    //do normal sleeping
                    System.Threading.Thread.Sleep(65000);
                }
                //end loop
            }
        }
    }
}