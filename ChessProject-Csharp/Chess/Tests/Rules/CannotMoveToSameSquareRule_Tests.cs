using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring
{

	[TestFixture]
	public class CannotMoveToSameSquareRule_Tests {

		[Test]
		public void Prevent_Movement_When_Start_Square_Equals_End_Square()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new CannotMoveToSameSquareRule();

			Move move = new Move(piece, 0, 0, 0, 0);

			Assert.IsFalse(rule.IsMoveValid(board, move));
		}

		[Test]
		public void Allow_Movement_When_Start_X_Equals_End_X()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new CannotMoveToSameSquareRule();

			Move move = new Move(piece, 0, 0, 0, 1);

			Assert.IsTrue(rule.IsMoveValid(board, move));
		}

		[Test]
		public void Allow_Movement_When_Start_Y_Equals_End_Y()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			IRule rule = new CannotMoveToSameSquareRule();

			Move move = new Move(piece, 0, 0, 1, 0);

			Assert.IsTrue(rule.IsMoveValid(board, move));
		}
	}
}
