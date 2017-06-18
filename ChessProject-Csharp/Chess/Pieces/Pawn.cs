using System;

namespace Gfi.Hiring
{
    public class Pawn : ChessPiece
    {
        public const int Max = 8;

        public Pawn(IChessBoard board, PieceColor pieceColor, IRule[] rules) : base(board, PieceType.Pawn, pieceColor, rules)
        {
        }

        public override bool Move(MovementType movementType, int newX, int newY)
        {
            if (!_chessBoard.IsLegalBoardPosition(newX, newY)) { 
                return false;
            }
            // no lateral movement for pawns
            if(newX != XCoordinate)
            {
                return false;
            }
            // switch to relative movement because easier to visualise
            int yMove = newY - YCoordinate;
            if(Color == PieceColor.Black)
            {
                return MoveBlack(movementType, yMove);
            }
            else
            {
                return MoveWhite(movementType, yMove);
            }
        }

        private bool MoveBlack(MovementType movementType, int yMove)
        {
            if (yMove == -1 || (YCoordinate == 7 && yMove == -2))
            {
                YCoordinate += yMove;
                return true;
            }
            return false;
        }

        private bool MoveWhite(MovementType movementType, int yMove)
        {
            if (yMove == 1 || (YCoordinate == 1 && yMove == 2))
            {
                YCoordinate += yMove;
                return true;
            }
            return false;
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
