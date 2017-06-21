using NSubstitute;
using NUnit.Framework;

namespace Gfi.Hiring {

	[TestFixture]
	public class MustMoveThreeSquaresRule_Test {

		[Test]
		public void Prevent_Movement_When_Moving_Four_Squares_Left()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new MustMoveThreeSquaresRule();

			Move move = new Move(piece, 4, 0, 0, 0);

			Assert.That(rule.IsMoveValid(board, move), Is.False);
		}

		[Test]
		public void Prevent_Movement_When_Moving_Four_Squares_Right()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new MustMoveThreeSquaresRule();

			Move move = new Move(piece, 0, 0, 4, 0);

			Assert.That(rule.IsMoveValid(board, move), Is.False);
		}

		[Test]
		public void Prevent_Movement_When_Moving_Two_Squares_Left()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new MustMoveThreeSquaresRule();

			Move move = new Move(piece, 2, 0, 0, 0);

			Assert.That(rule.IsMoveValid(board, move), Is.False);
		}

		[Test]
		public void Prevent_Movement_When_Moving_Two_Squares_Right()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new MustMoveThreeSquaresRule();

			Move move = new Move(piece, 0, 0, 2, 0);

			Assert.That(rule.IsMoveValid(board, move), Is.False);
		}
		[Test]
		public void Prevent_Movement_When_Moving_Four_Squares_Up()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new MustMoveThreeSquaresRule();

			Move move = new Move(piece, 0, 0, 0, 4);

			Assert.That(rule.IsMoveValid(board, move), Is.False);
		}

		[Test]
		public void Prevent_Movement_When_Moving_Four_Squares_Down()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new MustMoveThreeSquaresRule();

			Move move = new Move(piece, 0, 4, 0, 0);

			Assert.That(rule.IsMoveValid(board, move), Is.False);
		}

		[Test]
		public void Prevent_Movement_When_Moving_Two_Squares_Up()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new MustMoveThreeSquaresRule();

			Move move = new Move(piece, 0, 0, 0, 2);

			Assert.That(rule.IsMoveValid(board, move), Is.False);
		}

		[Test]
		public void Prevent_Movement_When_Moving_Two_Squares_Down()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new MustMoveThreeSquaresRule();

			Move move = new Move(piece, 0, 2, 0, 0);

			Assert.That(rule.IsMoveValid(board, move), Is.False);
		}

		[Test]
		public void Prevent_Movement_When_Moving_Four_Squares_On_Y_Equals_X()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new MustMoveThreeSquaresRule();

			Move move = new Move(piece, 0, 0, 2, 2);

			Assert.That(rule.IsMoveValid(board, move), Is.False);
		}

		[Test]
		public void Prevent_Movement_When_Moving_Two_Squares_On_Y_Equals_X()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new MustMoveThreeSquaresRule();

			Move move = new Move(piece, 0, 0, 1, 1);

			Assert.That(rule.IsMoveValid(board, move), Is.False);
		}

		[Test]
		public void Prevent_Movement_When_Moving_Four_Squares_On_Y_Equals_Minus_X()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new MustMoveThreeSquaresRule();

			Move move = new Move(piece, 2, 0, 0, 2);

			Assert.That(rule.IsMoveValid(board, move), Is.False);
		}

		[Test]
		public void Prevent_Movement_When_Moving_Two_Squares_On_Y_Equals_Minus_X()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new MustMoveThreeSquaresRule();

			Move move = new Move(piece, 1, 0, 0, 1);

			Assert.That(rule.IsMoveValid(board, move), Is.False);
        }

        [Test]
        public void Allow_Movement_When_Moving_Three_Squares_Left()
        {
            var board = Substitute.For<IChessBoard>();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new MustMoveThreeSquaresRule();

            Move move = new Move(piece, 3, 0, 0, 0);

            Assert.That(rule.IsMoveValid(board, move), Is.True);
        }

        [Test]
        public void Allow_Movement_When_Moving_Three_Squares_Right()
        {
            var board = Substitute.For<IChessBoard>();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new MustMoveThreeSquaresRule();

            Move move = new Move(piece, 0, 0, 3, 0);

            Assert.That(rule.IsMoveValid(board, move), Is.True);
        }

        [Test]
        public void Allow_Movement_When_Moving_Three_Squares_Up()
        {
            var board = Substitute.For<IChessBoard>();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new MustMoveThreeSquaresRule();

            Move move = new Move(piece, 0, 0, 0, 3);

            Assert.That(rule.IsMoveValid(board, move), Is.True);
        }

        [Test]
        public void Allow_Movement_When_Moving_Three_Squares_Down()
        {
            var board = Substitute.For<IChessBoard>();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new MustMoveThreeSquaresRule();

            Move move = new Move(piece, 0, 3, 0, 0);

            Assert.That(rule.IsMoveValid(board, move), Is.True);
        }

        [Test]
        public void Allow_Movement_When_Moving_One_Left_Two_Up()
        {
            var board = Substitute.For<IChessBoard>();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new MustMoveThreeSquaresRule();

            Move move = new Move(piece, 1, 0, 0, 2);

            Assert.That(rule.IsMoveValid(board, move), Is.True);
        }

        [Test]
        public void Allow_Movement_When_Moving_One_Left_Two_Down()
        {
            var board = Substitute.For<IChessBoard>();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new MustMoveThreeSquaresRule();

            Move move = new Move(piece, 1, 2, 0, 0);

            Assert.That(rule.IsMoveValid(board, move), Is.True);
        }

        [Test]
        public void Allow_Movement_When_Moving_Two_Left_One_Up()
        {
            var board = Substitute.For<IChessBoard>();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new MustMoveThreeSquaresRule();

            Move move = new Move(piece, 2, 0, 0, 1);

            Assert.That(rule.IsMoveValid(board, move), Is.True);
        }

        [Test]
        public void Allow_Movement_When_Moving_Two_Left_One_Down()
        {
            var board = Substitute.For<IChessBoard>();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new MustMoveThreeSquaresRule();

            Move move = new Move(piece, 2, 1, 0, 0);

            Assert.That(rule.IsMoveValid(board, move), Is.True);
        }

        [Test]
        public void Allow_Movement_When_Moving_One_Right_Two_Up()
        {
            var board = Substitute.For<IChessBoard>();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new MustMoveThreeSquaresRule();

            Move move = new Move(piece, 0, 0, 1, 2);

            Assert.That(rule.IsMoveValid(board, move), Is.True);
        }

        [Test]
        public void Allow_Movement_When_Moving_One_Right_Two_Down()
        {
            var board = Substitute.For<IChessBoard>();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new MustMoveThreeSquaresRule();

            Move move = new Move(piece, 0, 2, 1, 0);

            Assert.That(rule.IsMoveValid(board, move), Is.True);
        }

        [Test]
        public void Allow_Movement_When_Moving_Two_Right_One_Up()
        {
            var board = Substitute.For<IChessBoard>();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new MustMoveThreeSquaresRule();

            Move move = new Move(piece, 0, 0, 2, 1);

            Assert.That(rule.IsMoveValid(board, move), Is.True);
        }

        [Test]
        public void Allow_Movement_When_Moving_Two_Right_One_Down()
        {
            var board = Substitute.For<IChessBoard>();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new MustMoveThreeSquaresRule();

            Move move = new Move(piece, 0, 1, 2, 0);

            Assert.That(rule.IsMoveValid(board, move), Is.True);
        }
    }
}
