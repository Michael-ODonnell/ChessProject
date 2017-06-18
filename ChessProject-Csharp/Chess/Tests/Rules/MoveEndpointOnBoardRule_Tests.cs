using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring
{

	[TestFixture]
	public class MoveEndpointOnBoardRule_Tests {

		[Test]
		public void Move_To_Valid_Position_On_Board_Allowed()
		{
			var board = Substitute.For<IChessBoard>();
			board.IsLegalBoardPosition(Arg.Any<int>(), Arg.Any<int>()).Returns(true);
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new MoveEndpointOnBoardRule();

			Move move = new Move(piece, 0, 0, 1, 1);

			Assert.IsTrue(rule.IsMoveValid(board, move));
		}

		[Test]
		public void Move_To_Invalid_Position_On_Board_Disallowed()
		{
			var board = Substitute.For<IChessBoard>();
			board.IsLegalBoardPosition(Arg.Any<int>(), Arg.Any<int>()).Returns(false);
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new MoveEndpointOnBoardRule();

			Move move = new Move(piece, 0, 0, 1, 1);

            Assert.IsFalse(rule.IsMoveValid(board, move));
		}
	}
}
