/*******************************************************************************
 *  Penn State University Software Engineering Graduate Program
 *  Authors: Team 1: Zachary Carson, Aaron Eugene, Steve Haggerty, Joseph Oakes
 *  Date: Spring 2013
 *  Course: SWENG 500 Software Engineering Studio
 *  Professor: Mohamad Kassab
 *  Project: Chess By Bird Capstone group project
*******************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessByBird.Imager
{
    /// <summary>
    ///  ChessSquareLocator class
    /// </summary>
	public class ChessSquareLocator
	{
		/// <summary>
		/// Class variables
		/// </summary>
		private int x;
        private int y;
        private int counter;
		private bool newline;
		private byte row;
        private byte column;
	
        /// <summary>
        /// CLass Constructor
        /// </summary>
		public ChessSquareLocator() 
		{
			Reset();
		}

        /// <summary>
        ///  Reset Starting Location
        /// </summary>
		internal void Reset()	
		{
            x = ChessImageConstants.ChessBoardLeft;
            y = ChessImageConstants.ChessBoardTop;
			counter = 0;
			newline = true;
			row = 0;
			column = 0;
		}

        /// <summary>
        /// Next X Row
        /// </summary>
        /// <returns>int</returns>
		public int NextX()	
		{
			return x;
		}

        /// <summary>
        /// Next Y column
        /// </summary>
        /// <returns>int</returns>
		public int NextY()	
		{
			return y;
		}
		
        /// <summary>
        /// Increment location
        /// </summary>
		public void Increment()	
		{
			int remainder;
			int quotient;
			
			counter++;

			// This will decide new line or not.
			quotient = Math.DivRem(counter, ChessImageConstants.SquaresPerRow, out remainder);

			column = (byte) remainder;

			if (remainder == 0) 
			{
				// For a new line, you increment Y and reset X
                x = ChessImageConstants.ChessBoardLeft;
				y += ChessImageConstants.SquareSize;
				newline = true;
				row++;
			}
			else 
			{
				// If you are on the same line then Increment X 
				x += ChessImageConstants.SquareSize;
				newline = false;
			}
		}

        /// <summary>
        /// IsNewLine method
        /// </summary>
        /// <returns></returns>
		public bool IsNewLine()
		{
			return newline;
		}

        /// <summary>
        /// GetLocation method
        /// </summary>
        /// <returns>new Point</returns>
		public Point GetLocation()
		{
			return new Point(column, row);
		}

	}
}
