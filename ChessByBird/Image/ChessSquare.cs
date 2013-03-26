/*******************************************************************************
 *  Penn State University Software Engineering Graduate Program
 *  Authors: Team 1: Zachary Carson, Aaron Eugene, Steve Haggerty, Joseph Oakes
 *  Date: Spring 2013
 *  Course: SWENG 500 Software Engineering Studio
 *  Professor: Mohamad Kassab
 *  Project: Chess By Bird Capstone group project
*******************************************************************************/

using System;
using System.Drawing;
using System.Text;

namespace ChessByBird.ImagingProject
{
	public class ChessSquare
	{
        /// <summary>
        /// Class Variables
        /// </summary>
        private EnumSquareID squareID;
		private EnumSquareColor squareColor;
		private ChessPiece chessPiece;
		private Point chessLocation;
		private Point startLocation;
		private bool isHighlight;
		private bool isLastMove;

        /// <summary>
        /// ChessSquare Constructor
        /// </summary>
        public ChessSquare()
		{
			chessLocation = new Point(0,0);
			startLocation = new Point(0,0);
			chessPiece = null;
			isLastMove = false;
            squareID = EnumSquareID.A1;
		}

        /// <summary>
        /// Draw Square Method
        /// </summary>
        /// <param name="g"></param>
        /// <param name="aChessSquareFactory"></param>
        /// <param name="aIsHighlight"></param>
        /// <param name="aIsLastMove"></param>
        internal void Draw(Graphics g, ChessSquareFactory aChessSquareFactory, bool aIsHighlight, bool aIsLastMove)
        {
            StringBuilder title = new StringBuilder();
            ChessSquareRectangle chessSquareRectangle = aChessSquareFactory.GetSquareRectangle(squareColor);

            if (chessPiece == null)
                title.Append(chessLocation.ToString());
            else
                title.Append(chessLocation.ToString() + '/' + chessPiece.GetPieceType().ToString());

            chessSquareRectangle.Draw(g, startLocation.X, startLocation.Y, title.ToString(), aIsHighlight, aIsLastMove);
        }

        /// <summary>
        /// IsContained Method - is square physically contained within the board
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsContained(int x, int y)
        {
            return ((x > startLocation.X) && (x < startLocation.X + ChessImageConstants.SquareSize) &&
                    (y > startLocation.Y) && (y < startLocation.Y + ChessImageConstants.SquareSize));
        }

        /// <summary>
        /// GetChessSquareID Accessor
        /// </summary>
        /// <returns></returns>
        public EnumSquareID GetSquareID()
        {
            return squareID;
        }

        /// <summary>
        /// SetChessSquareID Accessor
        /// </summary>
        /// <param name="aSquareID"></param>
        public void SetSquareID(EnumSquareID aSquareID)
        {
            squareID = aSquareID;
        }

        /// <summary>
        /// GetColor Accessor
        /// </summary>
        /// <returns></returns>
        public EnumSquareColor GetColor()
		{
			return squareColor;
		}

        /// <summary>
        /// SetColor Accessor
        /// </summary>
        /// <param name="aSquareColor"></param>
        public void SetColor(EnumSquareColor aSquareColor)
		{
			squareColor = aSquareColor;
		}

        /// <summary>
        /// GetStartLocation Accessor
        /// </summary>
        /// <returns></returns>
        public Point GetStartLocation()
		{
			return startLocation;
		}

        /// <summary>
        /// SetStartLocation Accessor
        /// </summary>
        /// <param name="aLocation"></param>
        public void SetStartLocation(Point aLocation)
		{
            startLocation = aLocation;
		}
        /// <summary>
        /// GetChessSquareID Accessor
        /// </summary>
        /// <returns></returns>
        public EnumSquareID GetChessSquareID()
        {
            return squareID;
        }

        /// <summary>
        /// SetChessSquareID Accessor
        /// </summary>
        /// <param name="aSquareID"></param>
        public void SetChessSquareID(EnumSquareID aSquareID)
        {
            squareID = aSquareID;
        }

        /// <summary>
        /// GetSquareIDfromLocation
        /// </summary>
        /// <param name="aLocation"></param>
        /// <returns>EnumSquareID</returns>
        public EnumSquareID GetSquareIDfromLocation(Point aLocation)
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
                    squareID = (EnumSquareID)(((aRank - 1) * 8) + (aFile - 1));
                    break;
                }
                j++;
            }
            return squareID;
        }

        /// <summary>
        /// getchesslocation accessor to help with unit testing
        /// </summary>
        /// <returns></returns>
        public Point GetChessLocation()
        {
            return chessLocation;
        }

        /// <summary>
        /// SetChessLocation Accessor
        /// </summary>
        /// <param name="aLocation"></param>
        public void SetChessLocation(Point aLocation)
		{
            if ((aLocation.X < 0) || (aLocation.X > 7) || (aLocation.Y < 0) || (aLocation.Y > 7))
                throw (new Exception(String.Format(
                    "Square.SetChessLocation : Invalid Location ({0},{1})", aLocation.X, aLocation.Y)));
           
            // the new FEN AN way
            squareID = GetSquareIDfromLocation(aLocation);

            // the original location way
            chessLocation = aLocation;
		}

        /// <summary>
        /// GetChessPiece Accessor
        /// </summary>
        /// <returns></returns>
        public ChessPiece GetChessPiece()
		{
			return chessPiece;
		}

        /// <summary>
        /// SetChessPiece Accessor
        /// </summary>
        /// <param name="aChessPiece"></param>
        public void SetChessPiece(ChessPiece aChessPiece)
		{
            chessPiece = aChessPiece;
		}

        /// <summary>
        /// GetIsHighlight Accessor
        /// </summary>
        /// <returns></returns>
        public bool GetIsHighlight()
        {
            return isHighlight;
        }

        /// <summary>
        /// SetIsHighlight Accessor
        /// </summary>
        /// <param name="aIsHighlight"></param>
        public void SetIsHighlight(bool aIsHighlight)
		{
			isHighlight = aIsHighlight;
		}

        /// <summary>
        /// GetIsLastMove Accessor
        /// </summary>
        /// <returns></returns>
        public bool GetIsLastMove()
        {
            return isLastMove;
        }

        /// <summary>
        /// SetIsLastMove Accessor
        /// </summary>
        /// <param name="aIsLastMove"></param>
        public void SetIsLastMove(bool aIsLastMove)
		{
			isLastMove = aIsLastMove;
		}
		
	}
}

