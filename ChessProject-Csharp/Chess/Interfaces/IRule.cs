namespace Gfi.Hiring {

    /// <summary>
    /// A rule is something that governs behaviour of a piece
    /// </summary>
    public interface IRule {
        /// <summary>
        /// Check whether the rules on a piece allow a move
        /// </summary>
        /// <param name="board">The current boardstate before the move</param>
        /// <param name="move">The move to be performed</param>
        /// <returns> returns false if a move is not permitted</returns>
        bool IsMoveValid(IChessBoard board, Move move); 
    }
}
