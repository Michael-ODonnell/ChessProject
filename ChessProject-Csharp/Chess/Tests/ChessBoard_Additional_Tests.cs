using NUnit.Framework;

namespace Gfi.Hiring {
    [TestFixture]
	public class ChessBoard_Additional_Tests : IChessBoard_Tests   
	{
		protected override IChessBoard GetBoard()
		{
			return new ChessBoard();
		}
	}
}
