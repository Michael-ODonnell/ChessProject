using NSubstitute;
using NUnit.Framework;

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
        public void IsLegalBoardPosition_True_For_Valid_Max_X_Values()
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(0, 0);
            Assert.That(isValidPosition, Is.True);
        }

        [Test]
        public void IsLegalBoardPosition_True_For_Valid_Min_X_Values()
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(_chessBoard.Width - 1, 0);
            Assert.That(isValidPosition, Is.True);
        }

        [Test]
        public void IsLegalBoardPosition_True_For_Valid_Max_Y_Values()
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(0, _chessBoard.Height - 1);
            Assert.That(isValidPosition, Is.True);
        }

        [Test]
        public void IsLegalBoardPosition_True_For_Valid_Min_Y_Values()
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(0, 0);
            Assert.That(isValidPosition, Is.True);
        }

        [Test]
        public void Avoids_Duplicate_Positioning()
        {
            IChessPiece firstPawn = Substitute.For<IChessPiece>();
            IChessPiece secondPawn = Substitute.For<IChessPiece>();
            _chessBoard.Add(firstPawn, 0, 0, firstPawn.Color);
            _chessBoard.Add(secondPawn, 0, 0, secondPawn.Color);
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
                int row = i / _chessBoard.Settings().MaxPawnsPerSide;
                _chessBoard.Add(pawn, row, i % _chessBoard.Width, pawn.Color);
                if (row < 1)
                {
                    Assert.That(pawn.XCoordinate, Is.EqualTo(row));
                    Assert.That(pawn.YCoordinate, Is.EqualTo(i % _chessBoard.Settings().MaxPawnsPerSide));
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
            _chessBoard.Add(pawn, 0, 0, pawn.Color);
            IChessPiece piece;
            Assert.That(_chessBoard.TryGetPieceOn(0, 0, out piece), Is.True);
            Assert.That(piece, Is.SameAs(pawn));
        }

        [Test]
        public void Try_Get_Piece_On_Empty_Square_Returns_False()
        {
            var pawn = Substitute.For<IChessPiece>();
            _chessBoard.Add(pawn, 0, 0, pawn.Color);
            IChessPiece piece;
            Assert.That(_chessBoard.TryGetPieceOn(1, 0, out piece), Is.False);
        }

        [Test]
        public void Try_Get_Piece_On_Empty_Square_Out_Param_Is_Null()
        {
            var pawn = Substitute.For<IChessPiece>();
            _chessBoard.Add(pawn, 0, 0, pawn.Color);
            IChessPiece piece;
            _chessBoard.TryGetPieceOn(1, 0, out piece);
            Assert.That(piece, Is.Null);
        }

        #region Path Tests

        [Test]
        public void Is_Straight_Clear_Path_Between_Returns_True_On_Clear_Path_X_Equals_C()
        {
            var pawn = Substitute.For<IChessPiece>();
            _chessBoard.Add(pawn, 0, 0, pawn.Color);
            Assert.That(_chessBoard.IsStraightClearPathBetween(pawn.XCoordinate, pawn.YCoordinate, pawn.XCoordinate, _chessBoard.Height - 1), Is.True);

        }
        [Test]
        public void Is_Straight_Clear_Path_Between_Returns_True_On_Clear_Path_X_Equals_C_Inverted()
        {
            var pawn = Substitute.For<IChessPiece>();
            _chessBoard.Add(pawn, 1, _chessBoard.Height - 1, pawn.Color);
            Assert.That(_chessBoard.IsStraightClearPathBetween(pawn.XCoordinate, pawn.YCoordinate, pawn.XCoordinate, 0), Is.True);
        }

        [Test]
        public void Is_Straight_Clear_Path_Between_Returns_False_On_Blocked_Path_X_Equals_C()
        {
            var pawn = Substitute.For<IChessPiece>();
            var blocker = Substitute.For<IChessPiece>();

            _chessBoard.Add(pawn, 0, 0, pawn.Color);
            _chessBoard.Add(blocker, 0, 1, pawn.Color);

            Assert.That(_chessBoard.IsStraightClearPathBetween(pawn.XCoordinate, pawn.YCoordinate, pawn.XCoordinate, _chessBoard.Height - 1), Is.False);
        }

        [Test]
        public void Is_Straight_Clear_Path_Between_Returns_False_On_Blocked_Path_X_Equals_C_Inverted()
        {
            var pawn = Substitute.For<IChessPiece>();
            var blocker = Substitute.For<IChessPiece>();
            _chessBoard.Add(pawn, 1, _chessBoard.Height - 1, pawn.Color);
            _chessBoard.Add(blocker, 1, 1, blocker.Color);
            Assert.That(_chessBoard.IsStraightClearPathBetween(pawn.XCoordinate, pawn.YCoordinate, pawn.XCoordinate, 0), Is.False);
        }

        [Test]
        public void Is_Straight_Clear_Path_Between_Returns_True_On_Clear_Path_Y_Equals_C()
        {
            var pawn = Substitute.For<IChessPiece>();
            _chessBoard.Add(pawn, 0, 0, pawn.Color);
            Assert.That(_chessBoard.IsStraightClearPathBetween(pawn.XCoordinate, pawn.YCoordinate, _chessBoard.Width - 1, pawn.YCoordinate), Is.True);

        }
        [Test]
        public void Is_Straight_Clear_Path_Between_Returns_True_On_Clear_Path_Y_Equals_C_Inverted()
        {
            var pawn = Substitute.For<IChessPiece>();
            _chessBoard.Add(pawn, _chessBoard.Width - 1, 1, pawn.Color);
            Assert.That(_chessBoard.IsStraightClearPathBetween(pawn.XCoordinate, pawn.YCoordinate, 0, pawn.YCoordinate), Is.True);
        }

        [Test]
        public void Is_Straight_Clear_Path_Between_Returns_False_On_Blocked_Path_Y_Equals_C()
        {
            var pawn = Substitute.For<IChessPiece>();
            var blocker = Substitute.For<IChessPiece>();

            _chessBoard.Add(pawn, 0, 0, pawn.Color);
            _chessBoard.Add(blocker, 1, 0, blocker.Color);

            Assert.That(_chessBoard.IsStraightClearPathBetween(pawn.XCoordinate, pawn.YCoordinate, _chessBoard.Width - 1, pawn.YCoordinate), Is.False);
        }

        [Test]
        public void Is_Straight_Clear_Path_Between_Returns_False_On_Blocked_Path_Y_Equals_C_Inverted()
        {
            var pawn = Substitute.For<IChessPiece>();
            var blocker = Substitute.For<IChessPiece>();
            _chessBoard.Add(pawn, _chessBoard.Width - 1, 1, pawn.Color);
            _chessBoard.Add(blocker, 1, 1, blocker.Color);
            Assert.That(_chessBoard.IsStraightClearPathBetween(pawn.XCoordinate, pawn.YCoordinate, 0, pawn.YCoordinate), Is.False);
        }

        [Test]
        public void Is_Straight_Clear_Path_Between_Returns_True_On_Clear_Path_X_Equals_Y()
        {
            var pawn = Substitute.For<IChessPiece>();
            _chessBoard.Add(pawn, 0, 0, pawn.Color);
            Assert.That(_chessBoard.IsStraightClearPathBetween(pawn.XCoordinate, pawn.YCoordinate, _chessBoard.Width - 1, _chessBoard.Width - 1), Is.True);
        }

        [Test]
        public void Is_Straight_Clear_Path_Between_Returns_False_On_Blocked_Path_X_Equals_Y()
        {
            var pawn = Substitute.For<IChessPiece>();
            var blocker = Substitute.For<IChessPiece>();

            _chessBoard.Add(pawn, 0, 0, pawn.Color);
            _chessBoard.Add(blocker, 1, 1, blocker.Color);

            Assert.That(_chessBoard.IsStraightClearPathBetween(pawn.XCoordinate, pawn.YCoordinate, _chessBoard.Width - 1, _chessBoard.Width - 1), Is.False);
        }

        [Test]
        public void Is_Straight_Clear_Path_Between_Returns_False_On_Blocked_Path_X_Equals_Y_inverted()
        {
            var pawn = Substitute.For<IChessPiece>();
            var blocker = Substitute.For<IChessPiece>();
            _chessBoard.Add(pawn, _chessBoard.Width - 1, _chessBoard.Width - 1, pawn.Color);
            _chessBoard.Add(blocker, 1, 1, blocker.Color);
            Assert.That(_chessBoard.IsStraightClearPathBetween(pawn.XCoordinate, pawn.YCoordinate, 0, 0), Is.False);
        }

        [Test]
        public void Is_Straight_Clear_Path_Between_Returns_False_On_Blocked_Path_X_Equals_Minus_Y()
        {
            var pawn = Substitute.For<IChessPiece>();
            var blocker = Substitute.For<IChessPiece>();

            _chessBoard.Add(pawn, 0, _chessBoard.Width - 1, pawn.Color);
            _chessBoard.Add(blocker, 1, _chessBoard.Width - 2, blocker.Color);

            Assert.That(_chessBoard.IsStraightClearPathBetween(pawn.XCoordinate, pawn.YCoordinate, _chessBoard.Width - 1, 0), Is.False);
        }

        [Test]
        public void Is_Straight_Clear_Path_Between_Returns_False_On_Blocked_Path_X_Equals_Minus_Y_Inverted()
        {
            var pawn = Substitute.For<IChessPiece>();
            var blocker = Substitute.For<IChessPiece>();
            _chessBoard.Add(pawn, _chessBoard.Width - 1, 0, pawn.Color);
            _chessBoard.Add(blocker, 1, _chessBoard.Width - 2, blocker.Color);
            Assert.That(_chessBoard.IsStraightClearPathBetween(pawn.XCoordinate, pawn.YCoordinate, 0, _chessBoard.Width), Is.False);
        }

        [Test]
        public void Is_Straight_Clear_Path_Between_Returns_False_On_Unaligned_Paths()
        {
            var pawn = Substitute.For<IChessPiece>();
            var blocker = Substitute.For<IChessPiece>();
            _chessBoard.Add(pawn, 0, 0, pawn.Color);
            Assert.That(_chessBoard.IsStraightClearPathBetween(pawn.XCoordinate, pawn.YCoordinate, pawn.XCoordinate + 1, pawn.YCoordinate + 2), Is.False);
            Assert.That(_chessBoard.IsStraightClearPathBetween(pawn.XCoordinate, pawn.YCoordinate, pawn.XCoordinate + 2, pawn.YCoordinate + 1), Is.False);
        }
        #endregion

        [Test]
        public void Update_Board_Removes_Piece_From_Old_Position()
        {
            var pawn = Substitute.For<IChessPiece>();
            _chessBoard.Add(pawn, 0, 1, pawn.Color);
            _chessBoard.UpdateBoard(new Move(pawn, 0, 1, 0, 3));

            IChessPiece foundPiece;
            Assert.That(_chessBoard.TryGetPieceOn(0, 1, out foundPiece), Is.False);
            Assert.That(foundPiece, Is.Null);
        }

        [Test]
        public void Update_Board_Adds_Piece_To_New_Position()
        {
            var pawn = Substitute.For<IChessPiece>();
            _chessBoard.Add(pawn, 0, 1, pawn.Color);
            _chessBoard.UpdateBoard(new Move(pawn, 0, 1, 0, 3));

            IChessPiece foundPiece;
            Assert.That(_chessBoard.TryGetPieceOn(0, 3, out foundPiece), Is.True);
            Assert.That(pawn, Is.SameAs(foundPiece));
        }

        [Test]
        public void Update_Board_Removes_Captured_Piece_From_Board()
        {
            var piece = Substitute.For<IChessPiece>();
            _chessBoard.Add(piece, 0, 1, piece.Color);
            var capturedPiece = Substitute.For<IChessPiece>();
            _chessBoard.Add(capturedPiece, 1, 2, capturedPiece.Color);
            _chessBoard.UpdateBoard(new Move(piece, 0, 1, 1, 2));

            Assert.That(ChessBoard.OffBoardCoordinate, Is.EqualTo(capturedPiece.XCoordinate));
            Assert.That(ChessBoard.OffBoardCoordinate, Is.EqualTo(capturedPiece.YCoordinate));
        }

        [Test]
        public void Add_Sets_XCoordinate()
        {
            var piece = Substitute.For<IChessPiece>();

            _chessBoard.Add(piece, 6, 3, piece.Color);
            Assert.That(piece.XCoordinate, Is.EqualTo(6));
        }

        [Test]
        public void Add_Sets_YCoordinate()
        {
            var piece = Substitute.For<IChessPiece>();

            _chessBoard.Add(piece, 6, 3, piece.Color);
            Assert.That(piece.YCoordinate, Is.EqualTo(3));
        }

        [Test]
        public void Add_Calls_SetBoard()
        {
            var piece = Substitute.For<IChessPiece>();

            _chessBoard.Add(piece, 6, 3, piece.Color);
            piece.Received().SetBoard(_chessBoard);
        }
    }
}
