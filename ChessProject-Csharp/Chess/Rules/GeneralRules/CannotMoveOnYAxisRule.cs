using System;

namespace Gfi.Hiring {
    /// <summary>
    /// Prevent bishop, knight and pawn movement along the y=c axis
    /// </summary>
    class CannotMoveOnYAxisRule : IRule {
        public bool IsMoveValid(IChessBoard board, Move move)
        {
            if (move.StartingX != move.EndingX)
            {
                return true;
            }
            return move.StartingY == move.EndingY;
        }
    }
}
