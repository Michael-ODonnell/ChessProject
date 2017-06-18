using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring {
    internal class ChessPiece : IChessPiece {

        private ChessBoard _chessboard;

        public ChessPiece(ChessBoard board, PieceType type, PieceColor color)
        {
            _chessboard = board;
            Type = type;
            Color = color;
            XCoordinate = ChessBoard.OffBoardCoordinate;
            YCoordinate = ChessBoard.OffBoardCoordinate;
        }

        public PieceColor Color { get; private set; }

        public PieceType Type { get; private set; }

        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        public bool Move(MovementType type, int newXCoordinate, int newYCoordinate)
        {
            if (_chessboard.IsLegalBoardPosition(newXCoordinate, newYCoordinate))
            {
                XCoordinate = newXCoordinate;
                YCoordinate = newYCoordinate;
                return true;
            }

            return false;
        }
    }
}
