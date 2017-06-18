using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring
{

	[TestFixture]
	public class Pawn_IPawn_Tests : IPawn_Tests {
		
		protected override IPawn GetPawn(PieceColor color)
		{
			return new Pawn(_chessBoard, color);
		}
	}
}
