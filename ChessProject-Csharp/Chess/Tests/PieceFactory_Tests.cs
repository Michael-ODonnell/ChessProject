using NUnit.Framework;

namespace Gfi.Hiring {
    internal class PieceFactory_Tests {

        protected PieceFactory _pieceFactory;

        [SetUp]
        public void SetUp()
        {
            _pieceFactory = new PieceFactory(NSubstitute.Substitute.For<IChessBoard>());
        }

        [Test]
        public void TestPawnCreationIsNotNull()
        {
            IChessPiece piece = _pieceFactory.Build(PieceType.Pawn, PieceColor.Black);
            Assert.That(piece, Is.Not.Null);
        }
        [Test]
        public void TestPawnImplementsIPawn()
        {
            IChessPiece piece = _pieceFactory.Build(PieceType.Pawn, PieceColor.Black);
            Assert.That(piece as IPawn, Is.Not.Null);
        }
        [Test]
        public void TestPawnTypeCorrectlyAssigned()
        {
            IChessPiece piece = _pieceFactory.Build(PieceType.Pawn, PieceColor.Black);
            Assert.That(PieceType.Pawn, Is.EqualTo(piece.Type));
        }
        [Test]
        public void TestBlackPawnColorCorrectlyAssigned()
        {
            IChessPiece piece = _pieceFactory.Build(PieceType.Pawn, PieceColor.Black);
            Assert.That(PieceColor.Black, Is.EqualTo(piece.Color));
        }
        [Test]
        public void TestWhitePawnColorCorrectlyAssigned()
        {
            IChessPiece piece = _pieceFactory.Build(PieceType.Pawn, PieceColor.White);
            Assert.That(PieceColor.White, Is.EqualTo(piece.Color));
        }
    }
}
