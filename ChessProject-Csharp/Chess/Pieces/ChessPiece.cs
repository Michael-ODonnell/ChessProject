using System.Collections.Generic;

namespace Gfi.Hiring {
    public class ChessPiece : IChessPiece {
        
        protected IChessBoard _chessBoard;
        
        /// <summary>
        /// Constructor with initial rules governing piece behaviour
        /// </summary>
        /// <param name="board">board the piece is to be placed on</param>
        /// <param name="type">The type of piece</param>
        /// <param name="color">Which side the piece is on</param>
        /// <param name="rules">Rules constraining piece behaviour and movement</param>
        public ChessPiece(PieceType type, PieceColor color)
        {
            Init(type, color);
        }

        /// <summary>
        /// Which side the piece is on, Black or White
        /// </summary>
        public PieceColor Color { get; private set; }

        /// <summary>
        /// Type of Piece - Pawn, Rook, Knight, Bishop, Queen, King
        /// </summary>
        public PieceType Type { get; private set; }

        /// <summary>
        /// X Coordinate / Column Id / A-H AN
        /// </summary>
        public int XCoordinate { get; set; }

        /// <summary>
        /// Y Coordinate / Row Id / 1-8 AN
        /// </summary>
        public int YCoordinate { get; set; }

        /// <summary>
        /// Initialises the board variables for the constructors
        /// </summary>
        /// <param name="type">The type of piece</param>
        /// <param name="color">Which side the piece is on</param>
        private void Init(PieceType type, PieceColor color)
        {
            Type = type;
            Color = color;
            XCoordinate = ChessBoard.OffBoardCoordinate;
            YCoordinate = ChessBoard.OffBoardCoordinate;
        }

        /// <summary>
        /// Moves the piece.  Coordinates are only updated if the move is valid
        /// </summary>
        /// <param name="newXCoordinate">The x coordinate of the square being moved to</param>
        /// <param name="newYCoordinate">The y coordinate of the square being moved to</param>
        /// <returns>True when the move was valid</returns>
        public virtual bool Move(MovementType moveType, int newXCoordinate, int newYCoordinate)
        {
            Move move = new Move(this, XCoordinate, YCoordinate, newXCoordinate, newYCoordinate);

            if (_chessBoard.IsMoveValid(move))
            {
                XCoordinate = newXCoordinate;
                YCoordinate = newYCoordinate;
                _chessBoard.UpdateBoard(move);
            }

            return true;
        }

        public void AddToBoard(IChessBoard board)
        {
            _chessBoard = board;
        }

        public void RemoveFromBoard()
        {
            _chessBoard = null;
        }
    }
}
