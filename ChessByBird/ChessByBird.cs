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
                //Loop Check for getTweet()
                    //If it is the first move do not the getFlickr Pic
                        gameBoardState = FlickrClient.getFlickrPic(PhotoID);
                    //updatedGameBoardState = ProcessChess(chessMove, gameBoardState)
                    //assetPath = ProcessImage(updatedGameBoardState)
                    //URL = FlickrClient.postFlickrPic(assetPath, gameBoardState);
                    //PostTweet(URL)                    
                //end loop
            }
            //Catch all issues
            catch {
                //PostTweet(Issue) 
            }
        }
    }
}
