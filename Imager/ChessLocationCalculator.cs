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

namespace ChessByBird.Imaging.Imager
{
    /// <summary>
    /// ChessLocationCalculator class
    /// </summary>
	internal class ChessLocationCalculator 
	{
        /// <summary>
        /// Class variables
        /// </summary>
		protected ArrayList validSquaresList;
		protected ChessBoard chessBoard;
		protected ChessSquare originalSquare;

        /// <summary>
        /// ChessLocationCalculator Constructor
        /// </summary>
        /// <param name="aChessboard"></param>
        public ChessLocationCalculator(ChessBoard aChessboard)
		{
			chessBoard = aChessboard;
			validSquaresList = new ArrayList();
		}

        /// <summary>
        /// ClearValidSquaresList
        /// </summary>
		protected void ClearValidSquaresList()
		{
			validSquaresList.Clear();
		}

        /// <summary>
        /// ProcessSquare
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>bool</returns>
		protected bool ProcessSquare(int x, int y)
		{
			ChessSquare aSquare = chessBoard.GetSquareByItsLocation(new Point(x, y));
			if (aSquare != null) 
			{
				if (aSquare.GetChessPiece() == null)	
				{
					validSquaresList.Add(aSquare);
					return true;
				}
				else if (aSquare.GetChessPiece().GetPieceColor() == originalSquare.GetChessPiece().GetPieceColor()) 
				{
					return false;
				}
				else
				{
					validSquaresList.Add(aSquare);
					return false;
				}
			}
			return false;
		}

        /// <summary>
        /// ProcessSquareInclusive
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>bool</returns>
		protected bool ProcessSquareInclusive(int x, int y)
		{
			ChessSquare aSquare = chessBoard.GetSquareByItsLocation(new Point(x, y));
			if (aSquare != null) 
			{
				if (aSquare.GetChessPiece() == null)	
				{
					validSquaresList.Add(aSquare);
					return true;
				}
				else 
				{
					validSquaresList.Add(aSquare);
					return false;
				}
			}
			return false;
		}
		
        /// <summary>
        /// CalculateLocations
        /// </summary>
        /// <param name="aSquare"></param>
        /// <param name="isSupportPosition"></param>
        /// <returns>ArrayList</returns>
		internal virtual ArrayList CalculateLocations(ChessSquare aSquare, bool isSupportPosition)
		{
			ClearValidSquaresList();
            originalSquare = aSquare; // Preserve original square

			return null;
		}

	}
}
