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
            string move;
            string PhotoID = "";
            string assetPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\DigitalAssets\ChessGameboard.PNG");
  
            try
            {
                //Loop Check for Tweet
                    //If it is the first move do not the getFlickr Pic
                    move = FlickrClient.getFlickrPic(PhotoID);
                    //ProcessChess(move)
                    //ProcessImage()
                    //PostTweet()
                    FlickrClient.postFlickrPic(assetPath, PhotoID);
            }
            //Catch all issues
            catch { }
        }
    }
}
