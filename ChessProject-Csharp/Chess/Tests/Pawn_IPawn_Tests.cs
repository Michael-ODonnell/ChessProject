using NUnit.Framework;

namespace Gfi.Hiring {

    [TestFixture]
	public class Pawn_IPawn_Tests : IPawn_Tests {
		
		protected override IPawn GetPawn(PieceColor color)
		{
			return new Pawn(color);
		}
	}
}
