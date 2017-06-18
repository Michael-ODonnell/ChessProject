using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring
{

	[TestFixture]
	public class Pawn_Tests : ChessPiece_Tests {
		
		protected override IChessPiece GetPiece(PieceColor color)
		{
			return new Pawn(_chessBoard, color);
		}

		[Test]
		public void Pawn_Move_IllegalCoordinates_Right_DoesNotMove()
		{
			_chessBoard.AddPiece(_chessPiece, 6, 3);
			_chessPiece.Move(MovementType.Move, 7, 3);
			Assert.That(_chessPiece.XCoordinate, Is.EqualTo(6));
			Assert.That(_chessPiece.YCoordinate, Is.EqualTo(3));
		}

		[Test]
		public void Pawn_Move_IllegalCoordinates_Left_DoesNotMove()
		{
			_chessBoard.AddPiece(_chessPiece, 6, 3);
			_chessPiece.Move(MovementType.Move, 4, 3);
			Assert.That(_chessPiece.XCoordinate, Is.EqualTo(6));
			Assert.That(_chessPiece.YCoordinate, Is.EqualTo(3));
		}

		[Test]
		public void Pawn_Move_LegalCoordinates_Forward_UpdatesCoordinates()
		{
			_chessBoard.AddPiece(_chessPiece, 6, 3);
			_chessPiece.Move(MovementType.Move, 6, 2);
			Assert.That(_chessPiece.XCoordinate, Is.EqualTo(6));
			Assert.That(_chessPiece.YCoordinate, Is.EqualTo(2));
		}
	}
}
