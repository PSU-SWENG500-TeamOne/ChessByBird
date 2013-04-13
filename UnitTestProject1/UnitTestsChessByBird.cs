using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using ChessByBird.TwitterClient;
using ChessByBird.FlickrClient;
using ChessByBird.ChessClient;
using ChessByBird.ImageClient;

namespace UnitTestsProject
{
    [TestClass]
    public class UnitTestsChessByBird
    {
        //for imaging
        string gameState = "";
        string whitePlayerName = "Zach";
        string blackPlayerName = "Joe";
        string assetPath = "";
        
        [TestMethod]
        public void t_NewMentions()
        {
            long results = ChessByBird.TwitterClient.TwitterClient.areNewTweets(800, 291383000000000000); //will just grab the first mention ever
            Assert.AreEqual(results, 291382951072120832);
        }

        [TestMethod]
        public void t_NoNewMentions()
        {
            long results = ChessByBird.TwitterClient.TwitterClient.areNewTweets(9223372036854775807); //highest possible long value. no mentions after it!
            Assert.AreEqual(results, 0);
        }

        [TestMethod]
        public void t_GetTweet()
        {
            Dictionary<string, string> resultsDictionary = ChessByBird.TwitterClient.TwitterClient.getTweetInfo(318862778024738816);

            Dictionary<string, string> expectedDictionary = new Dictionary<string, string>();
            expectedDictionary.Add("currentPlayer", "ZacharyACarson");
            expectedDictionary.Add("otherPlayer", "ZachCarsonTest");
            expectedDictionary.Add("imageURL", "new game");
            expectedDictionary.Add("moveString", "b2 b4");

            CollectionAssert.AreEquivalent(expectedDictionary, resultsDictionary);
        }

        [TestMethod]
        public void t_PostTweet()
        {
            Guid randomText = Guid.NewGuid();
            string tweetText = "Running Unit Tests. Random key: " + randomText.ToString();

            bool results = ChessByBird.TwitterClient.TwitterClient.postTweet(299722128025063425, tweetText);

            Assert.IsTrue(results);
        }

        [TestMethod]
        public void t_IsNewGame()
        {
            Dictionary<string, string> resultsDictionary = ChessByBird.TwitterClient.TwitterClient.getTweetInfo(318862778024738816);

            Dictionary<string, string> expectedDictionary = new Dictionary<string, string>();
            expectedDictionary.Add("currentPlayer", "ZacharyACarson");
            expectedDictionary.Add("otherPlayer", "ZachCarsonTest");
            expectedDictionary.Add("imageURL", "new game");
            expectedDictionary.Add("moveString", "b2 b4");

            CollectionAssert.AreEquivalent(expectedDictionary, resultsDictionary);
        }

        [TestMethod]
        public void i_ProcessImageBadFENInputString()
        {
            try
            {
                gameState = "rnbqkbnr/aaaaaa/8/8/4P3/8/PPPP1PPP/RNBQKB"; // "Hacked" incomplete FEN String to test error response
                assetPath = ChessByBird.ImageClient.ImageClient.processImage(gameState, whitePlayerName, blackPlayerName);
                Assert.Fail(); // If it gets to this line, no exception was thrown
            }
            catch (Exception ex)
            {
            }
        }

        [TestMethod]
        public void i_ProcessImageBlackTurn()
        {
            try
            {
                gameState = "rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR b KQkq e3 0 1";
                assetPath = ChessByBird.ImageClient.ImageClient.processImage(gameState, whitePlayerName, blackPlayerName);
                Assert.IsTrue(assetPath.Length != 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void i_ProcessImageWhiteTurn()
        {
            try
            {
                gameState = "rnbqkbnr/pp1ppppp/8/2p5/4P3/8/PPPP1PPP/RNBQKBNR w KQkq c6 0 2";
                assetPath = ChessByBird.ImageClient.ImageClient.processImage(gameState, whitePlayerName, blackPlayerName);
                Assert.IsTrue(assetPath.Length != 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void i_CreateImage()
        {
            try
            {
                gameState = "rnbqkbnr/pp1ppppp/8/2p5/4P3/5N2/PPPP1PPP/RNBQKB1R b KQkq - 1 2";
                assetPath = ChessByBird.ImageClient.ImageClient.processImage(gameState, "player 1", "player 2");
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        
        [TestMethod]
        public void f_GetPicValid()
        {
            try
            {
                string photoDescription;  //This will hold the Chess FEN or Error message
                photoDescription = FlickrClient.getFlickrPic("8465703185");
                //Make sure the value returned is equal
                Assert.AreEqual("rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR b KQkq e3 0 1", photoDescription);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void f_GetPicInvalid()
        {
            try
            {
                string photoDescription;  //This will hold the Chess FEN or Error message
                photoDescription = FlickrClient.getFlickrPic("1234567890");
                Assert.Fail(); // If it gets to this line, no exception was thrown
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void f_PostPicValid()
        {
            try
            {
                String assetPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\DigitalAssets\ChessGameboard.PNG");
                string GameBoardState = "rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR b KQkq e3 0 1";
                Uri URL = FlickrClient.postFlickrPic(assetPath, GameBoardState);
                Assert.IsNotNull(URL);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void f_PostGetPicValid()
        {
            try
            {
                String assetPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\DigitalAssets\ChessGameboard.PNG");
                string GameBoardState = "rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR b KQkq e3 0 1";
                Uri URL = FlickrClient.postFlickrPic(assetPath, GameBoardState);
                Assert.IsNotNull(URL);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
        
        [TestMethod]
        public void c_ValidMove()
        {
            var engine = new Engine();
            Assert.IsTrue(engine.IsValidMove(3, 6, 3, 4));
        }

        [TestMethod]
        public void c_ColorPieceLocation()
        {
            var engine = new Engine();

            Assert.AreEqual(ChessPieceColor.White, engine.GetPieceColorAt(3, 6));
            Assert.AreEqual(ChessPieceColor.Black, engine.GetPieceColorAt(0, 0));

        }

        [TestMethod]
        public void c_PieceType()
        {
            var engine = new Engine();
            String test = engine.GetPieceTypeAt(2, 0).ToString();
            Assert.AreEqual(ChessPieceType.Rook, engine.GetPieceTypeAt(0, 0));
            Assert.AreEqual(ChessPieceType.Knight, engine.GetPieceTypeAt(1, 0));
            Assert.AreEqual(ChessPieceType.Bishop, engine.GetPieceTypeAt(2, 0));
            Assert.AreEqual(ChessPieceType.Queen, engine.GetPieceTypeAt(3, 0));
            Assert.AreEqual(ChessPieceType.King, engine.GetPieceTypeAt(4, 0));
            Assert.AreEqual(ChessPieceType.Bishop, engine.GetPieceTypeAt(5, 0));
            Assert.AreEqual(ChessPieceType.Knight, engine.GetPieceTypeAt(6, 0));
            Assert.AreEqual(ChessPieceType.Rook, engine.GetPieceTypeAt(7, 0));
            Assert.AreEqual(ChessPieceType.Pawn, engine.GetPieceTypeAt(7, 1));
        }

        [TestMethod]
        public void c_NotValidMove()
        {
            var engine = new Engine();
            Assert.IsFalse(engine.IsValidMove(3, 4, 3, 6));

        }

        [TestMethod]
        public void c_EngineCheck()
        {
            var engine = new Engine();
            Assert.IsNotNull(engine);
            var newengine = new Engine("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
            Assert.IsNotNull(newengine);
        }

        [TestMethod]
        public void c_SetMove()
        {
            var engine = new Engine();
            Assert.IsTrue(engine.MovePiece(3, 6, 3, 4));

        }
        
    }
}
