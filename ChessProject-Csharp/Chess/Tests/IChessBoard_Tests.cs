using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring {
    [TestFixture]
    public abstract class IChessBoard_Tests {
        protected IChessBoard _chessBoard;
        protected abstract IChessBoard GetBoard();

        [SetUp]
        public void SetUp()
        {
            _chessBoard = GetBoard();
        }

        [Test]
        public void IsLegalBoardPosition_False_For_X_Values_Greater_Than_Board_Width()
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(_chessBoard.Width, 0);
            Assert.That(isValidPosition, Is.False);
        }

        [Test]
        public void IsLegalBoardPosition_False_For_Y_Values_Greater_Than_Board_Height()
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(0, _chessBoard.Height);
            Assert.That(isValidPosition, Is.False);
        }

        [Test]
        public void IsLegalBoardPosition_False_For_Negative_X_Values()
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(-1, 0);
            Assert.That(isValidPosition, Is.False);
        }

        [Test]
        public void IsLegalBoardPosition_False_For_Negative_Y_Values()
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(0, -1);
            Assert.That(isValidPosition, Is.False);
        }

        [Test]
        public void Avoids_Duplicate_Positioning()
        {
            IChessPiece firstPawn = Substitute.For<IChessPiece>();
            IChessPiece secondPawn = Substitute.For<IChessPiece>();
            _chessBoard.AddPiece(firstPawn, 0, 0);
            _chessBoard.AddPiece(secondPawn, 0, 0);
            Assert.That(firstPawn.XCoordinate, Is.EqualTo(0));
            Assert.That(firstPawn.YCoordinate, Is.EqualTo(0));
            Assert.That(secondPawn.XCoordinate, Is.EqualTo(-1));
            Assert.That(secondPawn.YCoordinate, Is.EqualTo(-1));
        }

        [Test]
        public void Limits_The_Number_Of_Pawns()
        {
            for (int i = 0; i < 10; i++)
            {
                var pawn = Substitute.For<IChessPiece>();
                int row = i / _chessBoard.Width;
                _chessBoard.AddPiece(pawn, row, i % _chessBoard.Width);
                if (row < 1)
                {
                    Assert.That(pawn.XCoordinate, Is.EqualTo(row));
                    Assert.That(pawn.YCoordinate, Is.EqualTo(i % _chessBoard.Width));
                }
                else
                {
                    Assert.That(pawn.XCoordinate, Is.EqualTo(-1));
                    Assert.That(pawn.YCoordinate, Is.EqualTo(-1));
                }
            }
        }

        [Test]
        public void Get_Piece_Added_To_Position()
        {
            var pawn = Substitute.For<IChessPiece>();
            _chessBoard.AddPiece(pawn, 0, 0);
            IChessPiece piece;
            Assert.IsTrue(_chessBoard.TryGetPieceOn(0, 0, out piece));
            Assert.That(piece, Is.SameAs(pawn));
        }

        [Test]
        public void Try_Get_Piece_On_Empty_Square_Returns_False()
        {
            var pawn = Substitute.For<IChessPiece>();
            _chessBoard.AddPiece(pawn, 0, 0);
            IChessPiece piece;
            Assert.IsFalse(_chessBoard.TryGetPieceOn(1, 0, out piece));
        }

        [Test]
        public void Try_Get_Piece_On_Empty_Square_Out_Param_Is_Null()
        {
            var pawn = Substitute.For<IChessPiece>();
            _chessBoard.AddPiece(pawn, 0, 0);
            IChessPiece piece;
            _chessBoard.TryGetPieceOn(1, 0, out piece);
            Assert.IsNull(piece);
        }
    }
}
