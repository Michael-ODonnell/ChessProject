using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring
{
	[TestFixture]
	public class ChessBoard_Tests : IChessBoard_Tests   
	{
		protected override IChessBoard GetBoard()
		{
			return new ChessBoard();
		}
	}
}
