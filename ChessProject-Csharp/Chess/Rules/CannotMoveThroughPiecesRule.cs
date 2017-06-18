using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring {
    /// <summary>
    /// Prevents a move being performed when a piece lies between the start and end points.
    /// </summary>
    class CannotMoveThroughPiecesRule : IRule {
        public bool IsMoveValid(IChessBoard board, Move move)
        {
            throw new NotImplementedException();
        }
    }
}
