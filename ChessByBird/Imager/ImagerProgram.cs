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
/// Initial State
/// rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1
///
/// Here is the FEN after the move 1. e4:
/// rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR b KQkq e3 0 1
///
/// And then after 1. ... c5:
/// rnbqkbnr/pp1ppppp/8/2p5/4P3/8/PPPP1PPP/RNBQKBNR w KQkq c6 0 2
///
/// And then after 2. Nf3:
/// rnbqkbnr/pp1ppppp/8/2p5/4P3/5N2/PPPP1PPP/RNBQKB1R b KQkq - 1 2
///
/// </Remarks>

namespace ChessByBird
{
    static class ImagerProgram
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            int example = 0;  // Change this to test various valid string
            while (example < 5)
            {
                // Setup Objects
                ChessBoardForm cbbForm = new ChessBoardForm();
                ChessBoardImageGenerator cbbImgGen = new ChessBoardImageGenerator(cbbForm);
                cbbForm.ImageGenerator = cbbImgGen;

                // Setup Output Fields
                cbbImgGen.FileNameImageFormat = ImageFormat.Png;
                cbbImgGen.ImageFileName = @"..\..\DigitalAssets\GameBoardImage.png";

                // Setup Input Fields
                cbbImgGen.WhitePlayerButtonText = cbbImgGen.WhitePlayerName = "Zach";
                cbbImgGen.BlackPlayerButtonText = cbbImgGen.BlackPlayerName = "Joe";

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
                    case 0:         // Rank 1 Rank 2   3 4 5 6 Rank 7   Rank 8
                        gameState = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";       // Initial state - White has the Honor
                        break;
                    case 1:
                        gameState = "rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR b KQkq e3 0 1";    // Another state - White's Turn
                        break;
                    case 2:
                        gameState = "rnbqkbnr/pp1ppppp/8/2p5/4P3/8/PPPP1PPP/RNBQKBNR w KQkq c6 0 2";  // Another state - Black's Turn
                        break;
                    case 3:
                        gameState = "rnbqkbnr/pp1ppppp/8/2p5/4P3/5N2/PPPP1PPP/RNBQKB1R b KQkq - 1 2"; // Another state - White's Turn
                        break;
                    case 4:
                        gameState = "rnbqkb1r/pp1ppppp/2n5/2p5/4P3/5N2/PPPP1PPP/RNBQKB1R b KQkq - 1 2"; // Another state - Black's Turn
                        break;
                    default:
                        gameState = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";       // Initial state - White has the Honor
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
