/********************************************
 *  Penn State University Software Engineering Graduate Program
 *  Authors: Team 1: Zachary Carson, Aaron Eugene, Steve Haggerty, Joseph Oakes
 *  Date: Spring 2013
 *  Course: SWENG 500 Software Engineering Studio
 *  Professor: Mohamad Kassab
 *  Project: Chess By Bird Capstone group project
*********************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessByBird.ClassLibraryProject
{
    public class Board
    {
        // Properties
        private bool BlackCheck;
        private bool WhiteCheck;
        private Array[] Squares;

        //TODO: Finish Constructor
        public Board() { }

        public bool movePiece(int sourceColumn, int sourceRow, int DestinColumn, int DestinRow)
        {
            return true;
        }

        public bool validateMove(int sourceColumn, int sourceRow, int DestinColumn, int DestinRow, String FEN)
        {
            return true;
        }





    }
}
