using NSubstitute;
using NUnit.Framework;
using System;

namespace Gfi.Hiring {
    
    [TestFixture]
	public abstract class DefaultRules_Tests {

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
	}
}
