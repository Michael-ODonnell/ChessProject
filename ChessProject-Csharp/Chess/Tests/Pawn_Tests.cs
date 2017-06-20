using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring
{
	[TestFixture]
	public class Pawn_Tests
	{
		private ChessBoard _chessBoard;
		private Pawn _pawn;

		[SetUp]
		public void SetUp()
		{
			_chessBoard = new ChessBoard();
			_pawn = new Pawn(PieceColor.Black);
		}

		[Test]
		public void ChessBoard_Add_Sets_XCoordinate()
		{
			_chessBoard.Add(_pawn, 6, 3, PieceColor.Black);
			Assert.That(_pawn.XCoordinate, Is.EqualTo(6));
		}

		[Test]
		public void ChessBoard_Add_Sets_YCoordinate()
		{
			_chessBoard.Add(_pawn, 6, 3, PieceColor.Black);
			Assert.That(_pawn.YCoordinate, Is.EqualTo(3));
		}

		[Test]
		public void Pawn_Move_IllegalCoordinates_Right_DoesNotMove()
		{
			_chessBoard.Add(_pawn, 6, 3, PieceColor.Black);
			_pawn.Move(MovementType.Move, 7, 3);
			Assert.That(_pawn.XCoordinate, Is.EqualTo(6));
			Assert.That(_pawn.YCoordinate, Is.EqualTo(3));
		}

		[Test]
		public void Pawn_Move_IllegalCoordinates_Left_DoesNotMove()
		{
			_chessBoard.Add(_pawn, 6, 3, PieceColor.Black);
			_pawn.Move(MovementType.Move, 4, 3);
			Assert.That(_pawn.XCoordinate, Is.EqualTo(6));
			Assert.That(_pawn.YCoordinate, Is.EqualTo(3));
		}

		[Test]
		public void Pawn_Move_LegalCoordinates_Forward_UpdatesCoordinates()
		{
			_chessBoard.Add(_pawn, 6, 3, PieceColor.Black);
			_pawn.Move(MovementType.Move, 6, 2);
			Assert.That(_pawn.XCoordinate, Is.EqualTo(6));
			Assert.That(_pawn.YCoordinate, Is.EqualTo(2));
		}

	}
}
