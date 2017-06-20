namespace Gfi.Hiring {
    /// <summary>
    /// Prevents a move being performed when a piece lies between the start and end points.  The start and end points themselves may be occupied
    /// </summary>
    class CannotMoveThroughPiecesRule : IRule {
        public bool IsMoveValid(IChessBoard board, Move move)
        {
            return board.IsStraightClearPathBetween(move.StartingX, move.StartingY, move.EndingX, move.EndingY);
        }
    }
}
