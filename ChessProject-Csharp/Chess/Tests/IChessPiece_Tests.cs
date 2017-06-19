using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring {
    [TestFixture]
    public abstract class IChessPiece_Tests {
        protected IChessBoard _chessBoard;
        protected abstract IChessPiece GetPiece(PieceColor color);
        protected IChessPiece _chessPiece;

        [SetUp]
        public void SetUp()
        {
            _chessBoard = Substitute.For<IChessBoard>();
            _chessPiece = GetPiece(PieceColor.Black);
        }
    }
}
