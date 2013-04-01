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

namespace ChessByBird.ImagingProject
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
        /// AddIcon image
        /// </summary>
        /// <param name="filename"></param>
		public void AddIcon(string filename)
		{
			Image image;
			image = Image.FromFile(filename);
			WriteImage("MAINICON", image);
		}

        /// <summary>
        /// AddImages of white and black chess images
        /// </summary>
		public void AddImages()
		{
			Image image;

			image = Image.FromFile("./WhitePawn.gif");
			WriteImage("WhitePawn", image);

			image = Image.FromFile("./WhiteRook.gif");
			WriteImage("WhiteRook", image);

			image = Image.FromFile("./WhiteKnight.gif");
			WriteImage("WhiteKnight", image);

			image = Image.FromFile("./WhiteBishop.gif");
			WriteImage("WhiteBishop", image);

			image = Image.FromFile("./WhiteQueen.gif");
			WriteImage("WhiteQueen", image);

			image = Image.FromFile("./WhiteKing.gif");
			WriteImage("WhiteKing", image);

			image = Image.FromFile("./BlackPawn.gif");
			WriteImage("BlackPawn", image);

			image = Image.FromFile("./BlackRook.gif");
			WriteImage("BlackRook", image);

			image = Image.FromFile("./BlackKnight.gif");
			WriteImage("BlackKnight", image);

			image = Image.FromFile("./BlackBishop.gif");
			WriteImage("BlackBishop", image);

			image = Image.FromFile("./BlackQueen.gif");
			WriteImage("BlackQueen", image);

			image = Image.FromFile("./BlackKing.gif");
			WriteImage("BlackKing", image);
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

