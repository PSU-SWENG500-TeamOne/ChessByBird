using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject.Chess
{
    class Process
    {
        public Process()
        {

        }

        public String processChess(String move, String board)
        {
            byte sColumn;
            byte sRow;
            byte dColumn;
            byte dRow;
            char csColumn;
            char scrow;
            char cdColumn;
            char dcrow;
            Engine engine;
            String fen;

            if (move != null)
            {
               int space = move.LastIndexOf(" ");
               Byte[] bytes = Encoding.ASCII.GetBytes(move.ToLower());          
               csColumn = (char)bytes[space - 2];
               sColumn = GetByteFromChar(csColumn);      
               scrow =(char)bytes[space - 1];
               sRow = GetByteFromChar(scrow);   
               cdColumn = (char)bytes[space + 1];
               dColumn = GetByteFromChar(cdColumn);
               dcrow = (char) bytes[space + 2];

               dRow =GetByteFromChar((char)bytes[space + 2]);

            }
            else
            {
                throw new System.ArgumentException("The move sting is null", "Chess");
            }

            if(board != null)
            {
                engine = new Engine(board);
            }
            else{
                engine = new Engine();                            
            }

            String pieceColor = engine.GetPieceColorAt(sColumn, sRow).ToString();     
            String moveColor = engine.WhoseMove.ToString();
            if(!pieceColor.Equals(moveColor))
            {
                throw new System.ArgumentException("THE PIECE YOU ARE MOVING IS NOT YOUR COLOR PLEASE MOVE YOUR COLOR", "Chess");
            }


            if(engine.IsValidMove(sColumn,sRow,dColumn,dRow))
            {
                if (!engine.MovePiece(sColumn, sRow, dColumn, dRow))
                {
                    throw new System.ArgumentException("MOVED FAILED PLEASE RESEND", "Chess");
                }
           }
            else
            { 
                 throw new System.ArgumentException("Invalid Move move not allowed", "Chess");
            }

            fen = Fen(false, engine.ChessBoard);
            return fen;
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
        private static byte GetByteFromChar(char value)
        {
            switch (value)
            {
                case 'a':
                    return 0;
                case 'b':
                    return 1;
                case 'c':
                    return 2;
                case 'd':
                    return 3;
                case 'e':
                    return 4;
                case 'f':
                    return 5;
                case 'g':
                    return 6;
                case 'h':
                    return 7;
                case '1':
                    return 7;
                case '2':
                    return 6;
                case '3':
                    return 5;
                case '4':
                    return 4;
                case '5':
                    return 3;
                case '6':
                    return 2;
                case '7':
                    return 1;
                case '8':
                    return 0;
                default:
                    throw new System.ArgumentException("Either the Column or Row value is Invalid", "Chess");
            }
        }
    }
}
