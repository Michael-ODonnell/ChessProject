using NSubstitute;
using NUnit.Framework;

namespace Gfi.Hiring {

    [TestFixture]
	public class EndpointSquareOccupiedRule_Tests {

		[Test]
		public void Move_Black_Onto_Square_Occupied_By_Black_Prohibited()
        {
            var board = SetupBoardWithOccupiedSquare(PieceColor.Black);

            var mover = Substitute.For<IChessPiece>();
            mover.Color.Returns(PieceColor.Black);

			IRule rule = new EndpointSquareOccupiedRule();

			Move move = new Move(mover, 0, 0, 1, 1);
            
            Assert.IsFalse(rule.IsMoveValid(board, move));
        }

        [Test]
        public void Move_White_Onto_Square_Occupied_By_White_Prohibited()
        {
            var board = SetupBoardWithOccupiedSquare(PieceColor.White);

            var mover = Substitute.For<IChessPiece>();
            mover.Color.Returns(PieceColor.White);

            IRule rule = new EndpointSquareOccupiedRule();

            Move move = new Move(mover, 0, 0, 1, 1);

            Assert.IsFalse(rule.IsMoveValid(board, move));
        }

        [Test]
		public void Move_Black_Onto_Square_Occupied_By_White_Allowed()
        {
            var board = SetupBoardWithOccupiedSquare(PieceColor.White);

            var mover = Substitute.For<IChessPiece>();
            mover.Color.Returns(PieceColor.Black);

            IRule rule = new EndpointSquareOccupiedRule();

            Move move = new Move(mover, 0, 0, 1, 1);

            Assert.IsTrue(rule.IsMoveValid(board, move));
        }

        [Test]
        public void Move_White_Onto_Square_Occupied_By_Black_Allowed()
        {
            var board = SetupBoardWithOccupiedSquare(PieceColor.Black);

            var mover = Substitute.For<IChessPiece>();
            mover.Color.Returns(PieceColor.White);

            IRule rule = new EndpointSquareOccupiedRule();

            Move move = new Move(mover, 0, 0, 1, 1);

            Assert.IsTrue(rule.IsMoveValid(board, move));
        }

        [Test]
		public void Move_White_Onto_Unoccupied_Square_Allowed()
        {
            var board = SetupBoardWithUnoccupiedSquare();

            var mover = Substitute.For<IChessPiece>();
            mover.Color.Returns(PieceColor.White);

            IRule rule = new EndpointSquareOccupiedRule();

            Move move = new Move(mover, 0, 0, 1, 1);

            Assert.IsTrue(rule.IsMoveValid(board, move));
        }

        [Test]
        public void Move_Black_Onto_Unoccupied_Square_Allowed()
        {
            var board = SetupBoardWithUnoccupiedSquare();

            var mover = Substitute.For<IChessPiece>();
            mover.Color.Returns(PieceColor.Black);

            IRule rule = new EndpointSquareOccupiedRule();

            Move move = new Move(mover, 0, 0, 1, 1);

            Assert.IsTrue(rule.IsMoveValid(board, move));
        }

        private IChessBoard SetupBoardWithOccupiedSquare(PieceColor color)
        {
            var board = Substitute.For<IChessBoard>();

            var occupier = Substitute.For<IChessPiece>();
            occupier.Color.Returns(color);

            IChessPiece outVar = null;
            board.TryGetPieceOn(Arg.Any<int>(), Arg.Any<int>(), out outVar). Returns( x => {
                x[2] = occupier;
                return true;
            });

            return board;
        }

        private IChessBoard SetupBoardWithUnoccupiedSquare()
        {
            var board = Substitute.For<IChessBoard>();

            IChessPiece outVar = null;
            board.TryGetPieceOn(Arg.Any<int>(), Arg.Any<int>(), out outVar).Returns(x => {
                x[2] = null;
                return false;
            });

            return board;
        }
    }
}
