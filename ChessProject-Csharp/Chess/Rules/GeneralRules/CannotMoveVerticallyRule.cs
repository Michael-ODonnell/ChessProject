using System;

namespace Gfi.Hiring {
    /// <summary>
    /// Prevent bishop, knight and pawn movement along the y=c axis
    /// </summary>
    class CannotMoveVerticallyRule : IRule {
        public bool IsMoveValid(IChessBoard board, Move move)
        {
            throw new NotImplementedException();
        }
    }
}
