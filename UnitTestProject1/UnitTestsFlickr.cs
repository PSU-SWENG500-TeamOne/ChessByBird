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

namespace UnitTestsProject
{
    [TestClass]
    public class UnitTestsFlickr
    {

        FlickrClient fc = new FlickrClient;

        [TestMethod]
        public void TestMethodImageEntity()
        {

        }

        [TestMethod]
        public void TestMethodGetFlickrPic()
        {

        }

        [TestMethod]
        public void TestMethodPostFlickrPic()
        {

        }
    }
}
