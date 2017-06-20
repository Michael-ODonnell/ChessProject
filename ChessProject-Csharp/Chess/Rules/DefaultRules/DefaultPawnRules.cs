using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring {
    internal class DefaultPawnRules : UniversalRules {
        
        public DefaultPawnRules()
        {
            _rules.Add(new ValidPawnMoveRule());
        }
    }
}
