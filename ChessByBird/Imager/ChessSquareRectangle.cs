/*******************************************************************************
 *  Penn State University Software Engineering Graduate ImagerProgram
 *  Authors: Team 1: Zachary Carson, Aaron Eugene, Steve Haggerty, Joseph Oakes
 *  Date: Spring 2013
 *  Course: SWENG 500 Software Engineering Studio
 *  Professor: Mohamad Kassab
 *  Project: Chess By Bird Capstone group project
*******************************************************************************/

using System.Drawing;

namespace ChessByBird.ImagingProject
{
    /// <summary>
    /// ChessSquareRectangle class
    /// </summary>
    public class ChessSquareRectangle
    {
        /// <summary>
        /// Class variables
        /// </summary>
        protected Color squareColor;
        protected Brush brush;

        /// <summary>
        /// ChessSquareRectangle Default Constructor
        /// </summary>
        public ChessSquareRectangle() { }

        /// <summary>
        /// Destructor
        /// </summary>
        ~ChessSquareRectangle()
        {
            if (brush != null)
                brush.Dispose();
        }

        /// <summary>
        /// Draw method
        /// </summary>
        /// <param name="g"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="title"></param>
        internal virtual void Draw(Graphics g, int x, int y, string title)
        {
            g.FillRectangle(brush, x, y, ChessImageConstants.SquareSize, ChessImageConstants.SquareSize);
        }
    }

    /// <summary>
    /// BlackRectangle class
    /// </summary>
    public class BlackRectangle : ChessSquareRectangle
    {
        public BlackRectangle()
        {
            squareColor = ChessImageConstants.BlackSquareColor;
            brush = ChessImageConstants.GetBlackSquareBrush();
        }
    }

    /// <summary>
    /// WhiteRectangle class
    /// </summary>
    public class WhiteRectangle : ChessSquareRectangle
    {
        internal WhiteRectangle()
        {
            squareColor = ChessImageConstants.WhiteSquareColor;
            brush = ChessImageConstants.GetWhiteSquareBrush();
        }
    }
}

