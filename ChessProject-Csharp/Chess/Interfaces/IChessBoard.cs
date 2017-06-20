namespace Gfi.Hiring {
    /// <summary>
    /// Interface for a chessboard.  
    /// </summary>
    public interface IChessBoard {

        /// <summary>
        /// Width (number of columns) of the board
        /// </summary>
        int Width {get;}

        /// <summary>
        /// Height (number of rows) of the board
        /// </summary>
        int Height {get;}

        /// <summary>
        /// Adds a piece to the board if the square isn't occupied
        /// </summary>
        /// <param name="piece">The piece to add to the board</param>
        /// <param name="x">The x coordinate of the square to place the piece at</param>
        /// <param name="y">The y coordinate of the square to place the piece at</param>
        /// <returns>True if the piece was added</returns>
        bool Add(IChessPiece piece, int x, int y, PieceColor color);
        
        /// <summary>
        /// Checks if a move is valid.  Does not update the board
        /// </summary>
        /// <param name="move">Description of the move</param>
        bool IsMoveValid(Move move);

        /// <summary>
        /// Repositions a piece on the board.  Any pieces in the endpoint will be removed from the board
        /// </summary>
        /// <param name="move">Description of the move</param>
        void UpdateBoard(Move move);

        /// <summary>
        /// Checks if the x, y coordinates are on the board
        /// </summary>
        /// <param name="x">The x coordinate of the square to check for</param>
        /// <param name="y">The y coordinate of the square to check for</param>
        /// <returns>True if the coordinates are a valid square on the board</returns>
        bool IsLegalBoardPosition(int x, int y);

        /// <summary>
        /// Checks if there is a piece on x, y
        /// </summary>
        /// <param name="x">The x coordinate of the square to check</param>
        /// <param name="y">The y coordinate of the square to check</param>
        /// <param name="piece">The piece on the square.  If the square is empty this is set to null</param>
        /// <returns>True if a piece was found on the targeted square</returns>
        bool TryGetPieceOn(int x, int y, out IChessPiece piece);

        /// <summary>
        /// Current Turn Id.  0 on ititial board state, 1, during white first move, increments each turn
        /// </summary>
        int CurrentTurn { get; }

        /// <summary>
        /// checks if there are no pieces between two points.  The points can be occupied, but no square in a straight line between them can be.
        /// If the line is not of the form x=c, y=c, x=y or x=-y returns false.
        /// </summary>
        /// <param name="xStart">The x coordinate of the square being moved from</param>
        /// <param name="yStart">The y coordinate of the square being moved from</param>
        /// <param name="xEnd">The x coordinate of the square being moved to</param>
        /// <param name="yEnd">The y coordinate of the square being moved to</param>
        /// <returns>True if the path is a straight line with no pieces between the squares</returns>
        bool IsStraightClearPathBetween(int xStart, int yStart, int xEnd, int yEnd);

        /// <summary>
        /// Get the settings for the game
        /// </summary>
        /// <returns>The game settings</returns>
        GameSettings Settings();
    }
}
