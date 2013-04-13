/*******************************************************************************
 *  Penn State University Software Engineering Graduate ImagerProgram
 *  Authors: Team 1: Zachary Carson, Aaron Eugene, Steve Haggerty, Joseph Oakes
 *  Date: Spring 2013
 *  Course: SWENG 500 Software Engineering Studio
 *  Professor: Mohamad Kassab
 *  Project: Chess By Bird Capstone group project
*******************************************************************************/

using System;
using System.Collections;
using System.Drawing;

namespace ChessByBird.ImagingProject
{
    /// <summary>
    /// ChessBoardInitializer class
    /// </summary>
    public class ChessBoardInitializer
    {
        /// <summary>
        /// Class Variables
        /// </summary>
        private EnumSquareID squareID;
        private ArrayList squareList;
        private ArrayList whitePieceList;
        private ArrayList blackPieceList;
        private ChessSquareFactory squareFactory;
        private ChessSquareLocator squareLocator;
        private ChessPieceFactory pieceFactory;
        private ChessBoard chessBoard;

        /// <summary>
        /// ChessBoardInitializer Constructor
        /// </summary>
        /// <param name="aChessBoard"></param>
        /// <param name="aChessFENString"></param>
        /// <param name="aSquareList"></param>
        /// <param name="aWhitePieceList"></param>
        /// <param name="aBlackPieceList"></param>
        /// <param name="aSquareFactory"></param>
        /// <param name="aPieceFactory"></param>
        /// <param name="aSquareLocator"></param>
        public ChessBoardInitializer(ChessBoard aChessBoard,
            ArrayList aSquareList, ArrayList aWhitePieceList, ArrayList aBlackPieceList,
            ChessSquareFactory aSquareFactory, ChessPieceFactory aPieceFactory,
            ChessSquareLocator aSquareLocator)
        {
            chessBoard = aChessBoard;

            squareList = aSquareList;
            whitePieceList = aWhitePieceList;
            blackPieceList = aBlackPieceList;

            squareFactory = aSquareFactory;
            pieceFactory = aPieceFactory;
            squareLocator = aSquareLocator;
        }

        /// <summary>
        /// Initialize Method
        /// </summary>
        public void Initialize()
        {
            try
            {
                CreateBoardSquares();

                squareLocator.Reset();
                for (int counter = 0; counter < ChessImageConstants.SquareCount; counter++)
                {
                    ChessSquare square = (ChessSquare)squareList[counter];
                    square.SetStartLocation(new Point(squareLocator.NextX(), squareLocator.NextY()));
                    squareLocator.Increment();
                }

                // Empty the ChessBoard squares
                ChessImageConstants.parserChessBoardSquares.Clear();
                for (EnumSquareID sid = EnumSquareID.A1; sid <= EnumSquareID.H8; sid = ChessSquareID.IncrementEnumSquareID(sid))
                {
                    ChessImageConstants.parserChessBoardSquares.Add(sid, EnumPieceID.Empty);
                }
                //string initialGameState = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
                //ChessBoardParser.SetFEN(initialGameState);
            }
            catch (Exception E)
            {
                throw E;
            }
        }

        /// <summary>
        /// DrawChessPieces Method
        /// </summary>
        public void DrawChessPieces()
        {
            try
            {
                whitePieceList.Clear();
                blackPieceList.Clear();

                for (int i = 0; i < ChessImageConstants.SquareCount; i++)
                {
                    ((ChessSquare)squareList[i]).SetChessPiece(null);
                }

                CreatePieces();
            }
            catch (Exception E)
            {
                throw E;
            }
        }

        /// <summary>
        /// CreateBoardSquares method
        /// </summary>
        private void CreateBoardSquares()
        {
            EnumSquareColor squareColor = EnumSquareColor.Black;

            ChessSquare chessSquare;

            int row = 8;
            int column = 0;

            squareLocator.Reset();

            for (int counter = 0; counter < ChessImageConstants.SquareCount; counter++)
            {
                chessSquare = new ChessSquare();
                chessSquare.SetColor(GetSquareColor(squareColor));
                chessSquare.SetStartLocation(squareLocator.GetLocation());

                if (squareLocator.IsNewLine())
                {
                    row--;
                    column = 0;
                }
                else
                {
                    column++;
                }

                chessSquare.SetChessLocation(new Point(column, row));
                EnumSquareID sid = chessSquare.GetSquareID();

                squareList.Add(chessSquare);
                squareColor = chessSquare.GetColor();
                squareLocator.Increment();
            }
        }

        /// <summary>
        /// GetChessSquareID Accessor
        /// </summary>
        /// <returns></returns>
        public EnumSquareID GetID()
        {
            return squareID;
        }

        /// <summary>
        /// SetChessSquareID Accessor
        /// </summary>
        /// <param name="aSquareID"></param>
        public void SetID(EnumSquareID aSquareID)
        {
            squareID = aSquareID;
        }

        /// <summary>
        /// GetSquareIDfromLocation
        /// </summary>
        /// <param name="aLocation"></param>
        /// <returns>EnumSquareID</returns>
        private EnumSquareID GetSquareFromLocation(Point aLocation)
        {
            // the Chess Square Designation Way using Algebraic Notation
            uint theFile = 0;
            uint theRank = 0;
            uint aFile = 0;
            uint aRank = 0;
            uint j = 1;
            while (j <= ChessImageConstants.SquareCount)
            {
                theFile = (uint)aLocation.X + 1;
                theRank = (uint)aLocation.Y + 1;

                aFile = 1 + ((j - 1) % 8);
                aRank = 8 - ((j - 1) / 8);

                if (theFile == aFile && theRank == aRank)
                {
                    ChessImageConstants.parserSquareID = (EnumSquareID)(((aRank - 1) * 8) + (aFile - 1));
                    break;
                }
                j++;
            }
            this.SetID(ChessImageConstants.parserSquareID);
            return ChessImageConstants.parserSquareID;
        }

        /// <summary>
        /// CreatePieces method
        /// </summary>
        private void CreatePieces()
        {
            ChessSquare chessSquare;

            for (int counter = 0; counter < ChessImageConstants.SquareCount; counter++)
            {
                EnumSquareID key = (EnumSquareID)counter;
                chessSquare = chessBoard.GetSquareByID(key);
                EnumPieceID value = ChessImageConstants.parserChessBoardSquares[key];
                CreateChessPiece(chessSquare, value);
            }
        }

        /// <summary>
        /// CreateChessPiece by square and piece ID
        /// </summary>
        /// <param name="aChessSquare"></param>
        /// <param name="aChessPieceType"></param>
        /// <param name="aChessPieceColor"></param>
        /// <returns>ChessPiece</returns>
        private ChessPiece CreateChessPiece(ChessSquare aChessSquare, EnumPieceID aPieceID)
        {
            EnumPieceColor chessPieceColor = EnumPieceColor.White;
            EnumPieceType chessPieceType = EnumPieceType.Rook;

            int pieceNumber = (int)aPieceID;
            int whiteOffset = (int)EnumPieceColor.White;
            int blackOffset = (int)EnumPieceColor.Black;

            if (pieceNumber >= whiteOffset + 1 && pieceNumber <= whiteOffset + 6)
            {
                pieceNumber -= whiteOffset;
                chessPieceColor = EnumPieceColor.White;
            }
            else if (pieceNumber >= blackOffset + 1 && pieceNumber <= blackOffset + 6)
            {
                pieceNumber -= blackOffset;
                chessPieceColor = EnumPieceColor.Black;
            }
            else
            {
                chessPieceColor = EnumPieceColor.None;
                chessPieceType = EnumPieceType.None;
            }

            // King, Queen, Rook, Bishop, Knight, Pawn
            switch (pieceNumber)
            {
                case 1: chessPieceType = EnumPieceType.King; break;
                case 2: chessPieceType = EnumPieceType.Queen; break;
                case 3: chessPieceType = EnumPieceType.Rook; break;
                case 4: chessPieceType = EnumPieceType.Bishop; break;
                case 5: chessPieceType = EnumPieceType.Knight; break;
                case 6: chessPieceType = EnumPieceType.Pawn; break;
                default: chessPieceType = EnumPieceType.None; break;
            }

            ChessPiece chessPiece = new ChessPiece(chessPieceColor, chessPieceType, aChessSquare);
            EnumSquareID squareID = aChessSquare.GetSquareID();

            Point aLocation = new Point(aChessSquare.GetStartLocation().X + ChessImageConstants.ChessPieceLeft,
                aChessSquare.GetStartLocation().Y + ChessImageConstants.ChessPieceTop);

            chessPiece.SetStartLocation(aLocation);
            chessPiece.SetChessSquare(aChessSquare);

            aChessSquare.SetChessPiece(chessPiece);

            if (chessPieceColor == EnumPieceColor.White)
            {
                whitePieceList.Add(chessPiece);
            }
            else if (chessPieceColor == EnumPieceColor.Black)
            {
                blackPieceList.Add(chessPiece);
            }
            return chessPiece;
        }

        /// <summary>
        /// CreateChessPiece by square piece type and piece color
        /// </summary>
        /// <param name="aChessSquare"></param>
        /// <param name="aChessPieceType"></param>
        /// <param name="aChessPieceColor"></param>
        /// <returns>ChessPiece</returns>
        private ChessPiece CreateChessPiece(ChessSquare aChessSquare, EnumPieceType aChessPieceType, EnumPieceColor aChessPieceColor)
        {
            ChessPiece chessPiece = new ChessPiece(aChessPieceColor, aChessPieceType, aChessSquare);
            EnumSquareID squareID = aChessSquare.GetSquareID();

            Point aLocation = new Point(aChessSquare.GetStartLocation().X + ChessImageConstants.ChessPieceLeft,
                aChessSquare.GetStartLocation().Y + ChessImageConstants.ChessPieceTop);

            chessPiece.SetStartLocation(aLocation);
            chessPiece.SetChessSquare(aChessSquare);

            aChessSquare.SetChessPiece(chessPiece);

            if (aChessPieceColor == EnumPieceColor.White)
            {
                whitePieceList.Add(chessPiece);
            }
            else
            {
                blackPieceList.Add(chessPiece);
            }
            return chessPiece;
        }

        /// <summary>
        /// GetSquareColor method - alternating colors
        /// </summary>
        /// <param name="theOldSquareColor"></param>
        /// <returns></returns>
        private EnumSquareColor GetSquareColor(EnumSquareColor theOldSquareColor)
        {
            if (!squareLocator.IsNewLine())
            {
                if (theOldSquareColor == EnumSquareColor.White)
                    return EnumSquareColor.Black;
                else
                    return EnumSquareColor.White;
            }
            else
                return theOldSquareColor;
        }
    }
}


