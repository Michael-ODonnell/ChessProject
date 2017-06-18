using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring {
    class EndpointSquareOccupiedRule : IRule {
        public bool IsMoveValid(IChessBoard board, Move move)
        {
            IChessPiece capture;
            bool occupied = board.TryGetPieceOn(move.EndingX, move.EndingY, out capture);
            return !occupied || move.Piece.Color != capture.Color;
        }
    }
}
