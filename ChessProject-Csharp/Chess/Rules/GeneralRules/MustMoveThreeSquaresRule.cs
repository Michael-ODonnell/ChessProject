using System;

namespace Gfi.Hiring {
    /// <summary>
    /// Checks that the move endpoint is on the board
    /// </summary>
    class MustMoveThreeSquaresRule : IRule {
        
        public bool IsMoveValid(IChessBoard board, Move move)
        {
            int x = move.EndingX - move.StartingX;
            int y = move.EndingY - move.StartingY;
            // square everything to get rid of signs.
            return Math.Abs(x) + Math.Abs(y) == 3;
        }
    }
}
