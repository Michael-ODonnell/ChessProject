using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring {
    /// <summary>
    /// Standard rules for a normal chess knight
    /// </summary>
    internal class DefaultKnightRules : UniversalRules {
        
        public DefaultKnightRules()
        {
            _rules.Add(new CannotMoveOnXAxisRule());
            _rules.Add(new CannotMoveOnYAxisRule());
            _rules.Add(new MustMoveThreeSquaresRule());
        }
    }
}
