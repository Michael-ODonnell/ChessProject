using NSubstitute;
using NUnit.Framework;

namespace Gfi.Hiring {

	[TestFixture]
	public class CannotMoveHorizontallyRule_Tests {

		[Test]
		public void Prevent_Movement_When_Start_X_Greater_Than_End_X()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new CannotMoveOnXAxisRule();

			Move move = new Move(piece, 1, 0, 0, 0);

			Assert.That(rule.IsMoveValid(board, move), Is.False);
		}

		[Test]
		public void Prevent_Movement_When_Start_X_Less_Than_End_X()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new CannotMoveOnXAxisRule();

			Move move = new Move(piece, 0, 0, 1, 0);

			Assert.That(rule.IsMoveValid(board, move), Is.False);
		}

		[Test]
		public void Allow_Movement_When_Start_X_Equals_End_X()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new CannotMoveOnXAxisRule();

			Move move = new Move(piece, 3, 0, 3, 1);

			Assert.That(rule.IsMoveValid(board, move), Is.True);
		}

		[Test]
		public void Allow_Movement_Across_Multiple_Squares_When_Start_X_Equals_End_X()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new CannotMoveOnXAxisRule();

			board.Width.Returns(8);

			Move move = new Move(piece, 0, 0, 0, board.Height-1);

			Assert.That(rule.IsMoveValid(board, move));
        }

        [Test]
        public void Allow_Movement_On_X_When_Y_Changes()
        {
            var board = Substitute.For<IChessBoard>();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new CannotMoveOnYAxisRule();

            Move move = new Move(piece, 0, 0, 1, 1);

            Assert.That(rule.IsMoveValid(board, move), Is.True);
        }
    }
}
