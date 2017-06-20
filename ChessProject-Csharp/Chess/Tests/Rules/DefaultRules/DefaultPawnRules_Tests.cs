using System;
using NSubstitute;
using NUnit.Framework;

namespace Gfi.Hiring {

    [TestFixture]
	public class DefaultPawnRules_Tests : UniversalRules_Tests {


        protected override IRuleSet GetRuleSet()
        {
            return new DefaultPawnRules();
        }

        [Test]
        public void Pawn_RuleSet_Contains_ValidPawnMoveRule()
        {
            Assert.That(RuleSetContainsRule(_ruleset, typeof(EndpointSquareOccupiedRule)), Is.True);

        }
    }
}
