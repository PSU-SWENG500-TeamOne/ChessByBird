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
            WebClient serviceRequest = new WebClient();
            String responseJson;
            String flickrURLSigningRequest;
            String oauth_callback_confirmed;
            String oauth_token;
            String oauth_token_secret;
            String oauth_verifier;
            String fullname;
            String user_nsid;
            String username;
            dynamic JSONDoc;

            //Non-web based app
            /* http://flickr.com/services/auth/?api_key=[api_key]&perms=[perms]&frob=[frob]&api_sig=[api_sig] */

            //This process is documented http://www.flickr.com/services/api/auth.oauth.html#request_token

            //Step 1 Get a Request Token Flickr returns Request Token
            //TODO: figure out all the flickr values below
            flickrURLSigningRequest = "http://www.flickr.com/services/oauth/request_token";
            flickrURLSigningRequest += "?oauth_nonce="; //e.g. 89601180
            flickrURLSigningRequest += "&oauth_timestamp="; //e.g. 1305583298
            flickrURLSigningRequest += "&oauth_consumer_key="; //e.g. 653e7a6ecc1d528c516cc8f92cf98611
            flickrURLSigningRequest += "&oauth_signature_method=HMAC-SHA1";
            flickrURLSigningRequest += "&oauth_version=1.0";
            flickrURLSigningRequest += "&oauth_callback="; //e.g. http%3A%2F%2Fwww.example.com

            //Handle Flickr Token response
            responseJson = serviceRequest.DownloadString(new Uri(flickrURLSigningRequest));
            JSONDoc = (JsonObject)JsonObject.Parse(responseJson);
            if (JSONDoc.Count > 0)
            {
                oauth_callback_confirmed = JSONDoc["oauth_callback_confirmed"];  //e.g. true
                oauth_token = JSONDoc["oauth_token"];  //e.g. 72157626737672178-022bbd2f4c2f3432
                oauth_token_secret = JSONDoc["oauth_token_secret"]; //e.g. fccb68c4e6103197
            }

            //Step 2 Get a Authorization Flickr returns callback authorization
            flickrURLSigningRequest = "http://www.flickr.com/services/oauth/authorize";
            flickrURLSigningRequest += "?oauth_token="; //e.g. 72157626737672178-022bbd2f4c2f3432
            
            //Handle Flickr Authorization response
            responseJson = serviceRequest.DownloadString(new Uri(flickrURLSigningRequest));
            JSONDoc = (JsonObject)JsonObject.Parse(responseJson);
            if (JSONDoc.Count > 0)
            {
                //http://www.example.com/
                oauth_token = JSONDoc["oauth_token"];  //e.g. 72157626737672178-022bbd2f4c2f3432
                oauth_verifier = JSONDoc["oauth_verifier"]; //e.g. 5d1b96a26b494074
            }

            //Step 3 Exchange the Request Token for an Access Token
            flickrURLSigningRequest = "http://www.flickr.com/services/oauth/access_token";
            flickrURLSigningRequest += "?oauth_nonce="; //e.g. 89601180
            flickrURLSigningRequest += "&oauth_timestamp="; //e.g. 1305583298
            flickrURLSigningRequest += "&oauth_verifier="; //e.g. 5d1b96a26b494074
            flickrURLSigningRequest += "&oauth_consumer_key="; //e.g. 653e7a6ecc1d528c516cc8f92cf98611
            flickrURLSigningRequest += "&oauth_signature_method=HMAC-SHA1";
            flickrURLSigningRequest += "&oauth_version=1.0";
            flickrURLSigningRequest += "&oauth_token="; //e.g. 72157626737672178-022bbd2f4c2f3432
            flickrURLSigningRequest += "&oauth_signature="; //e.g. UD9TGXzrvLIb0Ar5ynqvzatM58U%3D

            //Handle Flickr Access Token response
            responseJson = serviceRequest.DownloadString(new Uri(flickrURLSigningRequest));
            JSONDoc = (JsonObject)JsonObject.Parse(responseJson);
            if (JSONDoc.Count > 0)
            {
                fullname = JSONDoc["fullname"];  //e.g. fullname=Jamal%20Fanaian
                oauth_token = JSONDoc["oauth_token"]; //e.g. 72157626737672178-022bbd2f4c2f3432
                oauth_token_secret = JSONDoc["oauth_token_secret"]; //e.g. a202d1f853ec69de
                user_nsid = JSONDoc["user_nsid"]; //e.g. 21207597%40N07
                username = JSONDoc["username"]; //e.g. jamalfanaian
            }

            return true;

           
        }
    }
}
