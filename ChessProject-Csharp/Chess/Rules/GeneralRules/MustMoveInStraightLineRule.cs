using System;

namespace Gfi.Hiring {
    /// <summary>
    /// Checks that the move endpoint is on one of the four pricipal axis x, y, x=y. x=-y of the starting point
    /// </summary>
    class MustMoveInStraightLineRule : IRule {
        
        public bool IsMoveValid(IChessBoard board, Move move)
        {
            // y axis
            if(move.StartingX == move.EndingX)  
            {
                return true;
            }
            // x axis
            if (move.StartingY == move.EndingY)
            {
                return true;
            }
            // x=y axis
            if (move.EndingX - move.StartingX == move.EndingY - move.StartingY)
            {
                return true;
            }
            // x=-y axis
            if (move.EndingX - move.StartingX == move.StartingY - move.EndingY)
            {
                return true;
            }

            return false;
        }
    }
}
