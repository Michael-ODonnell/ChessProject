using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring {
    public interface IPawn : IChessPiece {
        int FirstMovedOn { get; }
    }
}
