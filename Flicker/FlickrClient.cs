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
         
  
        public static bool getFlickrPic()
        {
            string consumerKey = "8d25fce60055946ae5f7e1dff9a5b955";

            try
            {

                Flickr flickr = new Flickr(consumerKey);

                // Get information about photo 936265426
                PhotoInfo photoInfo = flickr.PhotosGetInfo("8461965291");  //ChessBoard

                // Display the title
                string photTitle = photoInfo.Title;
                return true;
            }
            catch (WebException ex)
            {
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
                //failure example -- jsonFlickrApi({"stat":"fail", "code":99, "message":"Insufficient permissions. Method requires read privileges; none granted."})
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
            string responseJson;
            string responseString;
            string flickrURLSigningRequest;
            string oauth_callback_confirmed;
            string oauth_token = "";
            string oauth_token_secret = "";
            string oauth_verifier = "";
            string fullname;
            string user_nsid;
            string username;
            string timestamp; // timestamp
            string nonce; //nonce valu
            string consumerKey = "8d25fce60055946ae5f7e1dff9a5b955";
            string consumerSecret = "0d89b50f8cc4ab5f";
            string callback = "oob"; //Out of Band
            dynamic JSONDoc;

            //Non-web based app usng OAuth with Flickr
            /* http://flickr.com/services/auth/?api_key=[api_key]&perms=[perms]&frob=[frob]&api_sig=[api_sig] */

            //This process is documented http://www.flickr.com/services/api/auth.oauth.html#request_token

            //Step 1 Get a Request Token Flickr returns Request Token
            OAuthBase oauth = new OAuthBase();
           
            timestamp = oauth.GenerateTimeStamp();
            nonce = oauth.GenerateNonce();
            Uri rq = new Uri("http://www.flickr.com/services/oauth/request_token");
            string url, url2;
            string signature = oauth.GenerateSignature(rq, callback, consumerKey, consumerSecret, null, null, "GET", timestamp,
                nonce, OAuthBase.SignatureTypes.HMACSHA1, out url, out url2);

            flickrURLSigningRequest = "http://www.flickr.com/services/oauth/request_token";
            flickrURLSigningRequest += "?oauth_nonce=" +  HttpUtility.UrlEncode(nonce);
            flickrURLSigningRequest += "&oauth_timestamp=" + timestamp;
            flickrURLSigningRequest += "&oauth_consumer_key=" +  HttpUtility.UrlEncode(consumerKey);
            flickrURLSigningRequest += "&oauth_signature_method=HMAC-SHA1";
            flickrURLSigningRequest += "&oauth_version=1.0"; 
            flickrURLSigningRequest += "&oauth_signature=" + HttpUtility.UrlEncode(signature);
            flickrURLSigningRequest += "&oauth_callback=" + callback; 

            //Handle Flickr Token string response
            //example: oauth_callback_confirmed=true&oauth_token=72157632733281181-a1c53ea7076c8abe& =5869e241190f0b76"
            NameValueCollection query = HttpUtility.ParseQueryString(serviceRequest.DownloadString(new Uri(flickrURLSigningRequest)));
            if (query.Count > 0)
            {
                oauth_callback_confirmed = query["oauth_callback_confirmed"];  //e.g. true
                oauth_token = query["oauth_token"];  //e.g. 72157632733281181-a1c53ea7076c8abe
                oauth_token_secret = query["oauth_token_secret"]; //e.g. 5869e241190f0b76
            }

            //Step 2 Get a Authorization Flickr returns callback authorization
            flickrURLSigningRequest = "http://www.flickr.com/services/oauth/authorize";
            flickrURLSigningRequest += "?oauth_token=" + HttpUtility.UrlEncode(oauth_token); //e.g. 72157626737672178-022bbd2f4c2f3432
            flickrURLSigningRequest += "&perms=write";  //Privileges
            
            //Handle Flickr Authorization response
            query = HttpUtility.ParseQueryString(serviceRequest.DownloadString(new Uri(flickrURLSigningRequest)));
            if (query.Count > 0)
            {
                oauth_token = query["oauth_token"];  
                oauth_verifier = query["oauth_verifier"]; 
            }

            //Step 3 Exchange the Request Token for an Access Token
            flickrURLSigningRequest = "http://www.flickr.com/services/oauth/access_token";
            flickrURLSigningRequest += "?oauth_nonce=" + HttpUtility.UrlEncode(nonce);
            flickrURLSigningRequest += "&oauth_timestamp=" + timestamp;
            flickrURLSigningRequest += "&oauth_verifier=" + oauth_verifier; //???
            flickrURLSigningRequest += "&oauth_consumer_key=" + HttpUtility.UrlEncode(consumerKey); 
            flickrURLSigningRequest += "&oauth_signature_method=HMAC-SHA1";
            flickrURLSigningRequest += "&oauth_version=1.0";
            flickrURLSigningRequest += "&oauth_token=" + oauth_token; 
            flickrURLSigningRequest += "&oauth_signature=" + HttpUtility.UrlEncode(signature); 

            //Handle Flickr Access Token response
            //responseJson = serviceRequest.DownloadString(new Uri(flickrURLSigningRequest));
            //JSONDoc = (JsonObject)JsonObject.Parse(responseJson);
            //if (JSONDoc.Count > 0)
            //{
            //    fullname = JSONDoc["fullname"]; 
            //    oauth_token = JSONDoc["oauth_token"]; 
            //    oauth_token_secret = JSONDoc["oauth_token_secret"]; 
            //    user_nsid = JSONDoc["user_nsid"]; 
            //    username = JSONDoc["username"]; 
            //}

            return true;

           
        }
    }
}
