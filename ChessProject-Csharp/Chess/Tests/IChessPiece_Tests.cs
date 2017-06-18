using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring {
    [TestFixture]
    public abstract class IChessPiece_Tests {
        protected ChessBoard _chessBoard;
        protected abstract IChessPiece GetPiece(PieceColor color);
        protected IChessPiece _chessPiece;

        [SetUp]
        public void SetUp()
        {
            _chessBoard = new ChessBoard();
            _chessPiece = GetPiece(PieceColor.Black);
        }

        [Test]
        public void ChessBoard_Add_Sets_XCoordinate()
        {
            _chessBoard.AddPiece(_chessPiece, 6, 3);
            Assert.That(_chessPiece.XCoordinate, Is.EqualTo(6));
        }

        [Test]
        public void ChessBoard_Add_Sets_YCoordinate()
        {
            _chessBoard.AddPiece(_chessPiece, 6, 3);
            Assert.That(_chessPiece.YCoordinate, Is.EqualTo(3));
        }
    }
}
