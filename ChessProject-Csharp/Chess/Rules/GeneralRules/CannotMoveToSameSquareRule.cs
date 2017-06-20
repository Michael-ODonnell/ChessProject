namespace Gfi.Hiring {
    /// <summary>
    /// Prevent a move being performed to the same square the piece is on
    /// </summary>
    class CannotMoveToSameSquareRule : IRule {
        public bool IsMoveValid(IChessBoard board, Move move)
        {
            return move.StartingX != move.EndingX || move.StartingY != move.EndingY;
        }
    }
}
