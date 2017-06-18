using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring {

    /// <summary>
    /// A rule is something that governs behaviour of a piece
    /// </summary>
    public interface IRule {
        /// <summary>
        /// Check whether the rules on a piece allow a move
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns> returns false if a move is not permitted</returns>
        bool IsMoveValid(IChessBoard board, Move move); 
    }
}
