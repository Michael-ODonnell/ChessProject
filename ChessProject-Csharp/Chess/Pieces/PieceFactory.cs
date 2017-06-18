using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring {
    internal class PieceFactory {

        private IChessBoard _board;

        public PieceFactory (IChessBoard board)
        {
            _board = board;
        }

        public IChessPiece Build(PieceType type, PieceColor color)
        {
            switch (type)
            {
                case PieceType.Pawn:
                    return CreatePawn(color);
                default:
                    throw new ArgumentException("No constructor found for " + type);
            }
        }

        private IChessPiece CreatePawn(PieceColor color)
        {
            Pawn pawn = new Pawn(_board, color);

            pawn.AddRule(new EndpointSquareOccupiedRule());
            pawn.AddRule(new CannotMoveToSameSquareRule());
            pawn.AddRule(new EndpointSquareOccupiedRule());
            pawn.AddRule(new CannotMoveThroughPiecesRule());
            pawn.AddRule(new ValidPawnMoveRule());
            return pawn;
        }
    }
}
