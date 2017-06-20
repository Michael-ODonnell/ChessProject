using NSubstitute;
using NUnit.Framework;

namespace Gfi.Hiring {

	[TestFixture]
	public class CannotMoveToSameSquareRule_Tests {

		[Test]
		public void Prevent_Movement_When_Start_Square_Equals_End_Square()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new CannotMoveToSameSquareRule();

			Move move = new Move(piece, 0, 0, 0, 0);

			Assert.That(rule.IsMoveValid(board, move), Is.False);
		}

		[Test]
		public void Allow_Movement_When_Start_X_Equals_End_X()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new CannotMoveToSameSquareRule();

			Move move = new Move(piece, 0, 0, 0, 1);

			Assert.That(rule.IsMoveValid(board, move), Is.True);
		}

		[Test]
		public void Allow_Movement_When_Start_Y_Equals_End_Y()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new CannotMoveToSameSquareRule();

			Move move = new Move(piece, 0, 0, 1, 0);

			Assert.That(rule.IsMoveValid(board, move), Is.True);
		}
	}
}
