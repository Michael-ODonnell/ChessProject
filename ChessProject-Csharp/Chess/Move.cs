using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring {
    public class Move {
        public IChessPiece Piece { get; private set; }
        public int StartingX { get; private set; }
        public int StartingY { get; private set; }
        public int EndingX { get; private set; }
        public int EndingY { get; private set; }

        public Move(IChessPiece piece, int startX, int startY, int endX, int endY)
        {
            Piece = piece;
            StartingX = startX;
            StartingY = startY;
            EndingX = endX;
            EndingY = endY;
        }
    }
}
