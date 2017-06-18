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

		[Test]
		public void Has_MaxBoardWidth_of_8()
		{
			Assert.That(ChessBoard.MaxBoardWidth, Is.EqualTo(8));
		}

		[Test]
		public void Has_MaxBoardHeight_of_8()
		{
			Assert.That(ChessBoard.MaxBoardHeight, Is.EqualTo(8));
		}

		[Test]
		public void IsLegalBoardPosition_True_X_equals_0_Y_equals_0()
		{
			var isValidPosition = _chessBoard.IsLegalBoardPosition(0, 0);
			Assert.That(isValidPosition, Is.True);
		}

		[Test]
		public void IsLegalBoardPosition_True_X_equals_5_Y_equals_5()
		{
			var isValidPosition = _chessBoard.IsLegalBoardPosition(5, 5);
			Assert.That(isValidPosition, Is.True);
		}

		[Test]
		public void IsLegalBoardPosition_False_X_equals_11_Y_equals_5()
		{
			var isValidPosition = _chessBoard.IsLegalBoardPosition(11, 5);
			Assert.That(isValidPosition, Is.False);
		}

		[Test]
		public void IsLegalBoardPosition_False_X_equals_0_Y_equals_9()
		{
			var isValidPosition = _chessBoard.IsLegalBoardPosition(0, 9);
			Assert.That(isValidPosition, Is.False);
		}

		[Test]
		public void IsLegalBoardPosition_False_X_equals_11_Y_equals_0()
		{
			var isValidPosition = _chessBoard.IsLegalBoardPosition(11, 0);
			Assert.That(isValidPosition, Is.False);
		}
	}
}
