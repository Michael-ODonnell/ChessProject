using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring {
    public interface IChessPiece {
        int XCoordinate { get; set; }
        int YCoordinate { get; set; }
        PieceType Type { get; }
        PieceColor Color { get; }
        bool Move(MovementType type, int newXCoordinate, int newYCoordinate);
    }
}
