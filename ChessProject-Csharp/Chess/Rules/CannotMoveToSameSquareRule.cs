using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring {
    class CannotMoveToSameSquareRule : IRule {
        public bool IsMoveValid(IChessBoard board, Move move)
        {
            return move.StartingX != move.EndingX || move.StartingY != move.EndingY;
        }
    }
}
