namespace Gfi.Hiring {
    /// <summary>
    /// Prevent bishop, knight and pawn movement along the y=c axis
    /// </summary>
    class CannotMoveHorizontallyRule : IRule {
        public bool IsMoveValid(IChessBoard board, Move move)
        {
            return move.StartingY == move.EndingY;
        }
    }
}
