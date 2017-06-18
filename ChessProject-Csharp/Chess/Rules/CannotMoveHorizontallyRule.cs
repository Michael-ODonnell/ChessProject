using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring {
    /// <summary>
    /// Prevent bishop, knight and pawn movement along the y=c axis
    /// </summary>
    class CannotMoveHorizontallyRule : IRule {
        public bool IsMoveValid(IChessBoard board, Move move)
        {
            throw new NotImplementedException();
        }
    }
}
