/********************************************
 *  Penn State University Software Engineering Graduate Program
 *  Authors: Team 1: Zachary Carson, Aaron Eugene, Steve Haggerty, Joseph Oakes
 *  Date: Spring 2013
 *  Course: SWENG 500 Software Engineering Studio
 *  Professor: Mohamad Kassab
 *  Project: Chess By Bird Capstone group project
*********************************************/

//Assert.AreEqual();            //Verifies that specified values are equal.
//Assert.AreNotEqual();         //Verifies that specified values are not equal.
//Assert.AreSame();             //Verifies that specified object variables refer to the same object.
//Assert.AreNotSame();          //Verifies that specified object variables refer to different objects.
//Assert.Equals();              //Determines whether two objects are equal.
//Assert.Fail();                //Fails an assertion without checking any conditions.
//Assert.Inconclusive();        //Indicates that an assertion cannot be proven true or false. Also used to indicate an assertion that has not yet been implemented.   
//Assert.IsFalse();             //Verifies that a specified condition is false.
//Assert.IsInstanceOfType();    //Verifies that a specified object is an instance of a specified type.
//Assert.IsNotInstanaceOfType(); //Verifies that a specified object is not an instance of a specified type.
//Assert.IsNotNull();           //Verifies that a specified object is not null.
//Assert.IsNull();              //Verifies that a specified object is null.
//Assert.IsTrue();              //Verifies that a specified condition is true.

using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessByBird.TwitterProject;
using System.Threading;
using System.Reflection;

namespace UnitTestsProject
{
    [TestClass]
    public class UnitTestsTwitter
    {
        private static OAuthInfo GetOAuthInfo()
        {
            var tokensFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "oauth-info.xml");

            if (!File.Exists(tokensFile))
                Assert.Fail("Cannot find oauth parameter file.");

            var serializer = new XmlSerializer(typeof(OAuthInfo));
            using (var stream = File.OpenRead(tokensFile))
                return (OAuthInfo)serializer.Deserialize(stream);

        }

        [TestMethod]
        public void TestMethodPictureEntity()
        {

        }

        [TestMethod]
        public void TestMethodURLEntity()
        {

        }

        [TestMethod]
        public void TestMethodGetTweet()
        {
            var oauth = GetOAuthInfo();

            var twitter = new TinyTwitter(oauth);

            //get tweet #299722128025063425
            var tweet = twitter.GetSpecificTweet(299722128025063425);
            string actualText = "@ZacharyACarson this is a tweet! heres a link to something on flickr: http://www.flickr.com/photos/straymuffin/89009605/";
            Assert.AreEqual(tweet.ToString(), actualText);
            
        }

        [TestMethod]
        public void TestMethodPostTweetAndReadTimeline()
        {
            var oauth = GetOAuthInfo();

            var twitter = new TinyTwitter(oauth);

            var status = Guid.NewGuid().ToString();
            twitter.UpdateStatus(status);

            // Wait a little to let twitter update timelines
            Thread.Sleep(TimeSpan.FromSeconds(5));

            var tweets = twitter.GetHomeTimeline();
            Assert.AreEqual(status, tweets.First().Text);
        }

    }
}
