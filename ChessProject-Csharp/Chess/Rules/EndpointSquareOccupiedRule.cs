namespace Gfi.Hiring {
    /// <summary>
    /// Checks that the piece being moved is allowed to occupy the endpoint
    /// </summary>
    class EndpointSquareOccupiedRule : IRule {
        public bool IsMoveValid(IChessBoard board, Move move)
        {
            IChessPiece capture;
            bool occupied = board.TryGetPieceOn(move.EndingX, move.EndingY, out capture);
            return !occupied || move.Piece.Color != capture.Color;
        }
    }
}
