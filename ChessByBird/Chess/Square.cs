namespace ChessByBird.ChessClient
{
    internal struct Square
    {
        internal Piece Piece;

        #region Constructors

        internal Square(Piece piece)
        {
            Piece = new Piece(piece);
        }

        #endregion
    }
}