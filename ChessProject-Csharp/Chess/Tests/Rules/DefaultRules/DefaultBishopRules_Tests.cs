using System;
using NSubstitute;
using NUnit.Framework;

namespace Gfi.Hiring {

	[TestFixture]
	public class DefaultBishopRules_Tests : UniversalRules_Tests {


		protected override IRuleSet GetRuleSet()
		{
			return new DefaultBishopRules();
		}

		[Test]
		public void Bishop_RuleSet_Contains_CannotMoveHorizontallyRule()
		{
			Assert.That(RuleSetContainsRule(_ruleset, typeof(CannotMoveOnXAxisRule)), Is.True);
		}

		[Test]
		public void Bishop_RuleSet_Contains_CannotMoveVerticallyRule()
		{
			Assert.That(RuleSetContainsRule(_ruleset, typeof(CannotMoveOnYAxisRule)), Is.True);
		}

		[Test]
		public void Bishop_RuleSet_Contains_MustMoveInStraightLineRule()
		{
			Assert.That(RuleSetContainsRule(_ruleset, typeof(MustMoveInStraightLineRule)), Is.True);
		}

		[Test]
		public void Bishop_Cannot_Move_Left()
		{
			var piece = Substitute.For<IChessPiece>();
			Move move = new Move(piece, 1, 0, 0, 0);
			_board.IsMoveValid(move).ReturnsForAnyArgs(_ruleset.IsMoveValid(_board, move));

			Assert.That(_board.IsMoveValid(move), Is.False);
		}

		[Test]
		public void Bishop_Cannot_Move_Right()
		{
			var piece = Substitute.For<IChessPiece>();
			Move move = new Move(piece, 0, 0, 1, 0);
			_board.IsMoveValid(move).ReturnsForAnyArgs(_ruleset.IsMoveValid(_board, move));

			Assert.That(_board.IsMoveValid(move), Is.False);
		}

		[Test]
		public void Bishop_Cannot_Move_Up()
		{
			var board = Substitute.For<IChessBoard>();
			var piece = Substitute.For<IChessPiece>();
			Move move = new Move(piece, 0, 0, 0, 1);
			board.IsMoveValid(move).ReturnsForAnyArgs(_ruleset.IsMoveValid(board, move));

			Assert.That(board.IsMoveValid(move), Is.False);
		}

		[Test]
		public void Bishop_Cannot_Move_Down()
		{
			var piece = Substitute.For<IChessPiece>();
			Move move = new Move(piece, 0, 1, 0, 0);
			_board.IsMoveValid(move).ReturnsForAnyArgs(_ruleset.IsMoveValid(_board, move));

			Assert.That(_board.IsMoveValid(move), Is.False);
		}

		[Test]
		public void Bishop_Can_Move_On_X_Equals_Y()
		{
			var piece = Substitute.For<IChessPiece>();
			Move move = new Move(piece, 0, 0, 1, 1);
			_board.IsMoveValid(move).ReturnsForAnyArgs(x => { return _ruleset.IsMoveValid(_board, move); });


			bool result = _board.IsMoveValid(move);
			Assert.That(_board.IsMoveValid(move), Is.True);
		}

		[Test]
		public void Bishop_Can_Move_On_X_Equals_Minus_Y()
		{
			var piece = Substitute.For<IChessPiece>();
			Move move = new Move(piece, 0, 1, 1, 0);
			_board.IsMoveValid(move).ReturnsForAnyArgs(x => { return _ruleset.IsMoveValid(_board, move); });

			Assert.That(_board.IsMoveValid(move), Is.True);
		}
	}
}
