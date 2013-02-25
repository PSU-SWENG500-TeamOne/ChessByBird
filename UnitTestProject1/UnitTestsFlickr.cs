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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessByBird.FlickrProject;
using System.IO;

namespace UnitTestsProject
{
    [TestClass]
    public class UnitTestsFlickr
    {

        [TestMethod]
        public void TestMethodImageEntity()
        {

        }

        [TestMethod]
        public void TestMethodGetFlickrPicValid()
        {
            try{
                string photoDescription;  //This will hold the Chess FEN or Error message
                photoDescription = FlickrClient.getFlickrPic("8465703185");
                //Make sure the value returned is equal
                Assert.AreEqual("Move3: rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR b KQkq e3 0 1", photoDescription);
            }
            catch (Exception) {
             Assert.Fail(); 
         }
        }

        [TestMethod]
        public void TestMethodGetFlickrPicInvalid()
        {
            try{
            string photoDescription;  //This will hold the Chess FEN or Error message
            photoDescription = FlickrClient.getFlickrPic("1234567890");
            Assert.Fail(); // If it gets to this line, no exception was thrown
            }
            catch (Exception) {}
        }

        [TestMethod]
        public void TestMethodPostFlickrPicValid()
        {
         try{
           String assetPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\DigitalAssets\ChessGameboard.PNG");
           string GameBoardState = "Move3: rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR b KQkq e3 0 1";
           Uri URL = FlickrClient.postFlickrPic(assetPath, GameBoardState);
           Assert.IsNotNull(URL);
         }
         catch (Exception) {
             Assert.Fail();
         }
        }

    }
}
