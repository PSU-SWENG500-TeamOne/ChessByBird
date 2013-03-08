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
using ChessByBird.Twitter;
//using ChessByBird.TwitterProject;
using System.Threading;
using System.Reflection;
using TweetSharp;

namespace UnitTestsProject
{
    [TestClass]
    public class UnitTestsTwitter
    {
               
        [TestMethod]
        public void t_NewMentions()
        {
            long results = ChessByBird.Twitter.TwitterClient.areNewTweets(800); //really low number, will just grab the first mention ever
            Assert.AreEqual(results, 300330024228253697);
        }

        [TestMethod]
        public void t_NoNewMentions()
        {
            long results = ChessByBird.Twitter.TwitterClient.areNewTweets(9223372036854775807); //highest possible long value. no mentions after him!
            Assert.AreEqual(results, 0);
        }

        [TestMethod]
        public void t_GetTweet()
        {
            Dictionary<string,string> resultsDictionary = ChessByBird.Twitter.TwitterClient.getTweetInfo(299722128025063425);

            Dictionary<string,string> expectedDictionary = new Dictionary<string,string>();
            expectedDictionary.Add("currentPlayer", "ChessByBird");
            expectedDictionary.Add("otherPlayer", "ZacharyACarson");
            expectedDictionary.Add("imageURL", "not found");
            expectedDictionary.Add("moveString", "not found");

            Assert.AreEqual(expectedDictionary,resultsDictionary);           
        }

        [TestMethod]
        public void t_PostTweet()
        {
            bool results = ChessByBird.Twitter.TwitterClient.postTweet(299722128025063425, "hey @zacharyacarson it worked! test post from the new api");

            Assert.IsTrue(results);
        }

    }
}
