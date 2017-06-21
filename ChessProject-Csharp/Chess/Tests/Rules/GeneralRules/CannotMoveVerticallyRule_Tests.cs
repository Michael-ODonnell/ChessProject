using NSubstitute;
using NUnit.Framework;

namespace Gfi.Hiring {

    [TestFixture]
	public class CannotMoveVerticallyRule_Tests {

		[Test]
		public void Prevent_Movement_When_Start_Y_Greater_Than_End_Y()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new CannotMoveVerticallyRule();

			Move move = new Move(piece, 0, 0, 1, 1);

			Assert.That(rule.IsMoveValid(board, move), Is.False);
		}

		[Test]
		public void Prevent_Movement_When_Start_Y_Less_Than_End_Y()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new CannotMoveVerticallyRule();

			Move move = new Move(piece, 1, 1, 0, 0);

            Assert.That(rule.IsMoveValid(board, move), Is.False);
        }

		[Test]
		public void Allow_Movement_When_Start_Y_Equals_End_Y()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new CannotMoveVerticallyRule();

			Move move = new Move(piece, 0, 0, 1, 0);

            Assert.That(rule.IsMoveValid(board, move), Is.True);
        }

		[Test]
		public void Allow_Movement_Across_Multiple_Squares_When_Start_Y_Equals_End_Y()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new CannotMoveVerticallyRule();

			board.Width.Returns(8);

			Move move = new Move(piece, 0, 0, board.Width-1, 0);

            Assert.That(rule.IsMoveValid(board, move));
		}
	}
}
