namespace Gfi.Hiring {
    public class Move {
        public IChessPiece Piece { get; private set; }
        public int StartingX { get; private set; }
        public int StartingY { get; private set; }
        public int EndingX { get; private set; }
        public int EndingY { get; private set; }

        /// <summary>
        /// Defines a move
        /// </summary>
        /// <param name="piece">The piece being moved</param>
        /// <param name="startX">The x coordinate of the square the piece starts on</param>
        /// <param name="startY">The y coordinate of the square the piece starts on</param>
        /// <param name="endX">The x coordinate of the square the piece ends on</param>
        /// <param name="endY">The y coordinate of the square the piece ends on</param>
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
