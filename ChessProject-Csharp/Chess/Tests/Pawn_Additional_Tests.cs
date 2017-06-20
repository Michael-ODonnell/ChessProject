﻿using NUnit.Framework;

namespace Gfi.Hiring {

	[TestFixture]
	public class Pawn_Additional_Tests : ChessPiece_Tests {
		
		protected override IChessPiece CreatePiece(PieceType type, PieceColor color)
		{
			return new Pawn(color);
		}
	}
}
