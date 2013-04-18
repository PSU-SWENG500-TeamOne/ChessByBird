/*******************************************************************************
 *  Penn State University Software Engineering Graduate Program
 *  Authors: Team 1: Zachary Carson, Aaron Eugene, Steve Haggerty, Joseph Oakes
 *  Date: Spring 2013
 *  Course: SWENG 500 Software Engineering Studio
 *  Professor: Mohamad Kassab
 *  Project: Chess By Bird Capstone group project
*******************************************************************************/

using System.Drawing;

namespace ChessByBird.ImageClient
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
        /// <param name="squareHighlight"></param>
        /// <param name="squareLastMove"></param>
		internal virtual void Draw(Graphics g, int x, int y, string title, bool squareHighlight, bool squareLastMove)	
		{
            g.FillRectangle(brush, x, y, ChessImageConstants.SquareSize, ChessImageConstants.SquareSize);

			// HighLighting
			Pen pen;
			Pen lastPenMove;

			if (squareLastMove)
				lastPenMove = new Pen(ChessImageConstants.LastMoveColor, ChessImageConstants.HighlightPenSize);
			else
                lastPenMove = new Pen(Color.Transparent, ChessImageConstants.HighlightPenSize);
		
			if (squareHighlight)
                pen = new Pen(ChessImageConstants.HighlightPenColor, ChessImageConstants.HighlightPenSize);
			else
				pen = new Pen(Color.Transparent, ChessImageConstants.HighlightPenSize);

			try
			{
				// Draw the last move
				g.DrawRectangle(lastPenMove, 
					x + 10 + (ChessImageConstants.HighlightPenSize / 2), 
					y + 10 + ChessImageConstants.HighlightPenSize / 2, 
					ChessImageConstants.SquareSize - ChessImageConstants.HighlightPenSize - 20, 
					ChessImageConstants.SquareSize - ChessImageConstants.HighlightPenSize - 20 );

				// Draw highlighted border around it
				g.DrawRectangle(pen, 
					x + 20 + (ChessImageConstants.HighlightPenSize / 2), 
					y + 20 + ChessImageConstants.HighlightPenSize / 2, 
					ChessImageConstants.SquareSize - ChessImageConstants.HighlightPenSize - 40, 
					ChessImageConstants.SquareSize - ChessImageConstants.HighlightPenSize - 40 );
			}
			finally
			{
				pen.Dispose();
				lastPenMove.Dispose();
			}
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

