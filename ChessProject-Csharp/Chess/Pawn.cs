using System;

namespace Gfi.Hiring
{
    public class Pawn : IPiece
    {
        public const int Max = 8;

        private ChessBoard _chessBoard;
        private int _xCoordinate;
        private int _yCoordinate;
        private PieceColor _pieceColor;
        
        public ChessBoard ChessBoard
        {
            get { return _chessBoard; }
            set { _chessBoard = value; }
        }

        public int XCoordinate
        {
            get { return _xCoordinate; }
            set { _xCoordinate = value; }
        }
        
        public int YCoordinate
        {
            get { return _yCoordinate; }
            set { _yCoordinate = value; }
        }

        public PieceColor PieceColor
        {
            get { return _pieceColor; }
            private set { _pieceColor = value; }
        }

        public Pawn(PieceColor pieceColor)
        {
            _pieceColor = pieceColor;
        }

        public void Move(MovementType movementType, int newX, int newY)
        {
            // no lateral movement for pawns
            if(newX != XCoordinate)
            {
                return;
            }
            // switch to relative movement because easier to visualise
            int yMove = newY - YCoordinate;
            if(_pieceColor == PieceColor.Black)
            {
                MoveBlack(movementType, yMove);
            }
        }

        private void MoveBlack(MovementType movementType, int yMove)
        {
            if (yMove == -1 || (YCoordinate == 7 && yMove == -2))
            {
                YCoordinate += yMove;
            }
        }

        private void MoveWhite(MovementType movementType, int yMove)
        {
            if (yMove == 1 || (YCoordinate == 1 && yMove == 2))
            {
                YCoordinate += yMove;
            }
        }

        public override string ToString()
        {
            return CurrentPositionAsString();
        }

        protected string CurrentPositionAsString()
        {
            return string.Format("Current X: {1}{0}Current Y: {2}{0}Piece Color: {3}", Environment.NewLine, XCoordinate, YCoordinate, PieceColor);
        }

    }
}
