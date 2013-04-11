/*******************************************************************************
 *  Penn State University Software Engineering Graduate ImagerProgram
 *  Authors: Team 1: Zachary Carson, Aaron Eugene, Steve Haggerty, Joseph Oakes
 *  Date: Spring 2013
 *  Course: SWENG 500 Software Engineering Studio
 *  Professor: Mohamad Kassab
 *  Project: Chess By Bird Capstone group project
*******************************************************************************/

using ChessByBird.ImagingProject;
using System;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ChessByBird.ImageClient
{
    /// Forsyth-Edwards Notation (FEN) describes a Chess Position. It is an one-line ASCII-string. FEN is based on a system 
    /// created by Scotsman David Forsyth in the 19th century. Steven Edwards specified the FEN standard for computer chess 
    /// applications as part of the Portable Game Notation [1].
    ///
    /// Expected Chess Board States in Forsyth-Edwards Notation

    //string gameState = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";          // Initial state - White's Turn
    //string gameState = "rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR b KQkq e3 0 1";       // Another state - Black's Turn
    //string gameState = "rnbqkbnr/pp1ppppp/8/2p5/4P3/8/PPPP1PPP/RNBQKBNR w KQkq c6 0 2";     // Another state - White's Turn
    //string gameState = "rnbqkbnr/pp1ppppp/8/2p5/4P3/5N2/PPPP1PPP/RNBQKB1R b KQkq - 1 2";    // Another state - Black's Turn
    //string gameState = "rnbqkb1r/pp1ppppp/5n2/2p5/4P3/5N2/PPPP1PPP/RNBQKB1R w KQkq - 1 2";  // Another state - White's Turn

    public class ImageClient
    {
        /// <summary>
        /// Builds image for game state
        /// </summary>
        /// <param name="gameState">FEN Value of the current game state</param>
        /// <param name="whtePlayerName">Name of the white player</param>
        /// <param name="blackPlayerName">Name of the black player</param>
        /// <returns>asset path for the new image</returns>
        public static string processImage(string gameState, string whtePlayerName, string blackPlayerName)
        {
            // Setup Objects
            ChessBoardForm cbbForm = new ChessBoardForm();
            ChessBoardImageGenerator cbbImgGen = new ChessBoardImageGenerator(cbbForm);
            cbbForm.ImageGenerator = cbbImgGen;

            // Setup Output Fields
            cbbImgGen.FileNameImageFormat = ImageFormat.Png;
            cbbImgGen.ImageFileName = @"..\..\DigitalAssets\GameBoardImage.png";

            // Setup Input Fields
            if (whtePlayerName.Length > 0)
            {
                cbbImgGen.WhitePlayerButtonText = whtePlayerName;
            }
            else
            {
                cbbImgGen.WhitePlayerButtonText = "White Player";
            }
            if (blackPlayerName.Length > 0)
            {
                cbbImgGen.BlackPlayerButtonText = blackPlayerName;
            }
            else
            {
                cbbImgGen.BlackPlayerButtonText = "Black Player";
            }

            cbbForm.ChessBoardStateFEN = gameState;

            Application.Run(cbbForm);
            Application.Exit();

            return cbbImgGen.ImageFileName;
        }
    }
}