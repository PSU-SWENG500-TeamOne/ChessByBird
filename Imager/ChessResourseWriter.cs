/*******************************************************************************
 *  Penn State University Software Engineering Graduate Program
 *  Authors: Team 1: Zachary Carson, Aaron Eugene, Steve Haggerty, Joseph Oakes
 *  Date: Spring 2013
 *  Course: SWENG 500 Software Engineering Studio
 *  Professor: Mohamad Kassab
 *  Project: Chess By Bird Capstone group project
*******************************************************************************/

using System;
using System.Collections;
using System.Drawing;
using System.Resources;

namespace ChessByBird.Imaging.Imager
{
    /// <summary>
    /// ChessResourseWriter class
    /// </summary>
	public class ChessResourseWriter 
	{
        /// <summary>
        /// Class variables
        /// </summary>
		private IResourceWriter writer;

        /// <summary>
        /// ChessResourseWriterconstructor
        /// </summary>
		public ChessResourseWriter()
		{
			writer = new ResourceWriter("Chess.resources"); // Chess Pieces
		}

        /// <summary>
        /// Close writer
        /// </summary>
		public void Close()
		{
			writer.Close();
		}

        /// <summary>
        /// WriteImage given its name and value
        /// </summary>
        /// <param name="aName"></param>
        /// <param name="aImage"></param>
		public void WriteImage(string aName, Image aImage)
		{
			writer.AddResource(aName, aImage);
		}

        /// <summary>
        /// AddIcon theImage
        /// </summary>
        /// <param name="filename"></param>
		public void AddIcon(string filename)
		{
			Image theImage;
			theImage = Image.FromFile(filename);
			WriteImage("MAINICON", theImage);
		}

        /// <summary>
        /// AddImages of white and black chess images
        /// </summary>
		public void AddImages()
		{
			Image theImage;

			theImage = Image.FromFile("./WhitePawn.gif");
			WriteImage("WhitePawn", theImage);

			theImage = Image.FromFile("./WhiteRook.gif");
			WriteImage("WhiteRook", theImage);

			theImage = Image.FromFile("./WhiteKnight.gif");
			WriteImage("WhiteKnight", theImage);

			theImage = Image.FromFile("./WhiteBishop.gif");
			WriteImage("WhiteBishop", theImage);

			theImage = Image.FromFile("./WhiteQueen.gif");
			WriteImage("WhiteQueen", theImage);

			theImage = Image.FromFile("./WhiteKing.gif");
			WriteImage("WhiteKing", theImage);

			theImage = Image.FromFile("./BlackPawn.gif");
			WriteImage("BlackPawn", theImage);

			theImage = Image.FromFile("./BlackRook.gif");
			WriteImage("BlackRook", theImage);

			theImage = Image.FromFile("./BlackKnight.gif");
			WriteImage("BlackKnight", theImage);

			theImage = Image.FromFile("./BlackBishop.gif");
			WriteImage("BlackBishop", theImage);

			theImage = Image.FromFile("./BlackQueen.gif");
			WriteImage("BlackQueen", theImage);

			theImage = Image.FromFile("./BlackKing.gif");
			WriteImage("BlackKing", theImage);
		}
	}

    /// <summary>
    /// ChessResourceReader class
    /// </summary>
	public class ChessResourceReader
	{
        /// <summary>
        /// Class variables
        /// </summary>
		private IResourceReader reader;

        /// <summary>
        /// ChessResourceReader constructor
        /// </summary>
		public ChessResourceReader()
		{
            // relative to bin\debug or bin\release
			reader = new ResourceReader(@"..\..\Images\Chess.resources");
		}

        /// <summary>
        /// Close reader
        /// </summary>
		public void Close()
		{
			reader.Close();
		}

        /// <summary>
        /// ReadImage given its name
        /// </summary>
        /// <param name="aName"></param>
        /// <returns>Image</returns>
		public Image ReadImage(String aName)
		{
			IDictionaryEnumerator id = reader.GetEnumerator(); 
			while(id.MoveNext())
			{
				if (id.Key.ToString() == aName)
					return (Image) id.Value;
			}
			return null;
		}

	}
}

