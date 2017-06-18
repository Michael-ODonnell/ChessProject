using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring
{

	[TestFixture]
	public class CannotMoveHorizontallyRule_Tests {

		[Test]
		public void Prevent_Movement_When_Start_Y_Greater_Than_End_Y()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new CannotMoveHorizontallyRule();

			Move move = new Move(piece, 0, 0, 1, 1);

			Assert.IsFalse(rule.IsMoveValid(board, move));
		}

		[Test]
		public void Prevent_Movement_When_Start_Y_Less_Than_End_Y()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new CannotMoveHorizontallyRule();

			Move move = new Move(piece, 1, 1, 1, 0);

			Assert.IsFalse(rule.IsMoveValid(board, move));
		}

		[Test]
		public void Allow_Movement_When_Start_Y_Equals_End_Y()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new CannotMoveHorizontallyRule();

			Move move = new Move(piece, 0, 0, 1, 0);

			Assert.IsTrue(rule.IsMoveValid(board, move));
		}

		[Test]
		public void Allow_Movement_Across_Multiple_Squares_When_Start_Y_Equals_End_Y()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new CannotMoveHorizontallyRule();

			board.Width.Returns(8);

			Move move = new Move(piece, 0, 0, board.Width-1, 0);

			Assert.IsTrue(rule.IsMoveValid(board, move));
		}
	}
}
