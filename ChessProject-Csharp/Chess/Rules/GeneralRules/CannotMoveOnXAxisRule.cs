namespace Gfi.Hiring {
    /// <summary>
    /// Prevent bishop, knight and pawn movement along the y=c axis
    /// </summary>
    class CannotMoveOnXAxisRule : IRule {
        public bool IsMoveValid(IChessBoard board, Move move)
        {
            if(move.StartingY != move.EndingY)
            {
                return true;
            }
            return move.StartingX == move.EndingX;
        }
    }
}
