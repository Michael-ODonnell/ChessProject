using System;

namespace Gfi.Hiring
{
    public class Pawn : ChessPiece, IPawn
    {
        public const int Max = 8;

        public Pawn(IChessBoard board, PieceColor pieceColor) : base(board, PieceType.Pawn, pieceColor, PawnRules())
        {

        }

        public int FirstMovedOn { get { throw new NotImplementedException(); } }

        private static IRule[] PawnRules()
        {
            return new IRule[] {
                new EndpointSquareOccupiedRule(),
                new CannotMoveToSameSquareRule(),
                new EndpointSquareOccupiedRule(), 
                new CannotMoveThroughPiecesRule(),
                new ValidPawnMoveRule()
            };
        }
        public override string ToString()
        {
            return CurrentPositionAsString();
        }

        protected string CurrentPositionAsString()
        {
            return string.Format("Current X: {1}{0}Current Y: {2}{0}Piece Color: {3}", Environment.NewLine, XCoordinate, YCoordinate, Color);
        }

    }
}
