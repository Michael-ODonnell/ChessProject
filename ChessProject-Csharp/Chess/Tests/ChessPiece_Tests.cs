using NSubstitute;
using NUnit.Framework;

namespace Gfi.Hiring {
    [TestFixture]
	public class ChessPiece_Tests : IChessPiece_Tests {
		
		protected override IChessPiece GetPiece(PieceColor color)
		{
			return CreatePiece(PieceType.Pawn, color);
		}

		protected ChessPiece CreatePiece (PieceType type, PieceColor color, IRule[] rules = null)
		{
			if(rules == null)
			{
				rules = new IRule[1];
				rules[0] = new MoveEndpointOnBoardRule();

			}
			return new ChessPiece(_chessBoard, type, color, rules);
		}

		[Test]
		public void Color_Correct_On_New_Black_Piece()
		{
			IChessPiece piece = CreatePiece(PieceType.Pawn, PieceColor.Black);
			Assert.That(piece.Color, Is.EqualTo(PieceColor.Black));
		}

		[Test]
		public void Color_Correct_On_New_White_Piece()
		{
			IChessPiece piece = CreatePiece(PieceType.Pawn, PieceColor.Black);
			Assert.That(piece.Color, Is.EqualTo(PieceColor.Black));
		}

		[Test]
		public void New_Pawn_Type_Is_Pawn()
		{
			IChessPiece piece = CreatePiece(PieceType.Pawn, PieceColor.Black);
			Assert.That(piece.Type, Is.EqualTo(PieceType.Pawn));
		}

		[Test]
		public void New_ChessPiece_X_Coordinate_Off_Board()
		{
			IChessPiece piece = CreatePiece(PieceType.Pawn, PieceColor.Black);
			Assert.That(piece.XCoordinate, Is.EqualTo(ChessBoard.OffBoardCoordinate));
		}

		[Test]
		public void New_ChessPiece_Y_Coordinate_Off_Board()
		{
			IChessPiece piece = CreatePiece(PieceType.Pawn, PieceColor.Black);
			Assert.That(piece.YCoordinate, Is.EqualTo(ChessBoard.OffBoardCoordinate));
		}

		[Test]
		public void ChessPiece_Set_X_Coordinate()
		{
			IChessPiece piece = CreatePiece(PieceType.Pawn, PieceColor.Black);
			piece.XCoordinate = 0;
			Assert.That(piece.XCoordinate, Is.EqualTo(0));
		}

		[Test]
		public void ChessPiece_Set_Y_Coordinate()
		{
			IChessPiece piece = CreatePiece(PieceType.Pawn, PieceColor.Black);
			piece.YCoordinate = 0;
			Assert.That(piece.YCoordinate, Is.EqualTo(0));
		}

		[Test]
		public void ChessPiece_Move_Sets_X_Coordinate_For_Valid_Move()
        {
            IChessPiece piece = CreatePiece(PieceType.Pawn, PieceColor.Black);
            _chessBoard.AddPiece(Arg.Any<IChessPiece>(),
                    Arg.Do<int>(x => piece.XCoordinate = x), 
                    Arg.Do<int>(y => piece.YCoordinate = y)).Returns(true);

            _chessBoard.AddPiece(piece, 3, 6);
			piece.Move(3, 4);
			Assert.That(piece.XCoordinate, Is.EqualTo(3));
		}

		[Test]
		public void ChessPiece_Move_Sets_Y_Coordinate_For_Valid_Move()
        {
            IChessPiece piece = CreatePiece(PieceType.Pawn, PieceColor.Black);
            _chessBoard.AddPiece(Arg.Any<IChessPiece>(),
                    Arg.Do<int>(x => piece.XCoordinate = x),
                    Arg.Do<int>(y => piece.YCoordinate = y)).Returns(true);
            _chessBoard.IsLegalBoardPosition(1,1).ReturnsForAnyArgs(true);

            _chessBoard.AddPiece(piece, 3, 6);
			bool didMove = piece.Move(3, 4);
			Assert.That(piece.YCoordinate, Is.EqualTo(4));
		}

		[Test]
		public void ChessPiece_Move_Returns_False_On_Rule_Violation()
		{
			var failRule = Substitute.For<IRule>();
			var board = Substitute.For<IChessBoard>();
			IChessPiece piece = new ChessPiece(board, PieceType.Pawn, PieceColor.Black, new IRule[1] { failRule });

			failRule.IsMoveValid(board, null).ReturnsForAnyArgs(false);
			board.AddPiece(Arg.Any<IChessPiece>(), 
				Arg.Do<int>(x => piece.XCoordinate = x), 
				Arg.Do<int>(y => piece.YCoordinate = y));

			board.IsLegalBoardPosition(Arg.Any<int>(), Arg.Any<int>()).Returns(true);

			board.AddPiece(piece, 0, 0);            
			Assert.That(piece.Move(1, 1), Is.False);
		}

		[Test]
		public void ChessPiece_Does_Not_Move_On_Rule_Violation()
		{
			var failRule = Substitute.For<IRule>();
			var board = Substitute.For<IChessBoard>();
			IChessPiece piece = new ChessPiece(board, PieceType.Pawn, PieceColor.Black, new IRule[1] { failRule });

			failRule.IsMoveValid(board, null).ReturnsForAnyArgs(false);
			board.AddPiece(Arg.Any<IChessPiece>(),
				Arg.Do<int>(x => piece.XCoordinate = x),
				Arg.Do<int>(y => piece.YCoordinate = y));

			board.IsLegalBoardPosition(Arg.Any<int>(), Arg.Any<int>()).Returns(true);

			board.AddPiece(piece, 0, 0);
			piece.Move(1, 1);

			Assert.That(piece.XCoordinate, Is.EqualTo(0));
			Assert.That(piece.YCoordinate, Is.EqualTo(0));
		}
	}
}
