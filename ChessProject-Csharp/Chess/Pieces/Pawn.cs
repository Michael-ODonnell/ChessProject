using System;

namespace Gfi.Hiring
{
    public class Pawn : ChessPiece, IPawn
    {
        public const int Max = 8;

        public Pawn(IChessBoard board, PieceColor pieceColor) : base(board, PieceType.Pawn, pieceColor)
        {

        }

        public int FirstMovedOn { get; private set; }

        public override bool Move(MovementType type, int newXCoordinate, int newYCoordinate)
        {
            if(FirstMovedOn == 0)
            {
                FirstMovedOn = _chessBoard.CurrentTurn;
            }
            return base.Move(type, newXCoordinate, newYCoordinate);
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
