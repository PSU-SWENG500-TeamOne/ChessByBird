/*******************************************************************************
 *  Penn State University Software Engineering Graduate Program
 *  Authors: Team 1: Zachary Carson, Aaron Eugene, Steve Haggerty, Joseph Oakes
 *  Date: Spring 2013
 *  Course: SWENG 500 Software Engineering Studio
 *  Professor: Mohamad Kassab
 *  Project: Chess By Bird Capstone group project
*******************************************************************************/

using System;

/**
 * References:
 * 
 * http://www.c-sharpcorner.com/UploadFile/kaushalgol/ChessProgram11152005054904AM/ChessProgram.aspx
 * 
 */

namespace ChessByBird.Imaging.Imager
{
    /// <summary>
    /// ChessPieceFactory class
    /// </summary>
	public class ChessPieceFactory
	{
        /// <summary>
        /// Class variables
        /// </summary>
        ChessPieceRectangle blackPawnRectangle, blackRookRectangle, blackKnightRectangle, blackBishopRectangle, blackQueenRectangle, blackKingRectangle,
                            whitePawnRectangle, whiteRookRectangle, whiteKnightRectangle, whiteBishopRectangle, whiteQueenRectangle, whiteKingRectangle;

        /// <summary>
        /// ChessPieceFactory constructor
        /// </summary>
		public ChessPieceFactory()
		{
			whitePawnRectangle = new PawnRectangle(EnumPieceColor.White);
            blackPawnRectangle = new PawnRectangle(EnumPieceColor.Black);
			// Rook
            whiteRookRectangle = new RookRectangle(EnumPieceColor.White);
            blackRookRectangle = new RookRectangle(EnumPieceColor.Black);
			// Knight
            whiteKnightRectangle = new KnightRectangle(EnumPieceColor.White);
            blackKnightRectangle = new KnightRectangle(EnumPieceColor.Black);
			// Bishop
            whiteBishopRectangle = new BishopRectangle(EnumPieceColor.White);
            blackBishopRectangle = new BishopRectangle(EnumPieceColor.Black);
			// Queen
            whiteQueenRectangle = new QueenRectangle(EnumPieceColor.White);
			blackQueenRectangle = new QueenRectangle(EnumPieceColor.Black);
			// King
            blackKingRectangle = new KingRectangle(EnumPieceColor.Black);
            whiteKingRectangle = new KingRectangle(EnumPieceColor.White);
		}

        /// <summary>
        /// GetChessPieceRectangle by type and color 
        /// </summary>
        /// <param name="aPieceType"></param>
        /// <param name="aPieceColor"></param>
        /// <returns>ChessPieceRectangle</returns>
		public ChessPieceRectangle GetChessPieceRectangle(EnumPieceType aPieceType, EnumPieceColor aPieceColor)
		{
			switch(aPieceType)       
			{         
				case EnumPieceType.Pawn:   
					 if (aPieceColor == EnumPieceColor.White)
                         return whitePawnRectangle;
					else
                         return blackPawnRectangle;
					
				case EnumPieceType.Rook:            
					if (aPieceColor == EnumPieceColor.White)
                        return whiteRookRectangle;
					else
                        return blackRookRectangle;

				case EnumPieceType.Knight:            
					if (aPieceColor == EnumPieceColor.White)
                        return whiteKnightRectangle;
					else
						return blackKnightRectangle;

				case EnumPieceType.Bishop:            
					if (aPieceColor == EnumPieceColor.White)
                        return whiteBishopRectangle;
					else
                        return blackBishopRectangle;

				case EnumPieceType.Queen:            
					if (aPieceColor == EnumPieceColor.White)
                        return whiteQueenRectangle;
					else
                        return blackQueenRectangle;

				case EnumPieceType.King:   
					if (aPieceColor == EnumPieceColor.White)
                        return whiteKingRectangle;
					else
						return blackKingRectangle;

                case EnumPieceType.None:
                    return null;
			}

			throw( new Exception("ChessPieceFactory.GetChessPieceRectangle : Unknown EnumPieceType") );
		}

	}
}

