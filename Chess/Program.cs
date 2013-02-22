using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessProject.Engine;

namespace ChessByBird.ChessProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
    //    [STAThread]
          
        static void Main(string[] args)
        {

            System.Console.WriteLine("DRIVER for ChessImplementation");
            Engine engine = new Engine();
            Game game = new Game();
            
            Board newboard = engine.ChessBoard;
            
            System.Console.ReadKey();
           
        }

        private static string Fen(bool boardOnly, Board board)
        {
            string output = String.Empty;
            byte blankSquares = 0;

            for (byte x = 0; x < 64; x++)
            {
                byte index = x;

                if (board.Squares[index].Piece != null)
                {
                    if (blankSquares > 0)
                    {
                        output += blankSquares.ToString();
                        blankSquares = 0;
                    }

                    if (board.Squares[index].Piece.PieceColor == ChessPieceColor.Black)
                    {
                        output += Piece.GetPieceTypeShort(board.Squares[index].Piece.PieceType).ToLower();
                    }
                    else
                    {
                        output += Piece.GetPieceTypeShort(board.Squares[index].Piece.PieceType);
                    }
                }
                else
                {
                    blankSquares++;
                }

                if (x % 8 == 7)
                {
                    if (blankSquares > 0)
                    {
                        output += blankSquares.ToString();
                        output += "/";
                        blankSquares = 0;
                    }
                    else
                    {
                        if (x > 0 && x != 63)
                        {
                            output += "/";
                        }
                    }
                }
            }

            if (board.WhoseMove == ChessPieceColor.White)
            {
                output += " w ";
            }
            else
            {
                output += " b ";
            }

            string spacer = "";

            if (board.WhiteCastled == false)
            {
                if (board.Squares[60].Piece != null)
                {
                    if (board.Squares[60].Piece.Moved == false)
                    {
                        if (board.Squares[63].Piece != null)
                        {
                            if (board.Squares[63].Piece.Moved == false)
                            {
                                output += "K";
                                spacer = " ";
                            }
                        }
                        if (board.Squares[56].Piece != null)
                        {
                            if (board.Squares[56].Piece.Moved == false)
                            {
                                output += "Q";
                                spacer = " ";
                            }
                        }
                    }
                }
            }

            if (board.BlackCastled == false)
            {
                if (board.Squares[4].Piece != null)
                {
                    if (board.Squares[4].Piece.Moved == false)
                    {
                        if (board.Squares[7].Piece != null)
                        {
                            if (board.Squares[7].Piece.Moved == false)
                            {
                                output += "k";
                                spacer = " ";
                            }
                        }
                        if (board.Squares[0].Piece != null)
                        {
                            if (board.Squares[0].Piece.Moved == false)
                            {
                                output += "q";
                                spacer = " ";
                            }
                        }
                    }
                }


            }

            if (output.EndsWith("/"))
            {
                output.TrimEnd('/');
            }


            if (board.EnPassantPosition != 0)
            {
                output += spacer + GetColumnFromByte((byte)(board.EnPassantPosition % 8)) + "" + (byte)(8 - (byte)(board.EnPassantPosition / 8)) + " ";
            }
            else
            {
                output += spacer + "- ";
            }

            if (!boardOnly)
            {
                output += board.FiftyMove + " ";
                output += board.MoveCount + 1;
            }
            return output.Trim();
        }
        private static string GetColumnFromByte(byte column)
        {
            switch (column)
            {
                case 0:
                    return "a";
                case 1:
                    return "b";
                case 2:
                    return "c";
                case 3:
                    return "d";
                case 4:
                    return "e";
                case 5:
                    return "f";
                case 6:
                    return "g";
                case 7:
                    return "h";
                default:
                    return "a";
            }
        }
    }
}
