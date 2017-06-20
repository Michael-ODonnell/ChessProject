using NSubstitute;
using NUnit.Framework;

namespace Gfi.Hiring {
    [TestFixture]
    public abstract class IPawn_Tests {
        protected IChessBoard _chessBoard;
        protected abstract IPawn GetPawn(PieceColor color);
        protected IPawn _pawn;

        [SetUp]
        public void SetUp()
        {
            _chessBoard = Substitute.For<IChessBoard>();
            _pawn = GetPawn(PieceColor.Black);
        }

        [Test]
        public void First_Move_Is_Zero_Before_First_Move()
        {
            _chessBoard.CurrentTurn.Returns(2);
            Assert.That(_pawn.FirstMovedOn, Is.EqualTo(0));
        }

        [Test]
        public void First_Move_Sets_First_Move_Property()
        {
            _chessBoard.Add(Arg.Any<IChessPiece>(),
                Arg.Any<int>(), Arg.Any<int>(), Arg.Any<PieceColor>()
                ).Returns(true).AndDoes(x => _pawn.SetBoard(_chessBoard));
            _chessBoard.Add(_pawn, 1, 1, _pawn.Color);

            _chessBoard.CurrentTurn.Returns(2);
            _pawn.Move(MovementType.Move, 1, 3);
            Assert.That(_pawn.FirstMovedOn, Is.EqualTo(2));
        }

        [Test]
        public void Additional_Moves_Do_Not_Update_First_Move_Property()
        {
            _chessBoard.Add(Arg.Any<IChessPiece>(),
                Arg.Any<int>(), Arg.Any<int>(), Arg.Any<PieceColor>()
                ).Returns(true).AndDoes(x => _pawn.SetBoard(_chessBoard));

            _chessBoard.CurrentTurn.Returns(2);
            _chessBoard.Add(_pawn, 1, 1, _pawn.Color);
            _pawn.Move(MovementType.Move, 1, 3);
            _chessBoard.CurrentTurn.Returns(3);
            _pawn.Move(MovementType.Move, 1, 4);
            Assert.That(_pawn.FirstMovedOn, Is.EqualTo(2));
        }
    }
}
