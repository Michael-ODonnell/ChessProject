using NSubstitute;
using NUnit.Framework;

namespace Gfi.Hiring {

	[TestFixture]
	public class MustMoveInStraightLineRule_Test {

		[Test]
		public void Allow_Movement_When_Moving_One_Square_Left()
		{
			var board = Create8By8Board();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new MustMoveInStraightLineRule();

			Move move = new Move(piece, 1, 0, 0, 0);

			Assert.That(rule.IsMoveValid(board, move), Is.True);
		}

		[Test]
		public void Allow_Movement_When_Moving_One_Square_Right()
		{
			var board = Create8By8Board();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new MustMoveInStraightLineRule();

			Move move = new Move(piece, 0, 0, 1, 0);

			Assert.That(rule.IsMoveValid(board, move), Is.True);
		}
        
		[Test]
		public void Allow_Movement_When_Moving_One_Square_Up()
		{
			var board = Create8By8Board();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new MustMoveInStraightLineRule();

			Move move = new Move(piece, 0, 0, 0, 1);

			Assert.That(rule.IsMoveValid(board, move), Is.True);
		}

		[Test]
		public void Allow_Movement_When_Moving_One_Square_Down()
		{
			var board = Create8By8Board();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new MustMoveInStraightLineRule();

			Move move = new Move(piece, 0, 1, 0, 0);

			Assert.That(rule.IsMoveValid(board, move), Is.True);
		}
        
		[Test]
		public void Allow_Movement_When_Moving_On_Y_Equals_X()
		{
			var board = Create8By8Board();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new MustMoveInStraightLineRule();

			Move move = new Move(piece, 0, 0, board.Width-1, board.Height - 1);

			Assert.That(rule.IsMoveValid(board, move), Is.True);
		}

		[Test]
		public void Allow_Movement_When_Moving_On_Y_Equals_Minus_X()
		{
			var board = Create8By8Board();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new MustMoveInStraightLineRule();

			Move move = new Move(piece, board.Width-1, 0, 0, board.Height-1);

			Assert.That(rule.IsMoveValid(board, move), Is.True);
		}

        [Test]
        public void Allow_Movement_When_Moving_Full_Board_Left()
        {
            var board = Create8By8Board();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new MustMoveInStraightLineRule();

            Move move = new Move(piece, board.Width - 1, 0, 0, 0);

            Assert.That(rule.IsMoveValid(board, move), Is.True);
        }

        [Test]
        public void Allow_Movement_When_Moving_Full_Board_Right()
        {
            var board = Create8By8Board();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new MustMoveInStraightLineRule();

            Move move = new Move(piece, 0, 0, board.Width - 1, 0);

            Assert.That(rule.IsMoveValid(board, move), Is.True);
        }

        [Test]
        public void Allow_Movement_When_Moving_Full_Board_Up()
        {
            var board = Create8By8Board();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new MustMoveInStraightLineRule();

            Move move = new Move(piece, 0, 0, 0, board.Height - 1);

            Assert.That(rule.IsMoveValid(board, move), Is.True);
        }

        [Test]
        public void Allow_Movement_When_Moving_Full_Board_Down()
        {
            var board = Create8By8Board();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new MustMoveInStraightLineRule();

            Move move = new Move(piece, 0, board.Height - 1, 0, 0);

            Assert.That(rule.IsMoveValid(board, move), Is.True);
        }

        [Test]
        public void Prevent_Movement_When_Moving_One_Left_Two_Up()
        {
            var board = Create8By8Board();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new MustMoveInStraightLineRule();

            Move move = new Move(piece, 1, 0, 0, 2);

            Assert.That(rule.IsMoveValid(board, move), Is.False);
        }

        [Test]
        public void Prevent_Movement_When_Moving_One_Left_Two_Down()
        {
            var board = Create8By8Board();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new MustMoveInStraightLineRule();

            Move move = new Move(piece, 1, 2, 0, 0);

            Assert.That(rule.IsMoveValid(board, move), Is.False);
        }

        [Test]
        public void Prevent_Movement_When_Moving_Two_Left_One_Up()
        {
            var board = Create8By8Board();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new MustMoveInStraightLineRule();

            Move move = new Move(piece, 2, 0, 0, 1);

            Assert.That(rule.IsMoveValid(board, move), Is.False);
        }

        [Test]
        public void Prevent_Movement_When_Moving_Two_Left_One_Down()
        {
            var board = Create8By8Board();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new MustMoveInStraightLineRule();

            Move move = new Move(piece, 2, 1, 0, 0);

            Assert.That(rule.IsMoveValid(board, move), Is.False);
        }

        [Test]
        public void Prevent_Movement_When_Moving_One_Right_Two_Up()
        {
            var board = Create8By8Board();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new MustMoveInStraightLineRule();

            Move move = new Move(piece, 0, 0, 1, 2);

            Assert.That(rule.IsMoveValid(board, move), Is.False);
        }

        [Test]
        public void Prevent_Movement_When_Moving_One_Right_Two_Down()
        {
            var board = Create8By8Board();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new MustMoveInStraightLineRule();

            Move move = new Move(piece, 0, 2, 1, 0);

            Assert.That(rule.IsMoveValid(board, move), Is.False);
        }

        [Test]
        public void Prevent_Movement_When_Moving_Two_Right_One_Up()
        {
            var board = Create8By8Board();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new MustMoveInStraightLineRule();

            Move move = new Move(piece, 0, 0, 2, 1);

            Assert.That(rule.IsMoveValid(board, move), Is.False);
        }

        [Test]
        public void Prevent_Movement_When_Moving_Two_Right_One_Down()
        {
            var board = Create8By8Board();
            var piece = Substitute.For<IChessPiece>();
            IRule rule = new MustMoveInStraightLineRule();

            Move move = new Move(piece, 0, 1, 2, 0);

            Assert.That(rule.IsMoveValid(board, move), Is.False);
        }

        private IChessBoard Create8By8Board()
        {
            var board = Substitute.For<IChessBoard>();
            board.Width.Returns(8);
            board.Height.Returns(8);

            return board;
        }
    }
}
