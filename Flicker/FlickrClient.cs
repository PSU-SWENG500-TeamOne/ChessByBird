﻿/********************************************
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
            //Need api key and auth secret
            /* http://flickr.com/services/auth/?api_key=[api_key]&perms=[perms]&frob=[frob]&api_sig=[api_sig] */
            
            return true;
        }
    }
}
