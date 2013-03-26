/*******************************************************************************
 *  Penn State University Software Engineering Graduate Program
 *  Authors: Team 1: Zachary Carson, Aaron Eugene, Steve Haggerty, Joseph Oakes
 *  Date: Spring 2013
 *  Course: SWENG 500 Software Engineering Studio
 *  Professor: Mohamad Kassab
 *  Project: Chess By Bird Capstone group project
*******************************************************************************/

using System.Drawing;

namespace ChessByBird.Imaging.Imager
{
    public class ChessPiece
    {
        /// <summary>
        /// Class Variables
        /// </summary>
        private EnumPieceColor chessPieceColor;
		private EnumPieceType chessPieceType;
        private EnumPieceID chessPieceID;
        
        private Point location;
        private ChessSquare chessSquare;

        private bool isCastlingPossible;
		private bool isEnabled;

        /// <summary>
        /// ChessPiece Constructor
        /// </summary>
        /// <param name="aChessPieceID"></param>
        internal ChessPiece(EnumPieceID aChessPieceID, ChessSquare aChessSquare)
        {
            chessSquare = aChessSquare;

            if (aChessPieceID == EnumPieceID.BlackKing)
            {
                chessPieceType = EnumPieceType.King;
                chessPieceColor = EnumPieceColor.Black;
            }
            else if (aChessPieceID == EnumPieceID.WhiteKing)
            {
                chessPieceType = EnumPieceType.King;
                chessPieceColor = EnumPieceColor.White;
            }

            chessPieceID = aChessPieceID;

            isCastlingPossible = ((chessPieceType == EnumPieceType.King) || ((chessPieceType == EnumPieceType.Rook)));

            isEnabled = false;
        }

        /// <summary>
        /// ChessPiece Constructor
        /// </summary>
        /// <param name="aPieceColor"></param>
        /// <param name="aPieceType"></param>
        /// <param name="aChessSquare"></param>
        internal ChessPiece(EnumPieceColor aPieceColor, EnumPieceType aPieceType, ChessSquare aChessSquare)	
		{
            chessPieceColor = aPieceColor;
            chessPieceType = aPieceType;
            chessPieceID = (EnumPieceID)((int)chessPieceColor + (int)chessPieceType);

            chessSquare = aChessSquare;
            EnumSquareID sid = chessSquare.GetSquareID();
            ChessImageConstants.parserChessBoardSquares[sid] = chessPieceID;

            isCastlingPossible = ((aPieceType == EnumPieceType.King) || ((aPieceType == EnumPieceType.Rook)));
			isEnabled = true;  // TODO was false
		}

        /// <summary>
        /// GetIsEnabled
        /// </summary>
        /// <returns>bool</returns>
		internal bool GetIsEnabled()
		{
			return isEnabled;
		}

        /// <summary>
        /// SetIsEnabled
        /// </summary>
        /// <param name="aEnable"></param>
		internal void SetIsEnabled(bool aEnable) 
		{
			isEnabled = aEnable;
		}

        /// <summary>
        /// IsCastlingPossible
        /// </summary>
        /// <returns>bool</returns>
		internal bool IsCastlingPossible()
		{
            return isCastlingPossible;
		}

        /// <summary>
        /// SetCastlePossibility
        /// </summary>
        /// <param name="aIsCastlePossible"></param>
        internal void SetCastlePossibility(bool aIsCastlingPossible)
		{
            isCastlingPossible = aIsCastlingPossible;
		}

        /// <summary>
        /// GetPieceType
        /// </summary>
        /// <returns>EnumPieceType</returns>
		internal EnumPieceType GetPieceType()
		{
			return chessPieceType;		
		}

        /// <summary>
        /// SetPieceType
        /// </summary>
        /// <param name="aChessPieceType"></param>
        internal void SetPieceType(EnumPieceType aChessPieceType)
		{
            chessPieceType = aChessPieceType;
		}		

        /// <summary>
        /// GetPieceColor
        /// </summary>
        /// <returns>EnumPieceColor</returns>
		internal EnumPieceColor GetPieceColor()
		{
			return chessPieceColor;
		}

        /// <summary>
        /// SetPieceColor
        /// </summary>
        /// <param name="aChessPieceColor"></param>
		internal void SetPieceColor(EnumPieceColor aChessPieceColor)
		{
            chessPieceColor = aChessPieceColor;
		}

        /// <summary>
        /// GetChessSquare
        /// </summary>
        /// <returns>ChessSquare</returns>
		internal ChessSquare GetChessSquare()
		{
			return chessSquare;
		}

        /// <summary>
        /// SetChessSquare
        /// </summary>
        /// <param name="aChessSquare"></param>
        internal void SetChessSquare(ChessSquare aChessSquare)
		{
            chessSquare = aChessSquare;
		}

        /// <summary>
        /// GetStartLocation
        /// </summary>
        /// <returns>Point</returns>
		internal Point GetStartLocation()
		{
			return location;
		}

        /// <summary>
        /// SetStartLocation
        /// </summary>
        /// <param name="aLocation"></param>
        internal void SetStartLocation(Point aLocation)
		{
            location.X = aLocation.X;
            location.Y = aLocation.Y;
		}

        /// <summary>
        /// IsContains
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>bool</returns>
		internal bool IsContains(int x, int y)	
		{
            return ((x > location.X) && (x < location.X + ChessImageConstants.ChessPieceSize) &&
                    (y > location.Y) && (y < location.Y + ChessImageConstants.ChessPieceSize));
		}

        /// <summary>
        /// Draw Method
        /// </summary>
        /// <param name="g"></param>
        /// <param name="aChessPieceFactory"></param>
		internal void Draw(Graphics g, ChessPieceFactory aChessPieceFactory) 
		{
            ChessPieceRectangle chessPieceRectangle = aChessPieceFactory.GetChessPieceRectangle(chessPieceType, chessPieceColor);
            if (chessPieceRectangle != null)
            {                
                location.X = this.GetStartLocation().X;
                location.Y = this.GetStartLocation().Y;
                chessPieceRectangle.Draw(g, location);
            }
		}
	}
}
