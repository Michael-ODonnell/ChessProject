using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring
{
	[TestFixture]
	public class ChessPiece_Tests : IChessPiece_Tests {
		
		protected override IChessPiece GetPiece(PieceColor color)
		{
            return CreatePiece(PieceType.Pawn, color);
        }

        private ChessPiece CreatePiece (PieceType type, PieceColor color)
        {
            ChessBoard board = new ChessBoard();
            return new ChessPiece(board, type, color);
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
        public void ChessPiece_Move_Sets_X_Coordinate_For_Valid_Board_Position()
        {
            IChessPiece piece = CreatePiece(PieceType.Pawn, PieceColor.Black);
            piece.Move(MovementType.Move, 0, 0);
            Assert.That(piece.XCoordinate, Is.EqualTo(0));
        }

        [Test]
        public void ChessPiece_Move_Sets_Y_Coordinate_For_Valid_Board_Position()
        {
            IChessPiece piece = CreatePiece(PieceType.Pawn, PieceColor.Black);
            piece.Move(MovementType.Move, 0, 0);
            Assert.That(piece.YCoordinate, Is.EqualTo(0));
        }
    }
}
