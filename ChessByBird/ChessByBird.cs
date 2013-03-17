using System;
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
                //Loop Check for getTweet()
                    //If it is the first move do not the getFlickr Pic
                 //       gameBoardState = FlickrClient.getFlickrPic(PhotoID);

                String chessmove = "a2 a3";
                String gameBoardState = null;
                Process newProcess = new Process();
                String newBoard = newProcess.processChess(chessmove, gameBoardState);
                System.Console.WriteLine(newBoard);
                System.Console.WriteLine();
                    //assetPath = ProcessImage(updatedGameBoardState)
                //    Uri imageUri = FlickrClient.postFlickrPic(assetPath, gameBoardState);
                //PostTweet(imageUri)                    
                //end loop
            }
            //Catch all issues
            catch {
                //PostTweet(Issue) 
            }
        }
    }
}
