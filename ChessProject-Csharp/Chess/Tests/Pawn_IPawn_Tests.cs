using NUnit.Framework;

namespace Gfi.Hiring {

    [TestFixture]
	public class Pawn_IPawn_Tests : IPawn_Tests {
		
		protected override IPawn GetPawn(PieceColor color)
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
