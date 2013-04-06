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
using System.Drawing;
using System.Windows.Forms;

namespace ChessByBird.ImagingProject
{

    /// <summary>
    /// ChessBoard class
    /// </summary>
    public class ChessBoard
    {
        /// <summary>
        /// Class variables
        /// </summary>
        private PictureBox chessBoardBox;

        private EnumSquareID squareID;

        private ArrayList squareList;
        private ArrayList whitePieceList;
        private ArrayList blackPieceList;

        private ChessSquareFactory squareFactory;
        private ChessPieceFactory chessPieceFactory;
        private ChessBoardInitializer chessBoardInitializer;

        private ChessSquareLocator squareLocator;
        private ChessLocationCalculatorFactory chessLocationCalculatorFactory;
        private ChessBoardImageGenerator chessBoardImageGenerator;

        /// <summary>
        /// ChessBoardStatic
        /// </summary>
        /// <param name="aChessBoardBox"></param>
        /// <returns></returns>
        public ChessBoard(ChessBoardImageGenerator aChessBoardImageGenerator, PictureBox aPictureBox)
        {
            chessBoardImageGenerator = aChessBoardImageGenerator;

            if (aPictureBox.Handle == null)
            {
                throw new Exception("Bad PictureBox");
            }

            chessBoardBox = aPictureBox;

            squareList = new ArrayList();
            whitePieceList = new ArrayList();
            blackPieceList = new ArrayList();

            chessPieceFactory = new ChessPieceFactory();
            squareFactory = new ChessSquareFactory();
            squareLocator = new ChessSquareLocator();

            chessBoardInitializer = new ChessBoardInitializer(
                this, squareList, whitePieceList, blackPieceList, squareFactory, chessPieceFactory, squareLocator);

            chessBoardInitializer.Initialize();
            chessBoardBox.Paint += new PaintEventHandler(paint);

            chessLocationCalculatorFactory = new ChessLocationCalculatorFactory(this);
        }

        /// <summary>
        /// paint method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="mouseEvent"></param>
        public void paint(object sender, PaintEventArgs mouseEvent)
        {
            Graphics g = mouseEvent.Graphics;
            try
            {
                 Draw(g);
            }
            finally
            {
                // g.Dispose(); // Can not dispose here
            }
        }

        /// <summary>
        /// InitializeChessBoard
        /// </summary>
        public void InitializeChessBoard()
        {
            try
            {
                chessBoardInitializer.DrawChessPieces();
            }
            catch (Exception E)
            {
                throw E;
            }
            chessBoardBox.Refresh();
        }

        /// <summary>
        /// Refresh
        /// </summary>
        public void Refresh()
        {
            chessBoardBox.Refresh();
        }

        //////////////////// Getters ////////////////////////////

        /// <summary>
        /// GetSize method
        /// </summary>
        /// <returnsSizereturns>
        public Size GetSize()
        {
            int height = 20;
            int width = 20;

            height = (ChessImageConstants.SquareSize * ChessImageConstants.SquaresPerRow)
                + (ChessImageConstants.ChessBoardLeft * 2);

            width = height;
            return new Size(width, height);
        }

        /// <summary>
        /// GetSquare method
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>ChessSquare</returns>
        public ChessSquare GetSquare(int x, int y)
        {
            ChessSquare square;

            int chessBoardWidth = ChessImageConstants.SquareSize * ChessImageConstants.SquaresPerRow;

            if ((x < ChessImageConstants.ChessBoardLeft) || (y < ChessImageConstants.ChessBoardTop) ||
                (x > ChessImageConstants.ChessBoardLeft + chessBoardWidth) || (y > ChessImageConstants.ChessBoardLeft + chessBoardWidth))
                return null;

            for (int i = 0; i < ChessImageConstants.SquareCount; i++)
            {
                square = (ChessSquare)squareList[i];

                if (square != null)
                    if (square.IsContained(x, y))
                        return square;
            }
            return null;
        }

        /// <summary>
        /// GetChessPiece method
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>ChessPiece</returns>
        public ChessPiece GetChessPiece(int x, int y)
        {
            ChessSquare square = GetSquare(x, y);
            if (square != null)
                return (ChessPiece)square.GetChessPiece();
            else
                return null;
        }

        /// <summary>
        /// GetSquareByID method
        /// </summary>
        /// <param name="aLocation"></param>
        /// <returns>ChessSquare</returns>
        public ChessSquare GetSquareByID(EnumSquareID aSquareID)
        {
            ChessSquare square;
            for (int i = ChessImageConstants.SquareCount-1; i > -1; i--)
            {
                square = (ChessSquare)squareList[i];

                if (square != null)
                {
                    if (square.GetChessSquareID() == aSquareID)
                    {
                        return square;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// GetSquareByItsLocation method
        /// </summary>
        /// <param name="aLocation"></param>
        /// <returns>ChessSquare</returns>
        public ChessSquare GetSquareByItsLocation(Point aLocation)
        {
            ChessSquare square;
            for (int i = 0; i < ChessImageConstants.SquareCount; i++)
            {
                square = (ChessSquare)squareList[i];

                if (square != null)
                {
                    if ((square.GetChessLocation().X == aLocation.X)
                        && (square.GetChessLocation().Y == aLocation.Y))
                    {
                        EnumSquareID squareID = square.GetSquareIDfromLocation(aLocation);
                        square.SetChessSquareID(squareID);
                        return square;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// GetChessPieceAtSquare method
        /// </summary>
        /// <param name="square"></param>
        /// <returns>ChessPiece</returns>
        private ChessPiece GetChessPieceAtSquare(ChessSquare square)
        {
            if (square != null)
            {
                ChessPiece chessPiece = (ChessPiece)square.GetChessPiece();
                if (chessPiece != null)
                    return chessPiece;
                else
                    return null;
            }
            else
                return null;
        }

        /// <summary>
        /// GetWhitePieceList
        /// </summary>
        /// <returns>ArrayList</returns>
        public ArrayList GetWhitePieceList()
        {
            return whitePieceList;
        }

        /// <summary>
        /// GetBlackPieceList
        /// </summary>
        /// <returns>ArrayList</returns>
        public ArrayList GetBlackPieceList()
        {
            return blackPieceList;
        }

        //////////////////// MOVE ////////////////////////////

        /// <summary>
        /// RealMove method
        /// </summary>
        /// <param name="aMovingPiece"></param>
        /// <param name="aNewSquare"></param>
        /// <param name="aOriginalSquare"></param>
        private void RealMove(ChessPiece aMovingPiece, ChessSquare aNewSquare, ChessSquare aOriginalSquare)
        {
            aOriginalSquare.SetChessPiece(null);
            aMovingPiece.SetChessSquare(aNewSquare);
            aNewSquare.SetChessPiece(aMovingPiece);
        }

        /// <summary>
        /// MovePiece method
        /// </summary>
        /// <param name="aMovingPiece"></param>
        /// <param name="aSquare"></param>
        /// <param name="aoriginalSquare"></param>
        /// <returns>bool</returns>
        public bool MovePiece(ChessPiece aMovingPiece, ChessSquare aSquare, ChessSquare aoriginalSquare)
        {
            // if new square contains a piece, make that piece's square to null
            ChessPiece aCapturedPiece = aSquare.GetChessPiece();

            // Move the Piece 
            RealMove(aMovingPiece, aSquare, aoriginalSquare);

            // Set Piece's Start Position
            aMovingPiece.SetStartLocation(new Point(aSquare.GetStartLocation().X + ChessImageConstants.ChessPieceLeft,
                aSquare.GetStartLocation().Y + ChessImageConstants.ChessPieceTop));

            return true;
        }

        ////////////////////// DRAWING ////////////////////

        /// <summary>
        /// DrawSquare method
        /// </summary>
        /// <param name="g"></param>
        /// <param name="aChessSquare"></param>
        /// <param name="aIsHighlight"></param>
        /// <param name="aIsLastMove"></param>
        private void DrawSquare(Graphics g, ChessSquare aChessSquare, bool aIsHighlight, bool aIsLastMove)
        {
            if (aChessSquare != null)
            {
                aChessSquare.Draw(g, squareFactory, aIsHighlight, aIsLastMove);

                ChessPiece chessPiece = (ChessPiece)aChessSquare.GetChessPiece();

                DrawPiece(g, chessPiece);
            }
        }

        /// <summary>
        /// DrawPiece method
        /// </summary>
        /// <param name="g"></param>
        /// <param name="aChessPiece"></param>
        public void DrawPiece(Graphics g, ChessPiece aChessPiece)
        {
            if (aChessPiece != null)
                aChessPiece.Draw(g, chessPieceFactory);
        }

        /// <summary>
        /// Draw method
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            int width = ChessImageConstants.SquareSize * ChessImageConstants.SquaresPerRow;

            g.FillRectangle(new SolidBrush(ChessImageConstants.ChessBoardBorderColor),
                ChessImageConstants.ChessBoardLeft - 10, ChessImageConstants.ChessBoardTop - 10, width + 20, width + 20);

            ChessSquare chessSquare;

            for (int i = 0; i < ChessImageConstants.SquareCount; i++)
            {
                chessSquare = (ChessSquare)squareList[i];
                DrawSquare(g, chessSquare, false, chessSquare.GetIsLastMove());
            }
        }

        /// <summary>
        /// DrawChessPieces Method
        /// </summary>
        public void DrawChessPieces()
        {
            whitePieceList.Clear();
            blackPieceList.Clear();

            for (int i = 0; i < ChessImageConstants.SquareCount; i++)
            {
                ((ChessSquare) squareList[i]).SetChessPiece(null);
            }

            try
            {
                CreatePieces();
            }
            catch (Exception E)
            {
                throw E;
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

            for (int counter = 0; counter < ChessImageConstants.SquareCount; counter++ )
            {
                EnumSquareID key = (EnumSquareID)counter;
                chessSquare = this.GetSquareByID(key);
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
            EnumPieceType chessPieceType = EnumPieceType.None;

            int pieceNumber = (int)aPieceID;
            if( pieceNumber >= 11 && pieceNumber <= 16) 
            {
                pieceNumber -= 10;
                chessPieceColor = EnumPieceColor.White;
            }
            else if (pieceNumber >= 21 && pieceNumber <= 26)
            {
                pieceNumber -= 20;
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

