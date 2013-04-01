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
using ChessByBird.Chess;



namespace UnitTestsProject
{
    [TestClass]
    public class UnitTestsChess
    {

        #region Entity Test Checks
        //  [TestMethod]
        //public void TestMethodGameEntity()
        //{

        //}

        //[TestMethod]
        //public void TestMethodFenEntity()
        //{

        //}

        //[TestMethod]
        //public void TestMethodBoardEntity()
        //{

        //}

        //[TestMethod]
        //public void TestMethodPiecesEntity()
        //{

        //}
        #endregion
        [TestMethod]
        public void TestValidMove()
        {            
            var engine = new Engine();
            Assert.IsTrue(engine.IsValidMove(3, 6, 3, 4));
        }

        [TestMethod]
        public void TestColorPieceLocation()
        { 
            var engine = new Engine();
           
            Assert.AreEqual(ChessPieceColor.White, engine.GetPieceColorAt(3, 6));
            Assert.AreEqual(ChessPieceColor.Black, engine.GetPieceColorAt(0, 0));
            
      }
        [TestMethod]
        public void TestPieceType()
        {  
            var engine = new Engine();
            String test = engine.GetPieceTypeAt(2, 0).ToString();
            Assert.AreEqual(ChessPieceType.Rook,engine.GetPieceTypeAt(0,0));
            Assert.AreEqual(ChessPieceType.Knight, engine.GetPieceTypeAt(1, 0));
            Assert.AreEqual(ChessPieceType.Bishop, engine.GetPieceTypeAt(2, 0));
            Assert.AreEqual(ChessPieceType.Queen, engine.GetPieceTypeAt(3, 0));
            Assert.AreEqual(ChessPieceType.King, engine.GetPieceTypeAt(4, 0));
            Assert.AreEqual(ChessPieceType.Bishop, engine.GetPieceTypeAt(5, 0));
            Assert.AreEqual(ChessPieceType.Knight, engine.GetPieceTypeAt(6, 0));
            Assert.AreEqual(ChessPieceType.Rook, engine.GetPieceTypeAt(7, 0));
            Assert.AreEqual(ChessPieceType.Pawn, engine.GetPieceTypeAt(7, 1));
        }

        //[TestMethod]
        //public void TestMethodProcessChessCheckMate()
        //{
        
            
        //}


        [TestMethod]
        public void TestIsNotValidMove()
        {
            var engine = new Engine();
            Assert.IsFalse(engine.IsValidMove(3, 4, 3,6));
            
        }
        [TestMethod]
        public void TestEngineCheck()
        {
           var engine = new Engine();
            Assert.IsNotNull(engine);
            var newengine = new Engine("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
            Assert.IsNotNull(newengine);
        }

     [TestMethod]
     public void TestSetMove()
      {
          var engine = new Engine();
          Assert.IsTrue(engine.MovePiece(3, 6, 3, 4));

        }
    }
}
