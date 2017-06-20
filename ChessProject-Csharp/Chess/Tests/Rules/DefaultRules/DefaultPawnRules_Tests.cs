using NSubstitute;
using NUnit.Framework;

namespace Gfi.Hiring {

    [TestFixture]
	public class DefaultPawnRules_Tests : DefaultRules_Tests {

        private DefaultPawnRules _pawnRules;

        [SetUp]
        public void SetUp()
        {
            _pawnRules = new DefaultPawnRules();
        }

        [Test]
		public void Pawn_RuleSet_Contains_EndpointSquareOccupiedRule()
        {
            Assert.That(RuleSetContainsRule(_pawnRules, typeof(EndpointSquareOccupiedRule)), Is.True);

        }
        [Test]
        public void Pawn_RuleSet_Contains_CannotMoveToSameSquareRule()
        {
            Assert.That(RuleSetContainsRule(_pawnRules, typeof(CannotMoveToSameSquareRule)), Is.True);

        }
        [Test]
        public void Pawn_RuleSet_Contains_ValidPawnMoveRule()
        {
            Assert.That(RuleSetContainsRule(_pawnRules, typeof(EndpointSquareOccupiedRule)), Is.True);

        }
        [Test]
        public void Pawn_RuleSet_Contains_CannotMoveThroughPiecesRule()
        {
            Assert.That(RuleSetContainsRule(_pawnRules, typeof(EndpointSquareOccupiedRule)), Is.True);

        }
        [Test]
        public void Pawn_RuleSet_Contains_MoveEndpointOnBoardRule()
        {
            Assert.That(RuleSetContainsRule(_pawnRules, typeof(EndpointSquareOccupiedRule)), Is.True);

        }
	}
}
