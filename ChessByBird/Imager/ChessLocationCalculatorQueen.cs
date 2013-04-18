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
    /// ChessLocationCalculatorQueen class
    /// </summary>
    internal class ChessLocationCalculatorQueen : ChessLocationCalculator
	{
        /// <summary>
        /// ChessLocationCalculatorQueen constructor
        /// </summary>
        /// <param name="chessboard"></param>
		public ChessLocationCalculatorQueen(ChessBoard chessboard) : base(chessboard) {}

        /// <summary>
        /// CalculateLocations
        /// </summary>
        /// <param name="aSquare"></param>
        /// <param name="isSupportPosition"></param>
        /// <returns>ArrayList</returns>
		internal override ArrayList CalculateLocations(ChessSquare aSquare, bool isSupportPosition)
		{
			base.CalculateLocations(aSquare, isSupportPosition);

			GoUp       ( new Point(aSquare.GetChessLocation().X, aSquare.GetChessLocation().Y), isSupportPosition );
			GoDown     ( new Point(aSquare.GetChessLocation().X, aSquare.GetChessLocation().Y), isSupportPosition );
			GoRight    ( new Point(aSquare.GetChessLocation().X, aSquare.GetChessLocation().Y), isSupportPosition );
			GoLeft     ( new Point(aSquare.GetChessLocation().X, aSquare.GetChessLocation().Y), isSupportPosition );

			GoLeftUp   ( new Point(aSquare.GetChessLocation().X, aSquare.GetChessLocation().Y), isSupportPosition );
			GoLeftDown ( new Point(aSquare.GetChessLocation().X, aSquare.GetChessLocation().Y), isSupportPosition );
			GoRightUp  ( new Point(aSquare.GetChessLocation().X, aSquare.GetChessLocation().Y), isSupportPosition );
			GoRightDown( new Point(aSquare.GetChessLocation().X, aSquare.GetChessLocation().Y), isSupportPosition );

			return validSquaresList;
		}
	
        /// <summary>
        /// GoRight
        /// </summary>
        /// <param name="aLocation"></param>
        /// <param name="isSupportPosition"></param>
		private void GoRight(Point aLocation, bool isSupportPosition)
		{
			while (ChessHelper.IncrementX(ref aLocation))		
			{
				if (isSupportPosition)
				{
					if (! ProcessSquareInclusive(aLocation.X, aLocation.Y))
						break;
				}
				else
				{
					if (! ProcessSquare(aLocation.X, aLocation.Y))
						break;
				}
			}
		}

        /// <summary>
        /// GoLeft
        /// </summary>
        /// <param name="aLocation"></param>
        /// <param name="isSupportPosition"></param>
		private void GoLeft(Point aLocation, bool isSupportPosition)
		{
			while (ChessHelper.DecrementX(ref aLocation))		
			{
				if (isSupportPosition)
				{
					if (! ProcessSquareInclusive(aLocation.X, aLocation.Y))
						break;
				}
				else
				{
					if (! ProcessSquare(aLocation.X, aLocation.Y))
						break;
				}
			}
		}

        /// <summary>
        /// GoUp
        /// </summary>
        /// <param name="aLocation"></param>
        /// <param name="isSupportPosition"></param>
		private void GoUp(Point aLocation, bool isSupportPosition)
		{
			while (ChessHelper.DecrementY(ref aLocation))		
			{
				if (isSupportPosition)
				{
					if (! ProcessSquareInclusive(aLocation.X, aLocation.Y))
						break;
				}
				else
				{
					if (! ProcessSquare(aLocation.X, aLocation.Y))
						break;
				}
			}
		}

        /// <summary>
        /// GoDown
        /// </summary>
        /// <param name="aLocation"></param>
        /// <param name="isSupportPosition"></param>
		private void GoDown(Point aLocation, bool isSupportPosition)
		{
			while (ChessHelper.IncrementY(ref aLocation))		
			{
				if (isSupportPosition)
				{
					if (! ProcessSquareInclusive(aLocation.X, aLocation.Y))
						break;
				}
				else
				{
					if (! ProcessSquare(aLocation.X, aLocation.Y))
						break;
				}
			}
		}

        /// <summary>
        /// GoLeftUp
        /// </summary>
        /// <param name="aLocation"></param>
        /// <param name="isSupportPosition"></param>
		private void GoLeftUp(Point aLocation, bool isSupportPosition)
		{
			while (ChessHelper.DecXDecY(ref aLocation))		
			{
				if (isSupportPosition)
				{
					if (! ProcessSquareInclusive(aLocation.X, aLocation.Y))
						break;
				}
				else
				{
					if (! ProcessSquare(aLocation.X, aLocation.Y))
						break;
				}
			}
		}

        /// <summary>
        /// GoLeftDown
        /// </summary>
        /// <param name="aLocation"></param>
        /// <param name="isSupportPosition"></param>
		private void GoLeftDown(Point aLocation, bool isSupportPosition)
		{
			while (ChessHelper.DecXIncY(ref aLocation))		
			{
				if (isSupportPosition)
				{
					if (! ProcessSquareInclusive(aLocation.X, aLocation.Y))
						break;
				}
				else
				{
					if (! ProcessSquare(aLocation.X, aLocation.Y))
						break;
				}
			}
		}

        /// <summary>
        /// GoRightUp
        /// </summary>
        /// <param name="aLocation"></param>
        /// <param name="isSupportPosition"></param>
		private void GoRightUp(Point aLocation, bool isSupportPosition)
		{
			while (ChessHelper.IncXDecY(ref aLocation))		
			{
				if (isSupportPosition)
				{
					if (! ProcessSquareInclusive(aLocation.X, aLocation.Y))
						break;
				}
				else
				{
					if (! ProcessSquare(aLocation.X, aLocation.Y))
						break;
				}
			}
		}

        /// <summary>
        /// GoRightDown
        /// </summary>
        /// <param name="aLocation"></param>
        /// <param name="isSupportPosition"></param>
		private void GoRightDown(Point aLocation, bool isSupportPosition)
		{
			while (ChessHelper.IncXIncY(ref aLocation))		
			{
				if (isSupportPosition)
				{
					if (! ProcessSquareInclusive(aLocation.X, aLocation.Y))
						break;
				}
				else
				{
					if (! ProcessSquare(aLocation.X, aLocation.Y))
						break;
				}
			}
		}
	}
}
