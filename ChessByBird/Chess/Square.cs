namespace ChessByBird.Chess
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