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

namespace ChessByBird.Imaging.Imager
{
    /// <summary>
    /// ChessLocationCalculatorKnight class
    /// </summary>
    internal class ChessLocationCalculatorKnight : ChessLocationCalculator
	{
        /// <summary>
        /// ChessLocationCalculatorKnight constructor
        /// </summary>
        /// <param name="chessboard"></param>
        public ChessLocationCalculatorKnight(ChessBoard chessboard) : base(chessboard) {}

        /// <summary>
        /// CalculateLocations
        /// </summary>
        /// <param name="aSquare"></param>
        /// <param name="isSupportPosition"></param>
        /// <returns></returns>
		internal override ArrayList CalculateLocations(ChessSquare aSquare, bool isSupportPosition)
		{
			base.CalculateLocations(aSquare, isSupportPosition);
			
			UpLeft   ( new Point(aSquare.GetChessLocation().X, aSquare.GetChessLocation().Y), isSupportPosition);
			UpRight  ( new Point(aSquare.GetChessLocation().X, aSquare.GetChessLocation().Y), isSupportPosition);
			DownLeft ( new Point(aSquare.GetChessLocation().X, aSquare.GetChessLocation().Y), isSupportPosition);
			DownRight( new Point(aSquare.GetChessLocation().X, aSquare.GetChessLocation().Y), isSupportPosition);
			LeftUp   ( new Point(aSquare.GetChessLocation().X, aSquare.GetChessLocation().Y), isSupportPosition);
			LeftDown ( new Point(aSquare.GetChessLocation().X, aSquare.GetChessLocation().Y), isSupportPosition);
			RightUp  ( new Point(aSquare.GetChessLocation().X, aSquare.GetChessLocation().Y), isSupportPosition);
			RightDown( new Point(aSquare.GetChessLocation().X, aSquare.GetChessLocation().Y), isSupportPosition);

			return validSquaresList;
		}
		
        /// <summary>
        /// ProcessSquare
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>new bool</returns>
		protected new bool ProcessSquare(int x, int y)
		{
			ChessSquare b = chessBoard.GetSquareByItsLocation(new Point(x, y));
			if (b != null) 
			{
				ChessPiece piece =  b.GetChessPiece();
				if (piece != null) 
				{
					if (piece.GetPieceColor() == originalSquare.GetChessPiece().GetPieceColor()) 
					{
						return false;
					}
				}
				validSquaresList.Add(b);
				return false;
			}
			return false;
		}

        /// <summary>
        /// ProcessSquareInclusive
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>new bool</returns>
		protected new bool ProcessSquareInclusive(int x, int y)
		{
			ChessSquare s = chessBoard.GetSquareByItsLocation(new Point(x, y));
			if (s != null) 
			{
				validSquaresList.Add(s);
				return false;
			}
			return false;
		}

		// Up

        /// <summary>
        /// UpLeft
        /// </summary>
        /// <param name="aLocation"></param>
        /// <param name="isSupportPosition"></param>
		private void UpLeft(Point aLocation, bool isSupportPosition)	
		{
			if (ChessHelper.KnightUpLeft(ref aLocation))		
				if (isSupportPosition)
					this.ProcessSquareInclusive(aLocation.X, aLocation.Y);
				else
					this.ProcessSquare(aLocation.X, aLocation.Y);
		}

        /// <summary>
        /// UpRight
        /// </summary>
        /// <param name="aLocation"></param>
        /// <param name="isSupportPosition"></param>
		private void UpRight(Point aLocation, bool isSupportPosition)	
		{
			if (ChessHelper.KnightUpRight(ref aLocation))		
				if (isSupportPosition)
					this.ProcessSquareInclusive(aLocation.X, aLocation.Y);
				else
					this.ProcessSquare(aLocation.X, aLocation.Y);
		}

		// Down

        /// <summary>
        /// DownRight
        /// </summary>
        /// <param name="aLocation"></param>
        /// <param name="isSupportPosition"></param>
		private void DownRight(Point aLocation, bool isSupportPosition)	
		{
			if (ChessHelper.KnightDownRight(ref aLocation))		
				if (isSupportPosition)
					this.ProcessSquareInclusive(aLocation.X, aLocation.Y);
				else
					this.ProcessSquare(aLocation.X, aLocation.Y);
		}
		
        /// <summary>
        /// DownLeft
        /// </summary>
        /// <param name="aLocation"></param>
        /// <param name="isSupportPosition"></param>
		private void DownLeft(Point aLocation, bool isSupportPosition)	
		{
			if (ChessHelper.KnightDownLeft(ref aLocation))		
				if (isSupportPosition)
					this.ProcessSquareInclusive(aLocation.X, aLocation.Y);
				else
					this.ProcessSquare(aLocation.X, aLocation.Y);
		}

		// Left

        /// <summary>
        /// LeftDown
        /// </summary>
        /// <param name="aLocation"></param>
        /// <param name="isSupportPosition"></param>
		private void LeftDown(Point aLocation, bool isSupportPosition)	
		{
			if (ChessHelper.KnightLeftDown(ref aLocation))		
				if (isSupportPosition)
					this.ProcessSquareInclusive(aLocation.X, aLocation.Y);
				else
					this.ProcessSquare(aLocation.X, aLocation.Y);
		}

        /// <summary>
        /// LeftUp
        /// </summary>
        /// <param name="aLocation"></param>
        /// <param name="isSupportPosition"></param>
		private void LeftUp(Point aLocation, bool isSupportPosition)	
		{
			if (ChessHelper.KnightLeftUp(ref aLocation))		
				if (isSupportPosition)
					this.ProcessSquareInclusive(aLocation.X, aLocation.Y);
				else
					this.ProcessSquare(aLocation.X, aLocation.Y);
		}

		// Right

        /// <summary>
        /// RightDown
        /// </summary>
        /// <param name="aLocation"></param>
        /// <param name="isSupportPosition"></param>
		private void RightDown(Point aLocation, bool isSupportPosition)	
		{
			if (ChessHelper.KnightRightDown(ref aLocation))		
				if (isSupportPosition)
					this.ProcessSquareInclusive(aLocation.X, aLocation.Y);
				else
					this.ProcessSquare(aLocation.X, aLocation.Y);
		}

        /// <summary>
        /// RightUp
        /// </summary>
        /// <param name="aLocation"></param>
        /// <param name="isSupportPosition"></param>
		private void RightUp(Point aLocation, bool isSupportPosition)	
		{
			if (ChessHelper.KnightRightUp(ref aLocation))		
				if (isSupportPosition)
					this.ProcessSquareInclusive(aLocation.X, aLocation.Y);
				else
					this.ProcessSquare(aLocation.X, aLocation.Y);
		}

	}
}
