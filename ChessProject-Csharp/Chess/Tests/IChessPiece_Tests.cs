using NSubstitute;
using NUnit.Framework;

namespace Gfi.Hiring {
    [TestFixture]
    public abstract class IChessPiece_Tests {
        protected IChessBoard _chessBoard;
        protected abstract IChessPiece CreatePiece(PieceType type, PieceColor color);
        protected IChessPiece _chessPiece;

        [SetUp]
        public void SetUp()
        {
            _chessBoard = Substitute.For<IChessBoard>();
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
            _chessBoard.Add(Arg.Any<IChessPiece>(),
                    Arg.Do<int>(x => piece.XCoordinate = x),
                    Arg.Do<int>(y => piece.YCoordinate = y),
                    piece.Color).Returns(true).AndDoes(x => piece.SetBoard(_chessBoard));
            _chessBoard.IsMoveValid(Arg.Any<Move>()).Returns(true);

            _chessBoard.Add(piece, 3, 6, piece.Color);
            piece.Move(MovementType.Move, 2, 6);
            Assert.That(piece.XCoordinate, Is.EqualTo(2));
        }

        [Test]
        public void ChessPiece_Move_Sets_Y_Coordinate_For_Valid_Move()
        {
            IChessPiece piece = CreatePiece(PieceType.Pawn, PieceColor.Black);
            _chessBoard.Add(Arg.Any<IChessPiece>(),
                    Arg.Do<int>(x => piece.XCoordinate = x),
                    Arg.Do<int>(y => piece.YCoordinate = y),
                    piece.Color).Returns(true).AndDoes(x => piece.SetBoard(_chessBoard));
            _chessBoard.IsMoveValid(Arg.Any<Move>()).Returns(true);

            _chessBoard.Add(piece, 3, 6, piece.Color);
            piece.Move(MovementType.Move, 3, 4);
            Assert.That(piece.YCoordinate, Is.EqualTo(4));
        }

        [Test]
        public void ChessPiece_Move_Returns_False_On_Rule_Violation()
        {
            var failRule = Substitute.For<IRule>();
            IChessPiece piece = new ChessPiece(PieceType.Pawn, PieceColor.Black);

            failRule.IsMoveValid(_chessBoard, null).ReturnsForAnyArgs(false);
            _chessBoard.Add(Arg.Any<IChessPiece>(),
                    Arg.Do<int>(x => piece.XCoordinate = x),
                    Arg.Do<int>(y => piece.YCoordinate = y),
                    piece.Color).Returns(true).AndDoes(x => piece.SetBoard(_chessBoard));
            _chessBoard.IsMoveValid(Arg.Any<Move>()).Returns(false);

            _chessBoard.Add(piece, 0, 0, piece.Color);
            Assert.That(piece.Move(MovementType.Move, 1, 1), Is.False);
        }

        [Test]
        public void ChessPiece_Does_Not_Move_On_Rule_Violation()
        {
            IChessPiece piece = new ChessPiece(PieceType.Pawn, PieceColor.Black);            
            _chessBoard.Add(Arg.Any<IChessPiece>(),
                    Arg.Do<int>(x => piece.XCoordinate = x),
                    Arg.Do<int>(y => piece.YCoordinate = y),
                    piece.Color).Returns(true).AndDoes(x => piece.SetBoard(_chessBoard));            
            _chessBoard.IsMoveValid(Arg.Any<Move>()).Returns(false);

            _chessBoard.Add(piece, 0, 0, piece.Color);
            piece.Move(MovementType.Move, 1, 1);

            Assert.That(piece.XCoordinate, Is.EqualTo(0));
            Assert.That(piece.YCoordinate, Is.EqualTo(0));
        }
    }
}
