namespace Gfi.Hiring {
    /// <summary>
    /// Defines the behaviour required of a piece implementation.
    /// </summary>
    public interface IChessPiece {
        /// <summary>
        /// X Coordinate of the square on an IChessBoard the piece is on
        /// </summary>
        int XCoordinate { get; set; }

        /// <summary>
        /// Y Coordinate of the square on an IChessBoard the piece is on
        /// </summary>
        int YCoordinate { get; set; }

        /// <summary>
        /// Type of the piece
        /// </summary>
        PieceType Type { get; }

        /// <summary>
        /// Which side the piece is on
        /// </summary>
        PieceColor Color { get; }

        /// <summary>
        /// Moves the piece.  Coordinates are only updated if the move is valid
        /// </summary>
        /// <param name="newXCoordinate">The x coordinate of the square being moved to</param>
        /// <param name="newYCoordinate">The y coordinate of the square being moved to</param>
        /// <returns>True when the move was valid</returns>
        bool Move(MovementType moveType, int newXCoordinate, int newYCoordinate);
    }
}
