/*******************************************************************************
 *  Penn State University Software Engineering Graduate Program
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

namespace ChessByBird
{
    static class Program
    {
        /**
         * Forsyth-Edwards Notation (FEN) describes a Chess Position. It is an one-line ASCII-string. FEN is based on a system 
         * created by Scotsman David Forsyth in the 19th century. Steven Edwards specified the FEN standard for computer chess 
         * applications as part of the Portable Game Notation [1].
         */

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            int example = 0;  // Change this to test various valid string
            while (example < 4)
            {
                // Setup Objects
                ChessBoardForm cbbForm = new ChessBoardForm();
                ChessBoardImageGenerator cbbImgGen = new ChessBoardImageGenerator(cbbForm);
                cbbForm.ImageGenerator = cbbImgGen;

                // Setup Output Fields
                cbbImgGen.FileNameImageFormat = ImageFormat.Png;
                cbbImgGen.ImageFileName = @"..\..\DigitalAssets\GameBoardImage.png";

                // Setup Input Fields
                cbbImgGen.WhitePlayerLabel = "Zach";
                cbbImgGen.BlackPlayerLabel = "Joe";

                if (cbbImgGen.ImageFileName.Length > 0)
                {
                    int index = cbbImgGen.ImageFileName.IndexOf(".png");
                    string newFileName = cbbImgGen.ImageFileName.Insert(index, example.ToString());
                    cbbImgGen.ImageFileName = newFileName;
                }
                else
                {
                    throw new Exception("ERROR: Bad Image Filename");
                }

                // Expected Chess Board States in Forsyth-Edwards Notation
                string gameState = "";
                switch (example)
                {
                    case 1:
                        gameState = "rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR b KQkq e3 0 1";    // Another state - Black's Turn
                        break;
                    case 2:
                        gameState = "rnbqkbnr/pp1ppppp/8/2p5/4P3/8/PPPP1PPP/RNBQKBNR w KQkq c6 0 2";  // Another state - White's Turn
                        break;
                    case 3:
                        gameState = "rnbqkbnr/pp1ppppp/8/2p5/4P3/5N2/PPPP1PPP/RNBQKB1R b KQkq - 1 2"; // Another state - Black's Turn
                        break;
                    default:
                        gameState = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";       // Initial state - White's Turn
                        break;
                }
                cbbForm.ChessBoardStateFEN = gameState;

                Application.Run(cbbForm);                
                Application.Exit();

                example++;
            }
        }
    }
}
