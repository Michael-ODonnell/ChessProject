using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring {
    /// <summary>
    /// Standard rules for a normal chess pawn
    /// </summary>
    internal class DefaultKnightRules : UniversalRules {
        
        public DefaultKnightRules()
        {
            _rules.Add(new CannotMoveHorizontallyRule());
            _rules.Add(new CannotMoveVerticallyRule());
            _rules.Add(new MustMoveThreeSquaresRule());
        }
    }
}
