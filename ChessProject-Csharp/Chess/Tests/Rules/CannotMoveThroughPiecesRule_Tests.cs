using NSubstitute;
using NUnit.Framework;

namespace Gfi.Hiring {

    [TestFixture]
	public class CannotMoveThroughPiecesRule_Tests {
        
        [Test]
        public void Allow_Movement_When_Moving_Along_X_Equals_C_With_Clear_Path()
        {
            var board = Substitute.For<IChessBoard>();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new CannotMoveThroughPiecesRule();
            board.IsStraightClearPathBetween(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(true);

            Move move = new Move(piece, 0, 0, 0, 5);
            Assert.IsTrue(rule.IsMoveValid(board, move));
            move = new Move(piece, 0, 5, 0, 0);
            Assert.IsTrue(rule.IsMoveValid(board, move));
        }

        [Test]
		public void Prevent_Movement_When_Moving_Along_X_Equals_C_With_Blocked_Path()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new CannotMoveThroughPiecesRule();

			board.IsStraightClearPathBetween(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(false);

			Move move = new Move(piece, 0, 0, 0, 5);
			Assert.IsFalse(rule.IsMoveValid(board, move));
            move = new Move(piece, 0, 5, 0, 0);
            Assert.IsFalse(rule.IsMoveValid(board, move));
        }

        [Test]
        public void Allow_Movement_When_Moving_Along_Y_Equals_C_With_Clear_Path()
        {
            var board = Substitute.For<IChessBoard>();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new CannotMoveThroughPiecesRule();

            board.IsStraightClearPathBetween(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(true);
            
            Move move = new Move(piece, 0, 0, 5, 0);
            Assert.IsTrue(rule.IsMoveValid(board, move));
            move = new Move(piece, 5, 0, 0, 0);
            Assert.IsTrue(rule.IsMoveValid(board, move));
        }

        [Test]
        public void Prevent_Movement_When_Moving_Along_Y_Equals_C_With_Blocked_Path()
        {
            var board = Substitute.For<IChessBoard>();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new CannotMoveThroughPiecesRule();

            board.IsStraightClearPathBetween(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(false);

            Move move = new Move(piece, 0, 0, 5, 0);
            Assert.IsFalse(rule.IsMoveValid(board, move));
            move = new Move(piece, 5, 0, 0, 0);
            Assert.IsFalse(rule.IsMoveValid(board, move));
        }

        [Test]
        public void Allow_Movement_When_Moving_Along_X_Equals_Y_With_Clear_Path()
        {
            var board = Substitute.For<IChessBoard>();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new CannotMoveThroughPiecesRule();

            board.IsStraightClearPathBetween(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(true);

            Move move = new Move(piece, 0, 0, 5, 5);
            Assert.IsTrue(rule.IsMoveValid(board, move));
            move = new Move(piece, 5, 5, 0, 0);
            Assert.IsTrue(rule.IsMoveValid(board, move));
        }

        [Test]
        public void Prevent_Movement_When_Moving_Along_X_Equals_Y_With_Blocked_Path()
        {
            var board = Substitute.For<IChessBoard>();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new CannotMoveThroughPiecesRule();

            board.IsStraightClearPathBetween(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(false);

            Move move = new Move(piece, 0, 0, 5, 5);
            Assert.IsFalse(rule.IsMoveValid(board, move));
            move = new Move(piece, 5, 5, 0, 0);
            Assert.IsFalse(rule.IsMoveValid(board, move));
        }

        [Test]
        public void Allow_Movement_When_Moving_Along_X_Equals_Minus_Y_With_Clear_Path()
        {
            var board = Substitute.For<IChessBoard>();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new CannotMoveThroughPiecesRule();

            board.IsStraightClearPathBetween(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(true);

            Move move = new Move(piece, 5, 0, 0, 5);
            Assert.IsTrue(rule.IsMoveValid(board, move));
            move = new Move(piece, 0, 5, 5, 0);
            Assert.IsTrue(rule.IsMoveValid(board, move));
        }

        [Test]
        public void Allow_Movement_When_Moving_Along_X_Equals_Minus_Y_With_Blocked_Path()
        {
            var board = Substitute.For<IChessBoard>();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new CannotMoveThroughPiecesRule();

            board.IsStraightClearPathBetween(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(false);

            Move move = new Move(piece, 5, 0, 0, 5);
            Assert.IsFalse(rule.IsMoveValid(board, move));
            move = new Move(piece, 0, 5, 5, 0);
            Assert.IsFalse(rule.IsMoveValid(board, move));
        }
    }
}
