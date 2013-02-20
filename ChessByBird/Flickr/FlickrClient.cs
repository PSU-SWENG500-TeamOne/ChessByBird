/********************************************
 *  Penn State University Software Engineering Graduate Program
 *  Authors: Team 1: Zachary Carson, Aaron Eugene, Steve Haggerty, Joseph Oakes
 *  Date: Spring 2013
 *  Course: SWENG 500 Software Engineering Studio
 *  Professor: Mohamad Kassab
 *  Project: Chess By Bird Capstone group project
*********************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net;
/********************************************
 *  Penn State University Software Engineering Graduate Program
 *  Authors: Team 1: Zachary Carson, Aaron Eugene, Steve Haggerty, Joseph Oakes
 *  Date: Spring 2013
 *  Course: SWENG 500 Software Engineering Studio
 *  Professor: Mohamad Kassab
 *  Project: Chess By Bird Capstone group project
*********************************************/
using System.IO;
using System.Web;
using FlickrNet;
using System.Configuration;

namespace ChessByBird.FlickrProject
{
    public class FlickrClient
    {

        /// <summary>
        /// Using the PhotoID gets the Photo Description (Contains FEN Move) from Flickr
        /// </summary>
        /// <param name="photoID">The Flickr Photo ID to get</param>
        /// <returns>The FEN Chess Move</returns>
        public static string getFlickrPic(string photoID)
        {
            try
            {
                string consumerKey = ConfigurationManager.AppSettings["consumerKey"];
                Flickr flickr = new Flickr(consumerKey);
                PhotoInfo photoInfo = flickr.PhotosGetInfo(photoID);  //ChessBoard
                string photoTitle = photoInfo.Title;
                return photoInfo.Description;  //This has the FEN move
            }
            catch (Exception)
            {
                throw new System.ArgumentException("Cannot get Flickr image", "flickr");
            }
        }

        /// <summary>
        /// This will post the picture to flickr with a photo description the FEN Move
        /// </summary>
        /// <param name="assetPath">Flie Location of Image</param>
        /// <param name="GameBoardState">Chess FEN Move to add to Photo Description</param>
        public static Uri postFlickrPic(string assetPath, string GameBoardState)
        {
            try
            {
                string consumerKey = ConfigurationManager.AppSettings["consumerKey"];
                string consumerSecret = ConfigurationManager.AppSettings["consumerSecret"];
                Flickr flickr = new Flickr(consumerKey, consumerSecret);
                //Step 1 Request a Token
                //OAuthRequestToken OAuthRequestToken = flickr.OAuthGetRequestToken("oob");

                //Step 2 User Authorization
                //string url = flickr.OAuthCalculateAuthorizationUrl(OAuthRequestToken.Token, AuthLevel.Write);
                //This step is needed to get the verifier code only once for the application
                //System.Diagnostics.Process.Start(url);

                //Step 3 Get the Access Token for the application
                //string Verifier = "244-040-435";
                //string requestToken = "72157632741560142-76d6212140a1f3bf";
                //string requestTokenSecret = "53ae3f7e58e24e2e";
                //OAuthAccessToken AccessToken = flickr.OAuthGetAccessToken(requestToken, requestTokenSecret, Verifier);

                //This is the Application Access Token
                string OAuthAccessToken = ConfigurationManager.AppSettings["OAuthAccessToken"];
                string OAuthAccessTokenSecret = ConfigurationManager.AppSettings["OAuthAccessTokenSecret"];

                //TODO: Image must be set to public 
                string file = assetPath;
                string title = "Test Chess Photo";
                string tags = "tag1,tag2,tag3";
                string photoId = flickr.UploadPicture(file, title, GameBoardState, tags);
                //TODO - fix to use proper Uri
                Uri siteUri = new Uri("http://www.flickr.com/");
                return siteUri;
            }
            catch (Exception)
            {
                throw new System.ArgumentException("Cannot save Flickr image", "flickr");
            }
        }


    }
}
