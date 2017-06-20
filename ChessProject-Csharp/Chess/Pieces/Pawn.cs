using System;

namespace Gfi.Hiring
{
    /// <summary>
    /// Instance of the Pawn class.  Pawn needs it's own class due to requirements for one of it's rules
    /// Most Types won't need their own classes - probably only Rooks and Kings (for castling and game over handling)
    /// </summary>
    public class Pawn : ChessPiece, IPawn
    {
        private static readonly int NotMoved = 0;

        /// <summary>
        /// Base Constuctor
        /// </summary>
        /// <param name="board">Board related to the game.</param>
        /// <param name="pieceColor">Which side the piece is on</param>
        public Pawn(PieceColor pieceColor) : base(PieceType.Pawn, pieceColor)
        {
        }

        /// <summary>
        /// Indicates the turn when the piece was first moved
        /// </summary>
        public int FirstMovedOn { get; private set; }

        /// <summary>
        /// Moves the piece.  Coordinates are only updated if the move is valid
        /// </summary>
        /// <param name="newXCoordinate">XCoordinate of the square being moved to</param>
        /// <param name="newYCoordinate">YCoordinate of the square being moved to</param>
        /// <returns>True when the move was valid</returns>
        public override bool Move(MovementType moveType, int newXCoordinate, int newYCoordinate)
        {
            if(FirstMovedOn == NotMoved)
            {
                FirstMovedOn = _chessBoard.CurrentTurn;
            }
            return base.Move(moveType, newXCoordinate, newYCoordinate);
        }

        public override string ToString()
        {
            return CurrentPositionAsString();
        }

        protected string CurrentPositionAsString()
        {
            return string.Format("Current X: {1}{0}Current Y: {2}{0}Piece Color: {3}", Environment.NewLine, XCoordinate, YCoordinate, Color);
        }

    }
}
