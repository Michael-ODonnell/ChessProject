using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring {
    public class ChessPiece : IChessPiece {

        protected IChessBoard _chessBoard;

        public ChessPiece(IChessBoard board, PieceType type, PieceColor color)
        {
            _chessBoard = board;
            Type = type;
            Color = color;
            XCoordinate = ChessBoard.OffBoardCoordinate;
            YCoordinate = ChessBoard.OffBoardCoordinate;
        }

        public PieceColor Color { get; private set; }

        public PieceType Type { get; private set; }

        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        public virtual bool Move(MovementType type, int newXCoordinate, int newYCoordinate)
        {
            if (_chessBoard.IsLegalBoardPosition(newXCoordinate, newYCoordinate))
            {
                XCoordinate = newXCoordinate;
                YCoordinate = newYCoordinate;
                return true;
            }

            return false;
        }
    }
}
