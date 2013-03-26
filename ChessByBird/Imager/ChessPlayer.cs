/*******************************************************************************
 *  Penn State University Software Engineering Graduate Program
 *  Authors: Team 1: Zachary Carson, Aaron Eugene, Steve Haggerty, Joseph Oakes
 *  Date: Spring 2013
 *  Course: SWENG 500 Software Engineering Studio
 *  Professor: Mohamad Kassab
 *  Project: Chess By Bird Capstone group project
*******************************************************************************/

using System.Collections;

namespace ChessByBird.Imager
{
	public class ChessPlayer
	{
        /// <summary>
        /// Class Variables
        /// </summary>
		private string name;
        private bool isTurn;
		private EnumPlayerType playerType;
		private EnumPieceColor pieceColor;
		private ArrayList pieceList;
        private bool isCheck;

        /// <summary>
        /// Construct a Chess Player
        /// </summary>
        /// <param name="aType"></param>
        /// <param name="aName"></param>
        /// <param name="aColor"></param>
        public ChessPlayer(EnumPlayerType aType, string aName, EnumPieceColor aColor)
		{
			isTurn = false;
			playerType = aType;
			name = aName;
			pieceColor = aColor;
            isCheck = false;
		}

        /// <summary>
        /// GetCheckStatus Accessor
        /// </summary>
        /// <returns>bool</returns>
        internal bool GetCheckStatus()
        {
            return isCheck;
        }

        /// <summary>
        /// SetCheckStatus Accessor
        /// </summary>
        /// <param name="aIsCheck"></param>
        internal void SetCheckStatus(bool aIsCheck)
        {
            isCheck = aIsCheck;
        }

        /// <summary>
        /// SetPieceList Accessor
        /// </summary>
        /// <param name="aPieceList"></param>
		internal void SetPieceList (ArrayList aPieceList)
		{
			pieceList = aPieceList;
		}

        /// <summary>
        /// GetPieceList Accessor
        /// </summary>
        /// <returns></returns>
		internal ArrayList GetPieceList()
		{
			return pieceList;
		}

        /// <summary>
        /// GetName Accessor
        /// </summary>
        /// <returns>string</returns>
		internal string GetName()
		{
			return name;
		}

        /// <summary>
        /// SetName Accessor
        /// </summary>
        /// <param name="aName"></param>
		internal void SetName(string aName)
		{
			name = aName;
		}

        /// <summary>
        /// GetTurn Accessor
        /// </summary>
        /// <returns>bool</returns>
		internal bool GetTurn()
		{
			return isTurn;
		}

        /// <summary>
        /// SetTurn Accessor
        /// </summary>
        /// <param name="aTurn"></param>
		internal void SetTurn(bool aTurn)
		{
			isTurn = aTurn;
		}

        /// <summary>
        /// GetPlayerType Accessor
        /// </summary>
        /// <returns>EnumPlayerType</returns>
		internal EnumPlayerType GetPlayerType()
		{
			return playerType;
		}

        /// <summary>
        /// GetPieceColor Accessor
        /// </summary>
        /// <returns>EnumSquareColor</returns>
		internal EnumPieceColor GetPieceColor()
		{
			return pieceColor;
		}
	}
}
