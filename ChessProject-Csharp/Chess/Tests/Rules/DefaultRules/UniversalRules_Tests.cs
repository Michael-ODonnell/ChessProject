using NSubstitute;
using NUnit.Framework;
using System;

namespace Gfi.Hiring {
    
    [TestFixture]
	public abstract class UniversalRules_Tests {

        protected abstract IRuleSet GetRuleSet();
        protected IRuleSet _ruleset;
        protected IChessBoard _board;

        [SetUp]
        public void SetUp()
        {
            _ruleset = GetRuleSet();
            _board = Substitute.For<IChessBoard>();
            _board.IsLegalBoardPosition(0, 0).ReturnsForAnyArgs(true);
        }

        protected bool RuleSetContainsRule(IRuleSet ruleset, Type type)
        {
            foreach(IRule rule in ruleset.Rules())
            {
                if(rule.GetType() == type){
                    return true;
                }

                if(rule is IRuleSet){
                    if(RuleSetContainsRule(ruleset, type))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        [Test]
        public void Pawn_RuleSet_Contains_EndpointSquareOccupiedRule()
        {
            Assert.That(RuleSetContainsRule(_ruleset, typeof(EndpointSquareOccupiedRule)), Is.True);

        }
        [Test]
        public void Pawn_RuleSet_Contains_CannotMoveToSameSquareRule()
        {
            Assert.That(RuleSetContainsRule(_ruleset, typeof(CannotMoveToSameSquareRule)), Is.True);

        }
        [Test]
        public void Pawn_RuleSet_Contains_CannotMoveThroughPiecesRule()
        {
            Assert.That(RuleSetContainsRule(_ruleset, typeof(EndpointSquareOccupiedRule)), Is.True);

        }
        [Test]
        public void Pawn_RuleSet_Contains_MoveEndpointOnBoardRule()
        {
            Assert.That(RuleSetContainsRule(_ruleset, typeof(EndpointSquareOccupiedRule)), Is.True);

        }
    }
}
