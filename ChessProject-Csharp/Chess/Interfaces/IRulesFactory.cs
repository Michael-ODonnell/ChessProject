using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring {
    internal interface IRulesFactory {
        IRule[] GetRulesFor(PieceType type);
    }
}
