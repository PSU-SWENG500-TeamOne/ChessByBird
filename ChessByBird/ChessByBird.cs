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
                //Initialize the twitter object - can remember what it has looked it
                do
                {
                    System.Threading.Thread.Sleep(25000);   //Sleep 25 seconds
                    //getTweet() //returns - two player, URL(PhotoID) and proposed move
                    //If it is the first move do not the getFlickr Pic
                    gameBoardState = FlickrClient.getFlickrPic(PhotoID);
                    //updatedGameBoardState = ProcessChess(chessMove, gameBoardState)
                    //assetPath = ProcessImage(updatedGameBoardState)
                    Uri imageUri = FlickrClient.postFlickrPic(assetPath, gameBoardState);
                    //PostTweet(imageUri, players, original tweetID) 
                }
                while (true);
            }
            //Catch all issues
            catch {
                //PostTweet(Issue, original tweetID) 
            }
        }
    }
}
