/*******************************************************************************
 *  Penn State University Software Engraphics.neeringraphics.Graduate Prographics.am
 *  Authors: Team 1: Zachary Carson, Aaron Eugraphics.ne, Steve Hagraphics.erty, Joseph Oakes
 *  Date: Springraphics.2013
 *  Course: SWENG 500 Software Engraphics.neeringraphics.Studio
 *  Professor: Mohamad Kassab
 *  Project: Chess By Bird Capstone g.oup project
*******************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <Remarks>
/**
 * References:
 * http://en.wikipedia.org/wiki/Chess
 * http://www.fam-petzke.de/cp_board_en.shtml
 * 
 * 
 * Chess Board FEN parser class
 * 
 * 
 * Forsyth-Edwards Notation (FEN) describes a Chess Position. It is an one-line ASCII-string. FEN is based on a system 
 * created by Scotsman David Forsyth in the 19th century. Steven Edwards specified the FEN standard for computer chess 
 * applications as part of the Portable Game Notation [1].
 * 
 * Explanation:
 * 
 * Forsyth–Edwards Notation (FEN) is a standard notation for describing a particular 
 * ChessBoard position of a chess game. The purpose of FEN is to provide all the necessary
 * information to restart a game from a particular position. 
 * A FEN record contains six fields. The separator between fields is a space.
 * 
 * The six fields are:
 * 1. Piece placement on squares (A8 B8 .. G1 H1) Each piece is identified by a letter 
 *    taken from the standard English names (white upper-case, black lower-case). 
 *    Blank squares are noted using digits 1 through 8 (the number of blank squares), 
 *    and "/" separate ranks.
 * 2. Active color. "w" means white moves next, "b" means black.
 * 3. Castling availability. Either - if no side can castle or a letter (K,Q,k,q) for 
 *    each side and castle possibility.
 * 4. En passant target square in algebraic notation or "-".
 * 5. Halfmove (or parserPly) clock: This is the number of halfmoves since the last pawn advance or capture.
 * 6. Fullmove number: The number of the current full move.
 * 
 * The FEN parser
 * 
 * We implement a public method in our ChessBoard class called setFEN(string aFEN).
 * This method only accepts a valid FEN input if invalid it returns a syntax error.
 * The function splits the FEN string into its substrings and loops through the 
 * squares of the ChessBoard filling the squares data structure with the content of the string.
 * 
 * Samples
 * FEN strings of Starting Position and after 1.e4 c5 2.Nf3:
 *  rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1
 *  rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR b KQkq e3 0 1
 *  rnbqkbnr/pp1ppppp/8/2p5/4P3/8/PPPP1PPP/RNBQKBNR w KQkq c6 0 2
 *  rnbqkbnr/pp1ppppp/8/2p5/4P3/5N2/PPPP1PPP/RNBQKB1R b KQkq - 1 2
 * 
 * Examples 
 * Here is the FEN for the starting position:
 *  rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1
 * Here is the FEN after the move 1. e4:
 *  rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR b KQkq e3 0 1
 * And then after 1. ... c5:
 *  rnbqkbnr/pp1ppppp/8/2p5/4P3/8/PPPP1PPP/RNBQKBNR w KQkq c6 0 2
 * And then after 2. Nf3:
 *  nbqkbnr/pp1ppppp/8/2p5/4P3/5N2/PPPP1PPP/RNBQKB1R b KQkq - 1 2
 * 
 */
/// </Remarks>

namespace ChessByBird.ImagingProject
{
    /// <summary>
    /// ChessBoardParser class
    /// </summary>
    public static class ChessBoardParser
    {
        /**
         * Example: Set the Initial Position for a chess game like so...
         * "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1"
         */

        /// <summary>
        ///  Reset the ChessBoard and set its position to the one specified by the FEN string   
        /// </summary>
        public static int SetFEN(string aFEN)
        {
            /// <summary>
            /// Local Variables
            /// </summary>
            uint i = 0;
            uint j = 0;
            uint aRank = 0;
            uint aFile = 0;
            char letter = ' ';

            ArrayList tokenList = new ArrayList(aFEN.Split(" ".ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries));

            // Empty the ChessBoard squares
            ChessImageConstants.parserChessBoardSquares.Clear();
            for (EnumSquareID sid = EnumSquareID.A1; sid <= EnumSquareID.H8; sid = ChessSquareID.IncrementEnumSquareID(sid))
            {
                //Console.WriteLine(sid);
                ChessImageConstants.parserChessBoardSquares.Add(sid, EnumPieceID.Empty);
            }

            /** 1. Piece placement on squares (A8 B8 .. G1 H1) Each piece is identified by a letter 
              *    taken from the standard English names (white upper-case, black lower-case). 
              *    Blank squares are noted using digits 1 through 8 (the number of blank squares), 
              *    and "/" separate ranks.
              */

            // 1. Read the ChessBoard & translate each loop index into a ChessBoard square

            // The variable i marks the current position in the FEN string.
            // The variable j walks through the ChessBoard in the direction the 
            // FEN squares occur (A8 .. H1).

            j = 1;
            i = 0;
            while ((j <= ChessImageConstants.SquareCount) && (i <= tokenList[0].ToString().Length))
            {
                letter = tokenList[0].ToString().ToCharArray()[i];
                i++;
                aFile = 1 + ((j - 1) % 8);
                aRank = 8 - ((j - 1) / 8);
                ChessImageConstants.parserSquareID = (EnumSquareID)(((aRank - 1) * 8) + (aFile - 1));

                switch (letter)
                {
                    case 'p': ChessImageConstants.parserChessBoardSquares[ChessImageConstants.parserSquareID] = EnumPieceID.BlackPawn; break;
                    case 'r': ChessImageConstants.parserChessBoardSquares[ChessImageConstants.parserSquareID] = EnumPieceID.BlackRook; break;
                    case 'n': ChessImageConstants.parserChessBoardSquares[ChessImageConstants.parserSquareID] = EnumPieceID.BlackKnight; break;
                    case 'b': ChessImageConstants.parserChessBoardSquares[ChessImageConstants.parserSquareID] = EnumPieceID.BlackBishop; break;
                    case 'q': ChessImageConstants.parserChessBoardSquares[ChessImageConstants.parserSquareID] = EnumPieceID.BlackQueen; break;
                    case 'k': ChessImageConstants.parserChessBoardSquares[ChessImageConstants.parserSquareID] = EnumPieceID.BlackKing; break;

                    case 'P': ChessImageConstants.parserChessBoardSquares[ChessImageConstants.parserSquareID] = EnumPieceID.WhitePawn; break;
                    case 'R': ChessImageConstants.parserChessBoardSquares[ChessImageConstants.parserSquareID] = EnumPieceID.WhiteRook; break;
                    case 'N': ChessImageConstants.parserChessBoardSquares[ChessImageConstants.parserSquareID] = EnumPieceID.WhiteKnight; break;
                    case 'B': ChessImageConstants.parserChessBoardSquares[ChessImageConstants.parserSquareID] = EnumPieceID.WhiteBishop; break;
                    case 'Q': ChessImageConstants.parserChessBoardSquares[ChessImageConstants.parserSquareID] = EnumPieceID.WhiteQueen; break;
                    case 'K': ChessImageConstants.parserChessBoardSquares[ChessImageConstants.parserSquareID] = EnumPieceID.WhiteKing; break;

                    case '/': j--; break;

                    case '1': break;
                    case '2': j++; break;
                    case '3': j += 2; break;
                    case '4': j += 3; break;
                    case '5': j += 4; break;
                    case '6': j += 5; break;
                    case '7': j += 6; break;
                    case '8': j += 7; break;
                    default: return -1;
                }
                j++;
            }

            /** 
             * 2. Active color. "w" means white moves next, "b" means black.
             * 
             * "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1"
             */

            /**
             * Set the isTurn which is stored in the 2nd substring with default = White
             */
            if (tokenList.Count >= 2)
            {
                if ((string)tokenList[1] == "w")
                {
                    ChessImageConstants.parserSideToMove = EnumOpponentColor.White;
                }
                else if ((string)tokenList[1] == "b")
                {
                    ChessImageConstants.parserSideToMove = EnumOpponentColor.Black;
                }
                else
                {
                    return -1;
                }
            }

            /** 
             * 3. Castling availability. Either - if no side can castle or a letter (K,Q,k,q) for 
             *    each side and castle possibility.
             * 
             * "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1"
             */

            /**
             * Castling rights are stored in a single integer where different bits indicate 
             * a certain right exists (bit = 1) or the right doesn't exist (bit = 0)
             */

            // InitializeChessBoard chess board state
            ChessImageConstants.parserChessBoardState.SetAll(false);

            // InitializeChessBoard all Castling Possibilities
            if (tokenList.ToArray().Count() >= 3)
            {
                if (tokenList[2].ToString().Contains('K') == true)
                {
                    ChessImageConstants.parserChessBoardState.Set((int)EnumCastlingRights.WhiteCastleKingSide, true);
                }
                if (tokenList[2].ToString().Contains('Q') == true)
                {
                    ChessImageConstants.parserChessBoardState.Set((int)EnumCastlingRights.WhiteCastleQueenSide, true);
                }
                if (tokenList[2].ToString().Contains('k') == true)
                {
                    ChessImageConstants.parserChessBoardState.Set((int)EnumCastlingRights.BlackCastleKingSide, true);
                }
                if (tokenList[2].ToString().Contains('q') == true)
                {
                    ChessImageConstants.parserChessBoardState.Set((int)EnumCastlingRights.BlackCastleQueenSide, true);
                }

                /** 4. En passant target square in algebraic notation or "-".
                 * 
                 * "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1"
                 */

                /**
                 * The next sub string stands for a possible en passent square. 
                 * The square is initialized to the square "ER", which just means 
                 * no valid square (we could initialize also to square 0, which is A1. 
                 * Because A1 is also not a valid en passent square it is possible to 
                 * recognize this situation as "No en passent" possibility but keep 
                 * your code clean and readable. And it is advisable to call an invalid 
                 * square "Invalid square" and not use a valid square for that, which 
                 * is just invalid in this situation.
                 */

                /// 
                /// Read en passent and save it into "square" Default := None (ER)
                ///
                ChessImageConstants.parserEnPassentSquareID = EnumSquareID.ER;
                if ((tokenList.ToArray().Count() >= 4) && (tokenList[3].ToString().Length >= 2))
                {
                    char[] charArray = tokenList[3].ToString().ToCharArray();
                    if ((charArray[0] >= 'a') && (charArray[0] <= 'h')
                        && ((charArray[1] == '3') || (charArray[1] == '6')))
                    {
                        aFile = (uint)charArray[0] - 96; // ASCII 'a' = 97
                        aRank = (uint)charArray[1] - 48; // ASCII '1' = 49    
                        ChessImageConstants.parserEnPassentSquareID = (EnumSquareID)((aRank - 1) * 8 + aFile - 1);
                    }
                    else
                    {
                        return -1;
                    }
                }

                /**
                 * 5. Halfmove clock: This is the number of halfmoves (or parserPly) since the last pawn advance or capture.
                 *
                 * "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1"
                 */
                if (tokenList.Count >= 5)
                {
                    ChessImageConstants.parserPly = Convert.ToInt32(tokenList[4].ToString());
                }

                /**
                 * 6. Fullmove number: The number of the current full move.
                 * 
                 * "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1"
                 */

                // Retrieve the Turn number, starting at 1 by default
                ChessImageConstants.parserCurrentPly = 1;
                if (tokenList.Count >= 6)
                {
                    ChessImageConstants.parserCurrentPly = 2 * (Convert.ToInt32(tokenList[5].ToString()) - 1) + 1;
                    if (ChessImageConstants.parserCurrentPly < 0) ChessImageConstants.parserCurrentPly = 0; // avoid possible underflow
                    if (ChessImageConstants.parserSideToMove == EnumOpponentColor.Black) ChessImageConstants.parserCurrentPly++;
                }
            }
            return 0;
        }
    }
}
