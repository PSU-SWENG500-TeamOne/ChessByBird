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


/// <Remarks>
/// References:
/// http://en.wikipedia.org/wiki/Chess
/// http://www.fam-petzke.de/cp_board_en.shtml
///
///
/// Chess Board FEN parser class
///
/// Forsyth-Edwards Notation (FEN) describes a Chess Position. It is an one-line ASCII-string. FEN is based on a system 
/// created by Scotsman David Forsyth in the 19th century. Steven Edwards specified the FEN standard for computer chess 
/// applications as part of the Portable Game Notation [1].
///
/// Explanation:
///
/// Forsyth–Edwards Notation (FEN) is a standard notation for describing a particular 
/// ChessBoard position of a chess game. The purpose of FEN is to provide all the necessary
/// information to restart a game from a particular position. 
/// A FEN record contains six fields. The separator between fields is a space.
///
/// The six fields are:
/// 1. Piece placement on squares (A8 B8 .. G1 H1) Each piece is identified by a letter 
///    taken from the standard English names (white upper-case, black lower-case). 
///    Blank squares are noted using digits 1 through 8 (the number of blank squares), 
///    and "/" separate ranks.
/// 2. Active color. "w" means white moves next, "b" means black.
/// 3. Castling availability. Either - if no side can castle or a letter (K,Q,k,q) for 
///    each side and castle possibility.
/// 4. En passant target square in algebraic notation or "-".
/// 5. Halfmove (or parserPly) clock: This is the number of halfmoves since the last pawn advance or capture.
/// 6. Fullmove number: The number of the current full move.
///
/// The FEN parser
///
/// We implement a public method in our ChessBoard class called setFEN(string aFEN).
/// This method only accepts a valid FEN input if invalid it returns a syntax error.
/// The function splits the FEN string into its substrings and loops through the 
/// squares of the ChessBoard filling the squares data structure with the content of the string.
///
/// Examples
/// 
/// Place White Pieces at Bottom of Board and Black Pieces at the Top.
///
/// RNBQKBNR/PPPPPPPP/8/8/8/8/pppppppp/rnbqkbnr w KQkq - 0 1              // Initial Position (White on Bottom and Black at Top)
/// RNBQKBNR/PPPP1PPP/8/4P3/8/8/pppppppp/rnbqkbnr b KQkq e3 0 1           // White moves Pawn
/// RNBQKBNR/PPPP1PPP/8/4P3/2p5/8/pp1ppppp/rnbqkbnr w KQkq c6 0 2         // Black moves Pawn
/// RNBQKB1R/PPPP1PPP/5N2/4P3/2p5/8/pppp1ppp/rnbqkbnr b KQkq - 1 2        // White moves Rook
/// RNBQKB1R/PPPP1PPP/5N2/4P3/2p5/5n2/pppp1ppp/rnbqkb1r w KQkq - 1 2      // Black moves Rook
///
/// </Remarks>
/// 
namespace ChessByBird.ImageClient
{

    public class ImageClient
    {
        /// <summary>
        /// Builds image for game state
        /// </summary>
        /// <param name="gameState">FEN Value of the current game state</param>
        /// <param name="playerCurrentTurn">Name for the player who's turn it now is</param>
        /// <param name="playerNowWaiting">Name for player who just went</param>
        /// <returns>asset path for the new image</returns>
        public static string processImage(string gameState, string playerCurrentTurn, string playerNowWaiting)
        {
            // Setup Objects
            ChessBoardForm cbbForm = new ChessBoardForm();
            ChessBoardImageGenerator cbbImgGen = new ChessBoardImageGenerator(cbbForm);
            cbbForm.ImageGenerator = cbbImgGen;

            // Setup Output Fields
            cbbImgGen.FileNameImageFormat = ImageFormat.Png;
            cbbImgGen.ImageFileName = @"..\..\..\DigitalAssets\GameBoardImage.png";

            // Setup Input Fields
            if (playerCurrentTurn.Length > 0)
            {
                cbbImgGen.WhitePlayerButtonText = playerCurrentTurn;
            }
            else
            {
                cbbImgGen.WhitePlayerButtonText = "Current Player";
            }
            if (playerNowWaiting.Length > 0)
            {
                cbbImgGen.BlackPlayerButtonText = playerNowWaiting;
            }
            else
            {
                cbbImgGen.BlackPlayerButtonText = "Waiting Player";
            }

            cbbForm.ChessBoardStateFEN = gameState;

            Application.Run(cbbForm);
            Application.Exit();

            return cbbImgGen.ImageFileName;
        }
    }
}