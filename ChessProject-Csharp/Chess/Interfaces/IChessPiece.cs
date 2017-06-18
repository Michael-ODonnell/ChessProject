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

        /// <summary>
        /// Moves the piece.  Coordinates are only updated if the move is valid
        /// </summary>
        /// <param name="type"></param>
        /// <param name="newXCoordinate"></param>
        /// <param name="newYCoordinate"></param>
        /// <returns>True when the move was valid</returns>
        bool Move(MovementType type, int newXCoordinate, int newYCoordinate);
    }
}
