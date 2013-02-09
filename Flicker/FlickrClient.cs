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


namespace ChessByBird.FlickrProject
{
    public class FlickrClient
    {
         
  
        public static bool getFlickrPic()
        {
            try{

            //failure -- jsonFlickrApi({"stat":"fail", "code":99, "message":"Insufficient permissions. Method requires read privileges; none granted."})
            string urlJson = String.Format("http://www.flickr.com/services/rest/?method=flickr.test.echo&format=json&api_key=f9530d496325c2983a4fe9b9e51b1e86");
            WebClient serviceRequest = new WebClient();
            string responseJson = serviceRequest.DownloadString(new Uri(urlJson));

            dynamic JSONDoc = (JsonObject)JsonObject.Parse(responseJson);
                if (JSONDoc.Count > 0)
                {
                   string nodeName = JSONDoc["nodeName"];
                }
                return true;
            }
            catch (WebException ex) {
                //TODO: Email or log ex
                return false;
            }

        }

        public static bool postFlickrPic()
        {
            try
            {
                String assetPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\DigitalAssets\ChessGameboard.PNG");
                Image chessGameboardImage = Image.FromFile(assetPath);

                /* http://www.flickr.com/services/api/upload.api.html
                 * http://api.flickr.com/services/upload/ */
                //failure -- jsonFlickrApi({"stat":"fail", "code":99, "message":"Insufficient permissions. Method requires read privileges; none granted."})
                string urlJson = String.Format("http://www.flickr.com/services/rest/?method=flickr.test.echo&format=json&api_key=f9530d496325c2983a4fe9b9e51b1e86");
                WebClient serviceRequest = new WebClient();
                string responseJson = serviceRequest.DownloadString(new Uri(urlJson));

                dynamic JSONDoc = (JsonObject)JsonObject.Parse(responseJson);
                if (JSONDoc.Count > 0)
                {
                    string nodeName = JSONDoc["nodeName"];
                }
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

        public static bool authenticateFlickr()
        {
            //Non-web based app
            /* http://flickr.com/services/auth/?api_key=[api_key]&perms=[perms]&frob=[frob]&api_sig=[api_sig] */

            //Step 1 Get a Request Token Flickr returns Request Token
            String flickrURLSigningRequest = "http://www.flickr.com/services/oauth/request_token";
            flickrURLSigningRequest += "?oauth_nonce="; //89601180
            flickrURLSigningRequest += "&oauth_timestamp="; //1305583298
            flickrURLSigningRequest += "&oauth_consumer_key="; //653e7a6ecc1d528c516cc8f92cf98611
            flickrURLSigningRequest += "&oauth_signature_method=HMAC-SHA1";
            flickrURLSigningRequest += "&oauth_version=1.0";
            flickrURLSigningRequest += "&oauth_callback="; //http%3A%2F%2Fwww.example.com

            //TODO: Handle Flickr Token response
            //oauth_callback_confirmed=true
            //&oauth_token=72157626737672178-022bbd2f4c2f3432
            //&oauth_token_secret=fccb68c4e6103197

            //Step 2 Get a Authorization Flickr returns callback authorization
            flickrURLSigningRequest = "http://www.flickr.com/services/oauth/authorize";
            flickrURLSigningRequest += "?oauth_token="; //72157626737672178-022bbd2f4c2f3432
            
            //TODO: Handle Flickr Authorization response
            //http://www.example.com/
            //?oauth_token=72157626737672178-022bbd2f4c2f3432
            //&oauth_verifier=5d1b96a26b494074

            //Step 3 Exchange the Request Token for an Access Token
            flickrURLSigningRequest = "http://www.flickr.com/services/oauth/access_token";
            flickrURLSigningRequest += "?oauth_nonce="; //89601180
            flickrURLSigningRequest += "&oauth_timestamp="; //1305583298
            flickrURLSigningRequest += "&oauth_verifier="; //5d1b96a26b494074
            flickrURLSigningRequest += "&oauth_consumer_key="; //653e7a6ecc1d528c516cc8f92cf98611
            flickrURLSigningRequest += "&oauth_signature_method=HMAC-SHA1";
            flickrURLSigningRequest += "&oauth_version=1.0";
            flickrURLSigningRequest += "&oauth_token="; //72157626737672178-022bbd2f4c2f3432
            flickrURLSigningRequest += "&oauth_signature="; //UD9TGXzrvLIb0Ar5ynqvzatM58U%3D

            //TODO: Handle Flickr response
            //fullname=Jamal%20Fanaian
            //&oauth_token=72157626318069415-087bfc7b5816092c
            //&oauth_token_secret=a202d1f853ec69de
            //&user_nsid=21207597%40N07
            //&username=jamalfanaian

            return true;

           
        }
    }
}
