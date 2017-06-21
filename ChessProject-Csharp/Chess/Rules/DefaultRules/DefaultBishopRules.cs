using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring {
    /// <summary>
    /// Standard rules for a normal chess bishop
    /// </summary>
    internal class DefaultBishopRules : UniversalRules {
        
        public DefaultBishopRules()
        {
            _rules.Add(new CannotMoveOnXAxisRule());
            _rules.Add(new CannotMoveOnYAxisRule());
            _rules.Add(new MustMoveInStraightLineRule());
        }
    }
}
