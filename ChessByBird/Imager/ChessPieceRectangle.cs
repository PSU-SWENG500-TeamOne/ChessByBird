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
    /// ChessPieceRectangle class
    /// </summary>
    public class ChessPieceRectangle
	{
        /// <summary>
        /// Class variables
        /// </summary>
        protected Image image = null;

        /// <summary>
        /// Destructor
        /// </summary>
        ~ChessPieceRectangle()
		{
			if (image != null)
				image.Dispose();
		}

        // Override Draw method
		public virtual void Draw(Graphics g, Point aLocation)
		{
            g.DrawImage(image, aLocation.X, aLocation.Y, 
						ChessImageConstants.ChessPieceSize, 
						ChessImageConstants.ChessPieceSize);
		}

        /// <summary>
        /// ReadImage given name
        /// </summary>
        /// <param name="anImageName"></param>
        /// <returns>Image</returns>
		protected Image ReadImage(string anImageName)
		{
			Image image;

            ChessResourceReader chessResourceReader = new ChessResourceReader();
			try
			{
                image = chessResourceReader.ReadImage(anImageName);
			}
			finally
			{
                chessResourceReader.Close();
			}
			return image;
		}
	}

    /// <summary>
    /// PawnRectangle class
    /// </summary>
	public class PawnRectangle : ChessPieceRectangle
	{
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="aPieceColor"></param>
        public PawnRectangle(EnumPieceColor aPieceColor) 
		{
            if (aPieceColor == EnumPieceColor.White) 
				image = ReadImage("WHITEPAWN");
			else
				image = ReadImage("BLACKPAWN");
		}
	}

    /// <summary>
    /// RookRectangle class
    /// </summary>
	public class RookRectangle : ChessPieceRectangle
	{
        /// <summary>
        /// Constructor
        /// </summary>
        public RookRectangle(EnumPieceColor aPieceColor)
		{
            if (aPieceColor == EnumPieceColor.White) 
				image = ReadImage("WHITEROOK");
			else
				image = ReadImage("BLACKROOK");
		}
	}

    /// <summary>
    /// BishopRectangle class
    /// </summary>
	public class BishopRectangle : ChessPieceRectangle
	{
        /// <summary>
        /// Constructor
        /// </summary>
        public BishopRectangle(EnumPieceColor aPieceColor)
		{
            if (aPieceColor == EnumPieceColor.White) 
				image = ReadImage("WHITEBISHOP");
			else
				image = ReadImage("BLACKBISHOP");
		}
	}

    /// <summary>
    /// KnightRectangle class
    /// </summary>
	public class KnightRectangle : ChessPieceRectangle
	{
        /// <summary>
        /// Constructor
        /// </summary>
        public KnightRectangle(EnumPieceColor aPieceColor)
		{
            if (aPieceColor == EnumPieceColor.White) 
				image = ReadImage("WHITEKNIGHT");
			else
				image = ReadImage("BLACKKNIGHT");
		}
	}

    /// <summary>
    /// QueenRectangle class
    /// </summary>
	public class QueenRectangle : ChessPieceRectangle
	{
        /// <summary>
        /// Constructor
        /// </summary>
        public QueenRectangle(EnumPieceColor aPieceColor)
		{
            if (aPieceColor == EnumPieceColor.White) 
				image = ReadImage("WHITEQUEEN");
			else
				image = ReadImage("BLACKQUEEN");
		}
	}

    /// <summary>
    /// KingRectangle class
    /// </summary>
    public class KingRectangle : ChessPieceRectangle
	{
        /// <summary>
        /// Constructor
        /// </summary>
        public KingRectangle(EnumPieceColor aPieceColor)
		{
            if (aPieceColor == EnumPieceColor.White)
                image = ReadImage("WHITEKING");
			else
                image = ReadImage("BLACKKING");
		}
	}

}

