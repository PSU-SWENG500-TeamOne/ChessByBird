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
using System.Json;
using System.IO;
using System.Web;
using System.Collections.Specialized;
using FlickrNet;

namespace ChessByBird.FlickrProject
{
    public class FlickrClient
    {

        static void Main()
        {

        }
  
        public static bool getFlickrPic(string photoID, out string photoDescription)
        {
            string consumerKey = "8d25fce60055946ae5f7e1dff9a5b955";
            try
            {
                Flickr flickr = new Flickr(consumerKey);
                PhotoInfo photoInfo = flickr.PhotosGetInfo(photoID);  //ChessBoard
                string photoTitle = photoInfo.Title;
                photoDescription = photoInfo.Description;  //This has the FEN move
                return true;
            }
            catch (WebException)
            {
                photoDescription = "Error: Could not get the Image from Flickr";
                return false;
            }
            catch (Exception)
            {
                photoDescription = "Error: Could not get the Image from Flickr";
                return false;
            }

        }

        public static bool postFlickrPic(string photoDescription)
        {
            string consumerKey = "8d25fce60055946ae5f7e1dff9a5b955";
            string consumerSecret = "0d89b50f8cc4ab5f";

            try
            {
                String assetPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\DigitalAssets\ChessGameboard.PNG");
                Image chessGameboardImage = Image.FromFile(assetPath);

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

                //This the Application Access Token
                flickr.OAuthAccessToken = "72157632734925979-90e9a569b563b919";
                flickr.OAuthAccessTokenSecret = "8b330063711bb116";

                //TODO: Image must be set to public 
                string file = assetPath;
                string title = "Test Chess Photo";
                string tags = "tag1,tag2,tag3";
                string photoId = flickr.UploadPicture(file, title, photoDescription, tags);

                return true;
            }
            catch (FileNotFoundException ex)
            {
                //TODO: Email or log ex
                return false;
            }
            catch (WebException ex)
            {
                //TODO: Email or log ex
                return false;
            }
            catch (Exception ex)
            {
                //TODO: Email or log ex
                return false;
            }
        }


    }
}
