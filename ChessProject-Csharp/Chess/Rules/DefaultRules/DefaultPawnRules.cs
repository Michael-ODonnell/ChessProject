using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring {
    /// <summary>
    /// Standard rules for a normal chess pawn
    /// </summary>
    internal class DefaultPawnRules : UniversalRules {
        
        public DefaultPawnRules()
        {
            _rules.Add(new ValidPawnMoveRule());
        }
    }
}
