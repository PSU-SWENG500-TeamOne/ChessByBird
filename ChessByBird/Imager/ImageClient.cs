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

namespace ChessByBird.ImageClient
{
    /// <summary>
    /// ImagerClient accesses the ImagingProject Component
    /// </summary>
    public class ImageClient
    {
        /// <summary>
        /// Process Chess Board Image and Return Digital Asset "..\..\DigitalAssets\ChessBoardImage.png"
        /// </summary>
        /// <param name="gameBoardState"></param> 
        /// <param name="whitePlayerName"></param>
        /// <param name="blackPlayerName"></param>
        /// <returns></returns>
        public static string processImage(string gameBoardState, string whitePlayerName, string blackPlayerName)
        {
            // TODO: Do we need this as defaults
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Setup Objects
            ChessBoardImageForm cbbForm = new ChessBoardImageForm();
            ChessBoardImageGenerator cbbImgGen = new ChessBoardImageGenerator(cbbForm);
            cbbForm.ImageGenerator = cbbImgGen;

            // Setup Input Fields
            cbbImgGen.WhitePlayerLabel = whitePlayerName;
            cbbImgGen.BlackPlayerLabel = blackPlayerName;

            // Setup Output Fields
            cbbImgGen.FileNameImageFormat = ImageFormat.Png;
            cbbImgGen.ImageFileName = @"..\..\DigitalAssets\ChessBoardImage.png";

            // Set "updatedGameBoardState" expected in Forsyth-Edwards Notation
            cbbForm.ChessBoardStateFEN = gameBoardState;

            // Generate the game board
            Application.Run(cbbForm);

            return cbbImgGen.ImageFileName;
        }
    }
}

