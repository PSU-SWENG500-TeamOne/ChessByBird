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
using ChessByBird.ImageClient;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestsImage
    {
        [TestMethod]
        public void TestMethodBadFENInputString()
        {
            string whitePlayerName = "";
            string blackPlayerName = "";
            string assetPath = "";
            string gameState = "rnbqkbnr/aaaaaa/8/8/4P3/8/PPPP1PPP/RNBQKB"; // "Hacked" incomplete FEN String to test error response

            assetPath = ImageClient.processImage(gameState, whitePlayerName, blackPlayerName);
            Assert.IsTrue(assetPath.Length != 0);
        }
        [TestMethod]
        public void TestMethodProcessImage()
        {
            int example = 3;
            string gameState = "";
            string whitePlayerName = "Zach";
            string blackPlayerName = "Joe";
            string assetPath = "";

            switch (example)
            {
                case 1:
                    gameState = "rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR b KQkq e3 0 1"; // Another state - Black's Turn
                    break;
                case 2:
                    gameState = "rnbqkbnr/pp1ppppp/8/2p5/4P3/8/PPPP1PPP/RNBQKBNR w KQkq c6 0 2"; // Another state - White's Turn
                    break;
                case 3:
                    gameState = "rnbqkbnr/pp1ppppp/8/2p5/4P3/5N2/PPPP1PPP/RNBQKB1R b KQkq - 1 2"; // Another state - Black's Turn
                    break;
                default:
                    gameState = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1"; // Initial state - White's Turn
                    break;
            }

            assetPath = ImageClient.processImage(gameState, whitePlayerName, blackPlayerName);
            Assert.IsTrue(assetPath.Length != 0);
        }
    }
}
