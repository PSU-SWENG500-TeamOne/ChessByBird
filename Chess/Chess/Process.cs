using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject.Chess
{
    class Process
    {
        /*
         * Default constrcutor
         */
        public Process()
        {

        }
        /*
         * This is the process Driver This class handles all the checkes at the top most level
         * Each failed check throws the exception.
         */
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
            Engine engine = null;
            String fen;
            /*
             * This if/else checks for the move string throws and exception if null is passed in
             * This also checks and verify if the string is correct format it will throw
             * the exceptions
             */
            if (move != null)
            {
                int space = move.LastIndexOf(" ");
                if (space == -1)
                {
                    throw new System.ArgumentException("The move sting is in the wrong format missing space between moves", "Chess"); 
                }
                Byte[] bytes = Encoding.ASCII.GetBytes(move.ToLower());
                csColumn = (char)bytes[space - 2];
                sColumn = GetByteFromCharL(csColumn);
                scrow = (char)bytes[space - 1];
                sRow = GetByteFromCharN(scrow);
                cdColumn = (char)bytes[space + 1];
                dColumn = GetByteFromCharL(cdColumn);
                dcrow = (char)bytes[space + 2];

                dRow = GetByteFromCharN((char)bytes[space + 2]);

            }
            else
            {
                throw new System.ArgumentException("The move sting is null", "Chess");
            }

            /*
             * This if/else  checks for the board to be null or not and creates the engine           
             */
            if (board != null)
            {
                    engine = new Engine(board);

            }
            else
            {
                    engine = new Engine();
            }

            String pieceColor = engine.GetPieceColorAt(sColumn, sRow).ToString();
            String moveColor = engine.WhoseMove.ToString();

            /*
             *  Checks the piece color with the move color if they are not the same throws and exception            
             */
            if (!pieceColor.Equals(moveColor))
            {
                throw new System.ArgumentException("THE PIECE YOU ARE MOVING IS NOT YOUR COLOR PLEASE MOVE YOUR COLOR", "Chess");
            }

            /*
             *  Check to make sure the move is valid and make sure the FEN is valid      
             */
            if (engine.IsValidMove(sColumn, sRow, dColumn, dRow))
            {
             /*
             *     Checks to make sure th move is complete
             */
                if (!engine.MovePiece(sColumn, sRow, dColumn, dRow))
                {
                    throw new System.ArgumentException("MOVED FAILED PLEASE RESEND", "Chess");
                }
            }
            else
            {
                throw new System.ArgumentException("Invalid Move or Malformed FEN", "Chess");
            }

            fen = Fen(false, engine.ChessBoard);
            return fen;
        }


            /*
             *  Parse the board to the FEN
             */
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

             /*
             *Converts ColumnFromByte              
             */
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
             /*
             *Converts bytye from char for parsing the move for letters          
             */
        /*
        private static byte GetByteFromCharL(char value)
        {
            switch (value)
            {
                case 'a':
                    return 7;
                case 'b':
                    return 6;
                case 'c':
                    return 5;
                case 'd':
                    return 4;
                case 'e':
                    return 3;
                case 'f':
                    return 2;
                case 'g':
                    return 1;
                case 'h':
                    return 0;
                default:
                    throw new System.ArgumentException("Either the Column or Row value is Invalid", "Chess");
            }
        }
        /*
             *Converts bytye from char for parsing the move for Numbers          
             
        private static byte GetByteFromCharN(char value)
        {
            switch (value)
            {
                case '1':
                    return 0;
                case '2':
                    return 1;
                case '3':
                    return 2;
                case '4':
                    return 3;
                case '5':
                    return 4;
                case '6':
                    return 5;
                case '7':
                    return 6;
                case '8':
                    return 7;
                default:
                    throw new System.ArgumentException("Either the Column or Row value is Invalid", "Chess");
            }
        }
        */
        
        
        private static byte GetByteFromCharL(char value)
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
                default:
                    throw new System.ArgumentException("Either the Column or Row value is Invalid", "Chess");
            }
        }

        private static byte GetByteFromCharN(char value)
        {
            switch (value)
            {
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
          

            /*
             *Checks is the player is white return true if is.              
             */

        public bool IsWhiteMove(String fn)
        {
            bool move = false;
            Engine Tengine = new Engine(fn);
            string whitemove = "White";
            if (whitemove.Equals(Tengine.ChessBoard.WhoseMove.ToString()))
            {
                move = true;
            }
            return move;

        }
        public static bool SearchForMate(ChessPieceColor movingSide, Board examineBoard, bool blackMate, bool whiteMate, bool staleMate)
        {
            bool foundNonCheckBlack = false;
            bool foundNonCheckWhite = false;

            for (byte x = 0; x < 64; x++)
            {
                Square sqr = examineBoard.Squares[x];

                //Make sure there is a piece on the square
                if (sqr.Piece == null)
                    continue;

                //Make sure the color is the same color as the one we are moving.
                if (sqr.Piece.PieceColor != movingSide)
                    continue;

                //For each valid move for this piece
                foreach (byte dst in sqr.Piece.ValidMoves)
                {

                    //We make copies of the board and move so we don't change the original
                    Board board = examineBoard.FastCopy();

                    //Make move so we can examine it
                    Board.MovePiece(board, x, dst, ChessPieceType.Queen);

                    //We Generate Valid Moves for Board
                    PieceValidMoves.GenerateValidMoves(board);

                    if (board.BlackCheck == false)
                    {
                        foundNonCheckBlack = true;
                    }
                    else if (movingSide == ChessPieceColor.Black)
                    {
                        continue;
                    }

                    if (board.WhiteCheck == false)
                    {
                        foundNonCheckWhite = true;
                    }
                    else if (movingSide == ChessPieceColor.White)
                    {
                        continue;
                    }
                }
            }

            if (foundNonCheckBlack == false)
            {
                if (examineBoard.BlackCheck)
                {
                    blackMate = true;
                    return true;
                }
                if (!examineBoard.WhiteMate && movingSide != ChessPieceColor.White)
                {
                    staleMate = true;
                    return true;
                }
            }

            if (foundNonCheckWhite == false)
            {
                if (examineBoard.WhiteCheck)
                {
                    whiteMate = true;
                    return true;
                }
                if (!examineBoard.BlackMate && movingSide != ChessPieceColor.Black)
                {
                    staleMate = true;
                    return true;
                }
            }

            return false;
        }
    }
}
