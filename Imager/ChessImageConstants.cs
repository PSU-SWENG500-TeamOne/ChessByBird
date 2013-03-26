/*******************************************************************************
 *  Penn State University Software Engineering Graduate Program
 *  Authors: Team 1: Zachary Carson, Aaron Eugene, Steve Haggerty, Joseph Oakes
 *  Date: Spring 2013
 *  Course: SWENG 500 Software Engineering Studio
 *  Professor: Mohamad Kassab
 *  Project: Chess By Bird Capstone group project
*******************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;

/**
 * References:
 * http://en.wikipedia.org/wiki/Chess
 * http://www.fam-petzke.de/cp_board_en.shtml
 * http://www.codeproject.com/Articles/1456/Enums-and-Structs-in-C
 */

namespace ChessByBird.Imaging.Imager
{
    /// <summary>
    /// Enumerated Square ID's
    /// </summary>
    public enum EnumSquareID
    {
        A1, B1, C1, D1, E1, F1, G1, H1,
        A2, B2, C2, D2, E2, F2, G2, H2,
        A3, B3, C3, D3, E3, F3, G3, H3,
        A4, B4, C4, D4, E4, F4, G4, H4,
        A5, B5, C5, D5, E5, F5, G5, H5,
        A6, B6, C6, D6, E6, F6, G6, H6,
        A7, B7, C7, D7, E7, F7, G7, H7,
        A8, B8, C8, D8, E8, F8, G8, H8,
        ER
    };

    /// <summary>
    /// Enumerated Colors
    /// </summary>
    public enum EnumSquareColor { White, Black }
    public enum EnumOpponentColor { White, Black, None }

    /// <summary>
    /// Enumerated Piece Types
    /// </summary>
    public enum EnumPieceColor { White = 10, Black = 20, None=30 }
    public enum EnumPieceType { King=1, Queen, Rook, Bishop, Knight, Pawn, None }
    
    /// <summary>
    /// Enumerated Piece ID's
    /// </summary>
    public enum EnumPieceID
    {
        Empty=0,
        WhiteKing=11, WhiteQueen, WhiteRook, WhiteBishop, WhiteKnight, WhitePawn,
        BlackKing=21, BlackQueen, BlackRook, BlackBishop, BlackKnight, BlackPawn,
        Invalid
    };

    /// <summary>
    /// Enumerated Player Types
    /// </summary>
    public enum EnumPlayerType { WhitePlayer, BlackPlayer }

    /// <summary>
    /// Enumerated Castling Rights
    /// </summary>
    public enum EnumCastlingRights { WhiteCastleKingSide, WhiteCastleQueenSide, BlackCastleKingSide, BlackCastleQueenSide }

    /// <summary>
    /// ChessLocation
    /// </summary>
    public struct ChessLocation
    {
        public int x, y;

        public ChessLocation(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return (String.Format("({0},{1})", x, y));
        }
    }

    /// <summary>
    /// ChessSquareID Increment & Decrement Methods
    /// </summary>
    public struct ChessSquareID
    {
        public static EnumSquareID IncrementEnumSquareID(EnumSquareID id)
        {
            if (id == EnumSquareID.ER)
                return id;
            else
                return id + 1;
        }
        public static EnumSquareID DecrementEnumSquareID(EnumSquareID id)
        {
            if (id == EnumSquareID.A1)
                return id;
            else
                return id - 1;
        }
    }

    /// <summary>
    ///  Chess Image Constants
    /// </summary>
    public class ChessImageConstants
    {
        /// <summary>
        /// Colors
        /// </summary>
        public static Color BlackSquareColor = Color.Gray;
        public static Color BlackSquareColor2 = Color.Gray;
        public static Color WhiteSquareColor = Color.White;
        public static Color WhiteSquareColor2 = Color.White;
        public static Color ChessBoardBorderColor = Color.Black;
        public static Color HighlightPenColor = Color.Yellow;
        public static Color LastMoveColor = Color.Blue;

        /// <summary>
        /// Modes
        /// </summary>
        public static LinearGradientMode Mode = LinearGradientMode.Vertical;

        /// <summary>
        /// Sizes
        /// </summary>
        public static int HighlightPenSize = 4;

        public static int ChessPieceCount = 16;
        public static int ChessPieceSize = 40;
        public static int ChessPieceLeft = 20;
        public static int ChessPieceTop = 20;
        public static int ChessBoardSize = 40;
        public static int ChessBoardLeft = 20;
        public static int ChessBoardTop = 20;

        public static int SquareCount = 64;
        public static int SquareSize = 80;
        public static int SquaresPerRow = 8;

        /// <summary>
        ///  Parser Globals
        /// </summary>
        public static int parserPly = 0;
        public static int parserCurrentPly = 0;
        public static EnumSquareID parserEnPassentSquareID = EnumSquareID.ER;
        public static EnumSquareID parserSquareID = EnumSquareID.ER;
        public static EnumOpponentColor parserSideToMove = EnumOpponentColor.White;
        public static Dictionary<EnumSquareID, EnumPieceID> parserChessBoardSquares = new Dictionary<EnumSquareID, EnumPieceID>(64);
        public static BitArray parserChessBoardState = new BitArray(16, false);

        /// <summary>
        /// ChessImageConstants Constructor
        /// </summary>
        public ChessImageConstants() {}

        /// <summary>
        /// GetWhiteSquareBrush
        /// </summary>
        /// <returns></returns>
        public static Brush GetWhiteSquareBrush()
        {
            return new LinearGradientBrush(new Rectangle(
                30, 30, SquareSize, SquareSize), WhiteSquareColor, WhiteSquareColor2, Mode);
        }

        /// <summary>
        /// GetBlackSquareBrush
        /// </summary>
        /// <returns></returns>
        public static Brush GetBlackSquareBrush()
        {
            return new LinearGradientBrush(new Rectangle(
                30, 30, SquareSize, SquareSize), BlackSquareColor, BlackSquareColor2, Mode);
        }
    }
}