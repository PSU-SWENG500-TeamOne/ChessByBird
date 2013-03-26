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

namespace ChessByBird.Imaging.Imager
{
    /// <summary>
    /// ChessSquareFactory class
    /// </summary>
	public class ChessSquareFactory 
	{
        /// <summary>
        /// Class variables
        /// </summary>
		ChessSquareRectangle blackSquareRectangle;
        ChessSquareRectangle whiteSquareRectangle;
		
        /// <summary>
        /// ChessSquareFactory produces white and black rectangles
        /// </summary>
		public ChessSquareFactory()	
		{
            whiteSquareRectangle = new WhiteRectangle();
			blackSquareRectangle = new BlackRectangle();
		}

        /// <summary>
        /// GetSquareRectangle
        /// </summary>
        /// <param name="squareColor"></param>
        /// <returns>ChessSquareRectangle</returns>
        public ChessSquareRectangle GetSquareRectangle(EnumSquareColor squareColor)
		{
			switch (squareColor)
			{
				case EnumSquareColor.White:
						return whiteSquareRectangle;
				case EnumSquareColor.Black:
						return blackSquareRectangle;
				default:
                        throw (new Exception(
                            "SquareFactory.GetSquareRectangle : Unknown EnumSquareColor"));						
			}
		}
	}
}
