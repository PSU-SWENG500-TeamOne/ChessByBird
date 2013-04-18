/*******************************************************************************
 *  Penn State University Software Engineering Graduate ImagerProgram
 *  Authors: Team 1: Zachary Carson, Aaron Eugene, Steve Haggerty, Joseph Oakes
 *  Date: Spring 2013
 *  Course: SWENG 500 Software Engineering Studio
 *  Professor: Mohamad Kassab
 *  Project: Chess By Bird Capstone group project
*******************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessByBird.ImagingProject
{
    /// <summary>
    /// ChessLocationCalculatorFactory class
    /// </summary>
	internal class ChessLocationCalculatorFactory
	{
        /// <summary>
        /// Class variables
        /// </summary>
        private ChessLocationCalculatorPawn pawnCalculator;
        private ChessLocationCalculatorRook rookCalculator;
        private ChessLocationCalculatorKnight knightCalculator;
        private ChessLocationCalculatorBishop bishopCalculator;
        private ChessLocationCalculatorQueen queenCalculator;
        private ChessLocationCalculatorKing kingCalculator;

		private ChessBoard chessBoard;
		
        /// <summary>
        /// ChessLocationCalculatorFactory constructor
        /// </summary>
        /// <param name="aChessBoard"></param>
		public ChessLocationCalculatorFactory(ChessBoard aChessBoard)
		{
            chessBoard = aChessBoard;
		}

        /// <summary>
        /// GetLocationCalculator
        /// </summary>
        /// <param name="chessPieceType"></param>
        /// <param name="aChessPlayer"></param>
        /// <returns>ChessLocationCalculator</returns>
		internal ChessLocationCalculator GetLocationCalculator(EnumPieceType chessPieceType, ChessPlayer aChessPlayer)
		{
			switch(chessPieceType)       
			{         
				case EnumPieceType.Pawn:   
				{
					if (pawnCalculator == null)
						pawnCalculator = new ChessLocationCalculatorPawn(chessBoard);

					pawnCalculator.SetCurrentPlayer(aChessPlayer);

					return pawnCalculator;
				}
				case EnumPieceType.Rook:            
				{
					if (rookCalculator == null)
						rookCalculator = new ChessLocationCalculatorRook(chessBoard);

					return rookCalculator;
				}
				case EnumPieceType.Knight:            
				{
					if (knightCalculator == null)
						knightCalculator = new ChessLocationCalculatorKnight(chessBoard);

					return knightCalculator;
				}
				case EnumPieceType.Bishop:            
				{
					if (bishopCalculator == null)
						bishopCalculator = new ChessLocationCalculatorBishop(chessBoard);

					return bishopCalculator;
				}
				case EnumPieceType.Queen:            
				{
					if (queenCalculator == null)
						queenCalculator = new ChessLocationCalculatorQueen(chessBoard);

					return queenCalculator;
				}
				case EnumPieceType.King:   
				{
					if (kingCalculator == null)
						kingCalculator = new ChessLocationCalculatorKing(chessBoard);

					return kingCalculator;
				}
			}
            throw (new Exception("LocationCalculatorFactory.GetLocationCalculator : Invalid Chess Piece Type"));
		}
	}
}
