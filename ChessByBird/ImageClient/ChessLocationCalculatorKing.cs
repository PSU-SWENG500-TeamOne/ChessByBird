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

namespace ChessByBird.ImageClient
{
    /// <summary>
    /// ChessLocationCalculatorKingclass
    /// </summary>
	internal class ChessLocationCalculatorKing: ChessLocationCalculator
	{
        /// <summary>
        /// ChessLocationCalculatorKing constructor
        /// </summary>
        /// <param name="aChessBoard"></param>
        public ChessLocationCalculatorKing(ChessBoard aChessBoard) : base(aChessBoard) {}

        /// <summary>
        /// CalculateLocations
        /// </summary>
        /// <param name="aSquare"></param>
        /// <param name="isSupportPosition"></param>
        /// <returns>ArrayList</returns>
		internal override ArrayList CalculateLocations(ChessSquare aSquare, bool isSupportPosition)
		{
            base.CalculateLocations(aSquare, isSupportPosition);
			
			GoUp       ( new Point(aSquare.GetChessLocation().X, aSquare.GetChessLocation().Y) , isSupportPosition);
			GoDown     ( new Point(aSquare.GetChessLocation().X, aSquare.GetChessLocation().Y), isSupportPosition );
			GoRight    ( new Point(aSquare.GetChessLocation().X, aSquare.GetChessLocation().Y), isSupportPosition );
			GoLeft     ( new Point(aSquare.GetChessLocation().X, aSquare.GetChessLocation().Y), isSupportPosition );
			GoLeftUp   ( new Point(aSquare.GetChessLocation().X, aSquare.GetChessLocation().Y), isSupportPosition );
			GoLeftDown ( new Point(aSquare.GetChessLocation().X, aSquare.GetChessLocation().Y), isSupportPosition );
			GoRightUp  ( new Point(aSquare.GetChessLocation().X, aSquare.GetChessLocation().Y), isSupportPosition );
			GoRightDown( new Point(aSquare.GetChessLocation().X, aSquare.GetChessLocation().Y), isSupportPosition );
			CastlePositions();
			
			return validSquaresList;
		}

        /// <summary>
        /// CastlePositions method
        /// </summary>
		private void CastlePositions()
		{
			if (originalSquare == null)
				return;

			ChessPiece piece = originalSquare.GetChessPiece();

			if (piece == null)
				return;

			// It must be KING
			if ( piece.GetPieceType() != EnumPieceType.King)
				return;

			// Must be able to castle
			if (! piece.IsCastlingPossible())
				return;

			Point point = originalSquare.GetChessLocation();

			bool GotPiece = false;

			if (CanCastle(new Point(0, point.Y)))
			{
				for (int i=point.X - 1; i>0; i--)
				{
                    ChessSquare s = chessBoard.GetSquareByItsLocation(new Point(i, point.Y));

					if (s.GetChessPiece() != null)
						GotPiece = true;
				}

				if (! GotPiece)
                    validSquaresList.Add(chessBoard.GetSquareByItsLocation(new Point(point.X - 2, point.Y)));
			}			

			GotPiece = false;

			if (CanCastle(new Point(7, point.Y)))
			{

				for (int i=point.X + 1; i<7; i++)
				{
                    ChessSquare s = chessBoard.GetSquareByItsLocation(new Point(i, point.Y));

					if (s.GetChessPiece() != null)
						GotPiece = true;
				}

				if (! GotPiece)
                    validSquaresList.Add(chessBoard.GetSquareByItsLocation(new Point(point.X + 2, point.Y)));
			}

		}

        /// <summary>
        /// CanCastle
        /// </summary>
        /// <param name="aLocation"></param>
        /// <returns>bool</returns>
		private bool CanCastle(Point aLocation)
		{
			ChessSquare aSquare = chessBoard.GetSquareByItsLocation(aLocation);

			if (aSquare == null) 
				return false;

			ChessPiece piece = aSquare.GetChessPiece();

			if (piece == null)
				return false;

			if (piece.GetPieceType() != EnumPieceType.Rook)
				return false;

			if (! piece.IsCastlingPossible())
				return false;

			return true;
		}

        /// <summary>
        /// GoRight
        /// </summary>
        /// <param name="aLocation"></param>
        /// <param name="isSupportPosition"></param>
		private void GoRight(Point aLocation, bool isSupportPosition)
		{
			 if (ChessHelper.IncrementX(ref aLocation))		
				 if (isSupportPosition)
					 ProcessSquareInclusive(aLocation.X, aLocation.Y);
				else
					ProcessSquare(aLocation.X, aLocation.Y);
		}

        /// <summary>
        /// GoLeft
        /// </summary>
        /// <param name="aLocation"></param>
        /// <param name="isSupportPosition"></param>
		private void GoLeft(Point aLocation, bool isSupportPosition)
		{
			if (ChessHelper.DecrementX(ref aLocation))		
				if (isSupportPosition)
                    ProcessSquareInclusive(aLocation.X, aLocation.Y);
				else
                    ProcessSquare(aLocation.X, aLocation.Y);
		}

        /// <summary>
        /// GoUp
        /// </summary>
        /// <param name="aLocation"></param>
        /// <param name="isSupportPosition"></param>
		private void GoUp(Point aLocation, bool isSupportPosition)
		{
			if (ChessHelper.DecrementY(ref aLocation))		
				if (isSupportPosition)
                    ProcessSquareInclusive(aLocation.X, aLocation.Y);
				else
                    ProcessSquare(aLocation.X, aLocation.Y);
		}

        /// <summary>
        /// GoDown
        /// </summary>
        /// <param name="aLocation"></param>
        /// <param name="isSupportPosition"></param>
		private void GoDown(Point aLocation, bool isSupportPosition)
		{
			if (ChessHelper.IncrementY(ref aLocation))		
				if (isSupportPosition)
                    ProcessSquareInclusive(aLocation.X, aLocation.Y);
				else
                    ProcessSquare(aLocation.X, aLocation.Y);
		}

        /// <summary>
        /// GoLeftUp
        /// </summary>
        /// <param name="aLocation"></param>
        /// <param name="isSupportPosition"></param>
		private void GoLeftUp(Point aLocation, bool isSupportPosition)
		{
			if (ChessHelper.DecXDecY(ref aLocation))		
				if (isSupportPosition)
                    ProcessSquareInclusive(aLocation.X, aLocation.Y);
				else
					ProcessSquare(aLocation.X, aLocation.Y);
		}

        /// <summary>
        /// GoLeftDown
        /// </summary>
        /// <param name="aLocation"></param>
        /// <param name="isSupportPosition"></param>
		private void GoLeftDown(Point aLocation, bool isSupportPosition)
		{
			if (ChessHelper.DecXIncY(ref aLocation))		
				if (isSupportPosition)
                    ProcessSquareInclusive(aLocation.X, aLocation.Y);
				else
					ProcessSquare(aLocation.X, aLocation.Y);
		}

        /// <summary>
        /// GoRightUp
        /// </summary>
        /// <param name="aLocation"></param>
        /// <param name="isSupportPosition"></param>
		private void GoRightUp(Point aLocation, bool isSupportPosition)
		{
			if (ChessHelper.IncXDecY(ref aLocation))		
				if (isSupportPosition)
                    ProcessSquareInclusive(aLocation.X, aLocation.Y);
				else
					ProcessSquare(aLocation.X, aLocation.Y);
		}

        /// <summary>
        /// GoRightDown
        /// </summary>
        /// <param name="aLocation"></param>
        /// <param name="isSupportPosition"></param>
		private void GoRightDown(Point aLocation, bool isSupportPosition)
		{
			if (ChessHelper.IncXIncY(ref aLocation))		
				if (isSupportPosition)
                    ProcessSquareInclusive(aLocation.X, aLocation.Y);
				else
					ProcessSquare(aLocation.X, aLocation.Y);
		}

	}

}
