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
            Assert.IsNotNull(piece);
        }
        [Test]
        public void TestPawnImplementsIPawn()
        {
            IChessPiece piece = _pieceFactory.Build(PieceType.Pawn, PieceColor.Black);
            Assert.IsNotNull(piece as IPawn);
        }
        [Test]
        public void TestPawnTypeCorrectlyAssigned()
        {
            IChessPiece piece = _pieceFactory.Build(PieceType.Pawn, PieceColor.Black);
            Assert.AreEqual(PieceType.Pawn, piece.Type);
        }
        [Test]
        public void TestBlackPawnColorCorrectlyAssigned()
        {
            IChessPiece piece = _pieceFactory.Build(PieceType.Pawn, PieceColor.Black);
            Assert.AreEqual(PieceColor.Black, piece.Color);
        }
        [Test]
        public void TestWhitePawnColorCorrectlyAssigned()
        {
            IChessPiece piece = _pieceFactory.Build(PieceType.Pawn, PieceColor.White);
            Assert.AreEqual(PieceColor.White, piece.Color);
        }
    }
}
