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
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace ChessByBird.Imaging.Imager
{
    /// <summary>
    /// ChessHelper class
    /// </summary>
	public class ChessHelper
	{
        /// <summary>
        /// Constructor
        /// </summary>
		public ChessHelper() {}

        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
		private static bool Validate(int x, int y)
		{
			return ((x >= 0) && (x <= 7) && (y >= 0) && (y <= 7));
		}

        /// <summary>
        /// IncrementX
        /// </summary>
        /// <param name="aLocation"></param>
        /// <returns>bool</returns>
		public static bool IncrementX( ref Point aLocation )
		{
			if (Validate(aLocation.X + 1, aLocation.Y))
			{
				aLocation.X =  (aLocation.X + 1);
				return true;
			}
			else
				return false;
		}

        /// <summary>
        /// DecrementX
        /// </summary>
        /// <param name="aLocation"></param>
        /// <returns>bool</returns>
		public static bool DecrementX( ref Point aLocation )
		{
			if (Validate(aLocation.X - 1, aLocation.Y))
			{
				aLocation.X =  (aLocation.X - 1);
				return true;
			}
			else
				return false;
		}

        /// <summary>
        /// IncrementY
        /// </summary>
        /// <param name="aLocation"></param>
        /// <returns>bool</returns>
		public static bool IncrementY( ref Point aLocation )
		{
			if (Validate(aLocation.X , aLocation.Y + 1))
			{
				aLocation.Y = aLocation.Y + 1;
				return true;
			}
			else
				return false;
		}

        /// <summary>
        /// DecrementY
        /// </summary>
        /// <param name="aLocation"></param>
		public static bool DecrementY( ref Point aLocation )
		{
			if (Validate(aLocation.X , aLocation.Y - 1))
			{
				aLocation.Y = aLocation.Y - 1;
				return true;
			}
			else
				return false;
		}

        /// <summary>
        /// IncXDecY
        /// </summary>
        /// <param name="aLocation"></param>
        /// <returns>bool</returns>
		public static bool IncXDecY( ref Point aLocation )
		{
			if (Validate(aLocation.X + 1 , aLocation.Y - 1))
			{
				aLocation.X = aLocation.X + 1;
				aLocation.Y = aLocation.Y - 1;
				return true;
			}
			else
				return false;
		}

        /// <summary>
        /// DecXDecY
        /// </summary>
        /// <param name="aLocation"></param>
        /// <returns>bool</returns>
		public static bool DecXDecY( ref Point aLocation )
		{
			if (Validate(aLocation.X - 1 , aLocation.Y - 1))
			{
				aLocation.X = aLocation.X - 1;
				aLocation.Y = aLocation.Y - 1;
				return true;
			}
			else
				return false;
		}

        /// <summary>
        /// DecXIncY
        /// </summary>
        /// <param name="aLocation"></param>
        /// <returns>bool</returns>
		public static bool DecXIncY( ref Point aLocation )
		{
			if (Validate(aLocation.X - 1 , aLocation.Y + 1))
			{
				aLocation.X = aLocation.X- 1;
				aLocation.Y = aLocation.Y + 1;
				return true;
			}
			else
				return false;
		}

        /// <summary>
        /// IncXIncY
        /// </summary>
        /// <param name="aLocation"></param>
        /// <returns>bool</returns>
		public static bool IncXIncY( ref Point aLocation )
		{
			if (Validate(aLocation.X + 1 , aLocation.Y + 1))
			{
				aLocation.X = aLocation.X + 1;
				aLocation.Y = aLocation.Y + 1;
				return true;
			}
			else
				return false;
		}

		// UP

        /// <summary>
        /// KnightUpLeft
        /// </summary>
        /// <param name="aLocation"></param>
        /// <returns>bool</returns>
		public static bool KnightUpLeft( ref Point aLocation )
		{
			if (DecrementY( ref aLocation ) && DecrementY( ref aLocation ) && DecrementX( ref aLocation ))
				return true;
			else
				return false;
		}

        /// <summary>
        /// KnightUpRight
        /// </summary>
        /// <param name="aLocation"></param>
        /// <returns>bool</returns>
		public static bool KnightUpRight( ref Point aLocation )
		{
			if (DecrementY( ref aLocation ) && DecrementY( ref aLocation ) && IncrementX( ref aLocation ))
				return true;
			else
				return false;
		}

		// Down

        /// <summary>
        /// KnightDownLeft
        /// </summary>
        /// <param name="aLocation"></param>
        /// <returns>bool</returns>
		public static bool KnightDownLeft( ref Point aLocation )
		{
			if (IncrementY( ref aLocation ) && IncrementY( ref aLocation ) && DecrementX( ref aLocation ))
				return true;
			else
				return false;
		}

        /// <summary>
        /// KnightDownRight
        /// </summary>
        /// <param name="aLocation"></param>
        /// <returns>bool</returns>
		public static bool KnightDownRight( ref Point aLocation )
		{
			if (IncrementY( ref aLocation ) && IncrementY( ref aLocation ) && IncrementX( ref aLocation ))
				return true;
			else
				return false;
		}

		// Left

        /// <summary>
        /// KnightLeftUp
        /// </summary>
        /// <param name="aLocation"></param>
        /// <returns>bool</returns>
		public static bool KnightLeftUp( ref Point aLocation )
		{
			if (DecrementX( ref aLocation ) && DecrementX( ref aLocation ) && DecrementY( ref aLocation ))
				return true;
			else
				return false;
		}

        /// <summary>
        /// KnightLeftDown
        /// </summary>
        /// <param name="aLocation"></param>
        /// <returns>bool</returns>
		public static bool KnightLeftDown( ref Point aLocation )
		{
			if (DecrementX( ref aLocation ) && DecrementX( ref aLocation ) && IncrementY( ref aLocation ))
				return true;
			else
				return false;
		}

		// Right

        /// <summary>
        /// KnightRightUp
        /// </summary>
        /// <param name="aLocation"></param>
        /// <returns>bool</returns>
		public static bool KnightRightUp( ref Point aLocation )
		{
			if (IncrementX( ref aLocation ) && IncrementX( ref aLocation ) && DecrementY( ref aLocation ))
				return true;
			else
				return false;
		}

        /// <summary>
        /// KnightRightDown
        /// </summary>
        /// <param name="aLocation"></param>
        /// <returns>bool</returns>
		public static bool KnightRightDown( ref Point aLocation )
		{
			if (IncrementX( ref aLocation ) && IncrementX( ref aLocation ) && IncrementY( ref aLocation ))
				return true;
			else
				return false;
		}
	}
}
