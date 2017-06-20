using NSubstitute;
using NUnit.Framework;

namespace Gfi.Hiring {

    [TestFixture]
	public class ValidPawnMoveRuleTests {
		
		[Test]
		public void Prevent_White_Pawn_Movement_Backwards()
		{
			var board = SetupBoard();
			var piece = Substitute.For<IChessPiece>();
			piece.Color.Returns(PieceColor.White);
			IRule rule = new ValidPawnMoveRule();

			Move move = new Move(piece, 0, 1, 0, 0);
			Assert.That(rule.IsMoveValid(board, move), Is.False);
		}

		[Test]
		public void Prevent_Black_Pawn_Movement_Backwards()
		{
			var board = SetupBoard();
			var piece = Substitute.For<IChessPiece>();
			piece.Color.Returns(PieceColor.Black);

			IRule rule = new ValidPawnMoveRule();

			Move move = new Move(piece, 0, 6, 0, 7);
			Assert.That(rule.IsMoveValid(board, move), Is.False);
        }

        [Test]
        public void Prevent_White_Pawn_Horizontal_Movement_Without_Capture()
        {
            var board = SetupBoard();
            var piece = Substitute.For<IChessPiece>();
            piece.Color.Returns(PieceColor.White);
            IRule rule = new ValidPawnMoveRule();

            Move move = new Move(piece, 0, 1, 1, 1);
            Assert.That(rule.IsMoveValid(board, move), Is.False);
        }

        [Test]
        public void Prevent_Black_Pawn_Horizontal_Movement_Without_Capture()
        {
            var board = SetupBoard();
            var piece = Substitute.For<IChessPiece>();
            piece.Color.Returns(PieceColor.Black);

            IRule rule = new ValidPawnMoveRule();

            Move move = new Move(piece, 0, 6, 1, 6);
            Assert.That(rule.IsMoveValid(board, move), Is.False);
        }

        [Test]
		public void Prevent_White_Pawn_Advancement_To_Occupied_Square()
		{
			var board = SetupBoard(2, PieceColor.Black);
			var piece = Substitute.For<IChessPiece>();
			piece.Color.Returns(PieceColor.White);

			IRule rule = new ValidPawnMoveRule();

			Move move = new Move(piece, 0, 1, 0, 2);
			Assert.That(rule.IsMoveValid(board, move), Is.False);
		}
		
		[Test]
		public void Prevent_Black_Pawn_Advancement_To_Occupied_Square()
		{
			var board = SetupBoard(5, PieceColor.White);
			var piece = Substitute.For<IChessPiece>();
			piece.Color.Returns(PieceColor.Black);

			IRule rule = new ValidPawnMoveRule();

			Move move = new Move(piece, 0, 6, 0, 5);
			Assert.That(rule.IsMoveValid(board, move), Is.False);
		}

		[Test]
		public void Prevent_White_Pawn_Advancement_By_More_Than_Two_Squares()
		{
			var board = SetupBoard();
			var piece = Substitute.For<IChessPiece>();
			piece.Color.Returns(PieceColor.White);

			IRule rule = new ValidPawnMoveRule();

			Move move = new Move(piece, 0, 1, 0, 4);
			Assert.That(rule.IsMoveValid(board, move), Is.False);
		}

		[Test]
		public void Prevent_Black_Pawn_Advancement_By_More_Than_Two_Squares()
		{
			var board = SetupBoard();
			var piece = Substitute.For<IChessPiece>();
			piece.Color.Returns(PieceColor.Black);

			IRule rule = new ValidPawnMoveRule();

			Move move = new Move(piece, 0, 6, 0, 3);
			Assert.That(rule.IsMoveValid(board, move), Is.False);
        }

        [Test]
        public void Allow_White_Pawn_Advancement_To_Unoccupied_Square()
        {
            var board = SetupBoard();
            var piece = Substitute.For<IChessPiece>();
            piece.Color.Returns(PieceColor.White);

            IRule rule = new ValidPawnMoveRule();

            Move move = new Move(piece, 0, 1, 0, 2);
            Assert.That(rule.IsMoveValid(board, move), Is.True);
        }

        [Test]
        public void Allow_Black_Pawn_Advancement_To_Unoccupied_Square()
        {
            var board = SetupBoard();
            var piece = Substitute.For<IChessPiece>();
            piece.Color.Returns(PieceColor.Black);

            IRule rule = new ValidPawnMoveRule();

            Move move = new Move(piece, 0, 7, 0, 6);
            Assert.That(rule.IsMoveValid(board, move), Is.True);
        }

        [Test]
		public void Allow_White_Double_Step_From_Home_Rank_To_Unoccupied_Square()
		{
			var board = SetupBoard();
			var piece = Substitute.For<IChessPiece>();
			piece.Color.Returns(PieceColor.White);

			IRule rule = new ValidPawnMoveRule();

			Move move = new Move(piece, 0, 1, 0, 3);
			Assert.That(rule.IsMoveValid(board, move), Is.True);
		}

		[Test]
		public void Allow_Black_Double_Step_From_Home_Rank_To_Unoccupied_Square()
		{
			var board = SetupBoard();
			var piece = Substitute.For<IChessPiece>();
			piece.Color.Returns(PieceColor.Black);

			IRule rule = new ValidPawnMoveRule();

			Move move = new Move(piece, 0, 6, 0, 4);
			Assert.That(rule.IsMoveValid(board, move), Is.True);
		}

		[Test]
		public void Prevent_White_Double_Step_From_Home_Rank_To_Occupied_Square()
		{
			var board = SetupBoard(3, PieceColor.Black);
			var piece = Substitute.For<IChessPiece>();
			piece.Color.Returns(PieceColor.White);

			IRule rule = new ValidPawnMoveRule();

			Move move = new Move(piece, 0, 1, 0, 3);
			Assert.That(rule.IsMoveValid(board, move), Is.False);
		}

		[Test]
		public void Prevent_Black_Double_Step_From_Home_Rank_To_Occupied_Square()
		{
			var board = SetupBoard(4, PieceColor.White);
			var piece = Substitute.For<IChessPiece>();
			piece.Color.Returns(PieceColor.Black);

			IRule rule = new ValidPawnMoveRule();

			Move move = new Move(piece, 0, 6, 0, 4);
			Assert.That(rule.IsMoveValid(board, move), Is.False);
		}

		[Test]
		public void Allow_White_Capture_Movement_On_Black_Occupied_Square()
		{
			var board = SetupBoard(2, PieceColor.Black);
			var piece = Substitute.For<IChessPiece>();
			piece.Color.Returns(PieceColor.White);

			IRule rule = new ValidPawnMoveRule();

			Move leftCapture = new Move(piece, 1, 1, 0, 2);
			Assert.That(rule.IsMoveValid(board, leftCapture), Is.True);
            Move rightCapture = new Move(piece, 1, 1, 2, 2);
			Assert.That(rule.IsMoveValid(board, rightCapture), Is.True);
		}

		[Test]
		public void Allow_Black_Capture_Movement_On_White_Occupied_Square()
		{
			var board = SetupBoard(6, PieceColor.White);
			var piece = Substitute.For<IChessPiece>();
			piece.Color.Returns(PieceColor.Black);

			IRule rule = new ValidPawnMoveRule();

			Move leftCapture = new Move(piece, 1, 7, 0, 6);
			Assert.That(rule.IsMoveValid(board, leftCapture), Is.True);
            Move rightCapture = new Move(piece, 1, 7, 2, 6);
			Assert.That(rule.IsMoveValid(board, rightCapture), Is.True);
		}

		[Test]
		public void Prevent_White_Capture_Movement_On_Unoccupied_Square_Without_En_Passant()
		{
			var board = SetupBoard(4, PieceColor.Black);
			var piece = Substitute.For<IChessPiece>();
			piece.Color.Returns(PieceColor.White);

			IRule rule = new ValidPawnMoveRule();

			Move leftCapture = new Move(piece, 1, 4, 0, 5);
			Assert.That(rule.IsMoveValid(board, leftCapture), Is.False);
			Move rightCapture = new Move(piece, 1, 4, 3, 5);
			Assert.That(rule.IsMoveValid(board, rightCapture), Is.False);
		}

		[Test]
		public void Prevent_Black_Capture_Movement_On_Unoccupied_Square_Without_En_Passant()
		{
			var board = SetupBoard(3, PieceColor.White);
			var piece = Substitute.For<IChessPiece>();
			piece.Color.Returns(PieceColor.Black);

			IRule rule = new ValidPawnMoveRule();

			Move leftCapture = new Move(piece, 1, 3, 0, 2);
			Assert.That(rule.IsMoveValid(board, leftCapture), Is.False);
			Move rightCapture = new Move(piece, 1, 3, 3, 2);
			Assert.That(rule.IsMoveValid(board, rightCapture), Is.False);
		}

		[Test]
		public void Allow_White_En_Passant()
		{
			var board = SetupBoard(4, PieceColor.Black, 2);
			var piece = Substitute.For<IChessPiece>();
			piece.Color.Returns(PieceColor.White);

			IRule rule = new ValidPawnMoveRule();

			Move leftCapture = new Move(piece, 1, 4, 0, 5);
			Assert.That(rule.IsMoveValid(board, leftCapture), Is.True);
			Move rightCapture = new Move(piece, 1, 4, 2, 5);
			Assert.That(rule.IsMoveValid(board, rightCapture), Is.True);
		}

		[Test]
		public void Allow_Black_En_Passant()
		{
			var board = SetupBoard(3, PieceColor.White, 2);
			var piece = Substitute.For<IChessPiece>();
			piece.Color.Returns(PieceColor.Black);

			IRule rule = new ValidPawnMoveRule();

			Move leftCapture = new Move(piece, 1, 3, 0, 2);
			Assert.That(rule.IsMoveValid(board, leftCapture), Is.True);
			Move rightCapture = new Move(piece, 1, 3, 2, 2);
			Assert.That(rule.IsMoveValid(board, rightCapture), Is.True);
		}

		[Test]
		public void Prevent_White_Capture_On_Double_Step()
		{
			var board = SetupBoard(3, PieceColor.Black);
			var piece = Substitute.For<IChessPiece>();
			piece.Color.Returns(PieceColor.White);

			IRule rule = new ValidPawnMoveRule();

			Move leftCapture = new Move(piece, 1, 1, 0, 3);
			Assert.That(rule.IsMoveValid(board, leftCapture), Is.False);
			Move rightCapture = new Move(piece, 1, 1, 2, 3);
			Assert.That(rule.IsMoveValid(board, rightCapture), Is.False);
		}

		[Test]
		public void Prevent_Black_Capture_On_Double_Step()
		{
			var board = SetupBoard(4, PieceColor.White);
			var piece = Substitute.For<IChessPiece>();
			piece.Color.Returns(PieceColor.Black);

			IRule rule = new ValidPawnMoveRule();

			Move leftCapture = new Move(piece, 1, 6, 0, 4);
			Assert.That(rule.IsMoveValid(board, leftCapture), Is.False);
			Move rightCapture = new Move(piece, 1, 6, 2, 4);
			Assert.That(rule.IsMoveValid(board, rightCapture), Is.False);
		}

		[Test]
		public void Prevent_White_Advancement_By_Greater_Than_One_Square_When_Off_Home_Rank()
		{
			var board = SetupBoard();
			var piece = Substitute.For<IChessPiece>();
			piece.Color.Returns(PieceColor.White);

			IRule rule = new ValidPawnMoveRule();

			Move move = new Move(piece, 0, 2, 0, 4);
			Assert.That(rule.IsMoveValid(board, move), Is.False);
		}

		[Test]
		public void Prevent_Black_Advancement_By_Greater_Than_One_Square_When_Off_Home_Rank()
		{
			var board = SetupBoard();
			var piece = Substitute.For<IChessPiece>();
			piece.Color.Returns(PieceColor.Black);

			IRule rule = new ValidPawnMoveRule();

			Move move = new Move(piece, 0, 5, 0, 3);
			Assert.That(rule.IsMoveValid(board, move), Is.False);
		}

		private IChessBoard SetupBoard(int occupyRow =-1, PieceColor color = PieceColor.Black, int turn = 3)
		{
			var board = Substitute.For<IChessBoard>();
			if(occupyRow == -1)
			{
				UnoccupyBoard(board);
			}
			else
			{
				OccupyRow(board, color, occupyRow);
			}
			board.CurrentTurn.Returns(turn);
            board.Height.Returns(8);

            return board;
		}

		private void OccupyRow(IChessBoard board, PieceColor color, int y)
		{
			IChessPiece outVar = null;

			var occupier = Substitute.For<IPawn>();
			occupier.Color.Returns(color);
			occupier.FirstMovedOn.Returns(1);

			board.TryGetPieceOn(Arg.Any<int>(), y, out outVar).Returns(args => {
				args[2] = occupier;
				return true;
			});

			board.TryGetPieceOn(Arg.Any<int>(), Arg.Is<int>(y1 => y1!=y), out outVar).Returns(args => {
				args[2] = null;
				return false;
			});
		}

		private void UnoccupyBoard(IChessBoard board)
		{
			IChessPiece outVar = null;
			
			board.TryGetPieceOn(Arg.Any<int>(), Arg.Any<int>(), out outVar).Returns(args => {
				args[2] = null;
				return false;
			});
		}
	}
}
