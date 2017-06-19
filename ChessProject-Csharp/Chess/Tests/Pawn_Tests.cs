using NUnit.Framework;

namespace Gfi.Hiring {

    [TestFixture]
	public class Pawn_Tests : ChessPiece_Tests {
		
		protected override IChessPiece GetPiece(PieceColor color)
        {
            IRule[] pawnRules = new IRule[] {
                new EndpointSquareOccupiedRule(),
                new CannotMoveToSameSquareRule(),
                new EndpointSquareOccupiedRule(),
                new CannotMoveThroughPiecesRule(),
                new ValidPawnMoveRule()};
            return new Pawn(_chessBoard, color, pawnRules);
        }
	}
}
