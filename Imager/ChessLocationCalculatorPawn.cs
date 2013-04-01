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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessByBird.ImagingProject
{
    /// <summary>
    /// ChessLocationCalculatorPawn class
    /// </summary>
	internal class ChessLocationCalculatorPawn : ChessLocationCalculator
	{
        /// <summary>
        /// Class variables
        /// </summary>
		ChessPlayer chessPlayer;

        /// <summary>
        /// ChessLocationCalculatorPawn constructor
        /// </summary>
        /// <param name="chessboard"></param>
		public ChessLocationCalculatorPawn(ChessBoard chessboard) : base (chessboard) {}

        /// <summary>
        /// SetCurrentPlayer
        /// </summary>
        /// <param name="aChessPlayer"></param>
        internal void SetCurrentPlayer(ChessPlayer aChessPlayer)
		{
			chessPlayer = aChessPlayer;
		}

        /// <summary>
        /// CalculateCaptureLocations
        /// </summary>
        /// <param name="square"></param>
        /// <param name="isSupportLocation"></param>
        /// <returns>ArrayList</returns>
		private ArrayList CalculateCaptureLocations(ChessSquare square, Boolean isSupportLocation)
		{	
			if (chessPlayer.GetPlayerType() == EnumPlayerType.WhitePlayer)
			{
				GoLeftDown(square.GetChessLocation(), isSupportLocation);
				GoRightDown(square.GetChessLocation(), isSupportLocation);
			}
			else if (chessPlayer.GetPlayerType() == EnumPlayerType.BlackPlayer)
			{
				GoLeftUp(square.GetChessLocation(), isSupportLocation);
				GoRightUp(square.GetChessLocation(), isSupportLocation);
			}
			return validSquaresList;
		}
		
        /// <summary>
        /// CalculateLocations
        /// </summary>
        /// <param name="aSquare"></param>
        /// <param name="isSupportLocation"></param>
        /// <returns>ArrayList</returns>
		internal override ArrayList CalculateLocations(ChessSquare aSquare, bool isSupportLocation)
		{
			base.CalculateLocations(aSquare, isSupportLocation);

			if (isSupportLocation)
				return this.CalculateCaptureLocations(aSquare, isSupportLocation);
			else
			{
				if (chessPlayer.GetPlayerType() == EnumPlayerType.WhitePlayer)
				{
					if (originalSquare.GetChessLocation().Y == 1)
						GoDown( aSquare.GetChessLocation(), 2);
					else
						GoDown( aSquare.GetChessLocation(), 1 );

					GoLeftDown(aSquare.GetChessLocation(), false);
					GoRightDown(aSquare.GetChessLocation(), false);
				}
				else if (chessPlayer.GetPlayerType() == EnumPlayerType.BlackPlayer)
				{
					if (originalSquare.GetChessLocation().Y == 6)
						GoUp( aSquare.GetChessLocation(), 2 );
					else
						GoUp( aSquare.GetChessLocation(), 1 );

					GoLeftUp(aSquare.GetChessLocation(), false);
					GoRightUp(aSquare.GetChessLocation(), false);
				}
				return validSquaresList;
			}
		}

        /// <summary>
        /// GoDown
        /// </summary>
        /// <param name="cp"></param>
        /// <param name="steps"></param>
		private void GoDown(Point cp, Byte steps)
		{
			byte aStep = 0;

			while( aStep < steps)
			{
				if (ChessHelper.IncrementY(ref cp))		
					ShouldProceedIfNoPiece(cp.X, cp.Y);

				aStep++;
			}
		}

        /// <summary>
        /// GoLeftUp
        /// </summary>
        /// <param name="cp"></param>
        /// <param name="isSupportLocation"></param>
		private void GoLeftUp(Point cp, bool isSupportLocation)	
		{
			if (ChessHelper.DecXDecY(ref cp))		
				if (isSupportLocation)
					ShouldProcessSquareForPawnInclusive(cp.X, cp.Y);
				else
					ShouldProcessSquareForPawn(cp.X, cp.Y);
		}

        /// <summary>
        /// GoLeftDown
        /// </summary>
        /// <param name="cp"></param>
        /// <param name="isSupportLocation"></param>
		private void GoLeftDown(Point cp, bool isSupportLocation)	
		{
			if (ChessHelper.DecXIncY(ref cp))		
				if (isSupportLocation)
					ShouldProcessSquareForPawnInclusive(cp.X, cp.Y);
				else
					ShouldProcessSquareForPawn(cp.X, cp.Y);
		}

        /// <summary>
        /// GoRightUp
        /// </summary>
        /// <param name="cp"></param>
        /// <param name="isSupportLocation"></param>
		private void GoRightUp(Point cp, bool isSupportLocation)	
		{
			if (ChessHelper.IncXDecY(ref cp))		
				if (isSupportLocation)
					ShouldProcessSquareForPawnInclusive(cp.X, cp.Y);
				else
					ShouldProcessSquareForPawn(cp.X, cp.Y);
		}

        /// <summary>
        /// GoRightDown
        /// </summary>
        /// <param name="cp"></param>
        /// <param name="isSupportLocation"></param>
		private void GoRightDown(Point cp, bool isSupportLocation)	
		{
			if (ChessHelper.IncXIncY(ref cp))		
				if (isSupportLocation)
					ShouldProcessSquareForPawnInclusive(cp.X, cp.Y);
				else
					ShouldProcessSquareForPawn(cp.X, cp.Y);
		}

        /// <summary>
        /// GoUp
        /// </summary>
        /// <param name="cp"></param>
        /// <param name="steps"></param>
		private void GoUp(Point cp,  Byte steps)
		{
			byte aStep = 0;

			while( aStep < steps)
			{
				if (ChessHelper.DecrementY(ref cp))		
			  		ShouldProceedIfNoPiece(cp.X, cp.Y);
				aStep++;
			}
		}

        /// <summary>
        /// ShouldProceedIfNoPiece
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>bool</returns>
		private bool ShouldProceedIfNoPiece(int x, int y)
		{
			ChessSquare b = chessBoard.GetSquareByItsLocation(new Point(x, y));
			if (b != null) 
			{
				if (b.GetChessPiece() == null)	
				{
					validSquaresList.Add(b);
					return true;
				}					
			}
			return false;
		}

        /// <summary>
        /// ShouldProcessSquareForPawnInclusive
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>bool</returns>
		private bool ShouldProcessSquareForPawnInclusive(int x, int y)
		{
			ChessSquare b = chessBoard.GetSquareByItsLocation(new Point(x, y));
			if (b != null) 
			{
				validSquaresList.Add(b);
				return true;
			}					
			return false;
		}

        /// <summary>
        /// ShouldProcessSquareForPawn
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>bool</returns>
		private bool ShouldProcessSquareForPawn(int x, int y)
		{
			ChessSquare square = chessBoard.GetSquareByItsLocation(new Point(x, y));
			if (square != null) 
			{
				if (square.GetChessPiece() == null)	
				{
					return false;
				}
				else
				{
					if (square.GetChessPiece().GetPieceColor() == originalSquare.GetChessPiece().GetPieceColor()) 
						return false;
					else
					{
						validSquaresList.Add(square);
						return true;
					}
				}					
			}
			return false;
		}
	}
}
