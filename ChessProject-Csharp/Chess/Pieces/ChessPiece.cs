using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring {
    public class ChessPiece : IChessPiece {

        /// <summary>
        /// Rules governing behaviour of the piece
        /// </summary>
        private List<IRule> _rules;

        protected IChessBoard _chessBoard;
        
        /// <summary>
        /// Constructor with initial rules governing piece behaviour
        /// </summary>
        /// <param name="board">board the piece is to be placed on</param>
        /// <param name="type">The type of piece</param>
        /// <param name="color">Which side the piece is on</param>
        /// <param name="rules">Rules constraining piece behaviour and movement</param>
        public ChessPiece(IChessBoard board, PieceType type, PieceColor color, IRule[] rules)
        {
            Init(board, type, color, rules);
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
        /// <param name="board">board the piece is to be placed on</param>
        /// <param name="type">The type of piece</param>
        /// <param name="color">Which side the piece is on</param>
        /// <param name="rules">Rules constraining piece behaviour and movement</param>
        private void Init(IChessBoard board, PieceType type, PieceColor color, IRule[] rules)
        {
            _chessBoard = board;
            Type = type;
            Color = color;
            XCoordinate = ChessBoard.OffBoardCoordinate;
            YCoordinate = ChessBoard.OffBoardCoordinate;
            _rules = new List<IRule>(rules);
        }

        /// <summary>
        /// Moves a piece iff the move meets all the required rules for the piece.  Returns whehter the move happened
        /// </summary>
        /// <param name="newXCoordinate"></param>
        /// <param name="newYCoordinate"></param>
        /// <returns></returns>
        public virtual bool Move(int newXCoordinate, int newYCoordinate)
        {
            Move move = new Move(this, XCoordinate, YCoordinate, newXCoordinate, newYCoordinate);

            foreach (IRule rule in _rules)
            {
                if (!rule.IsMoveValid(_chessBoard, move))
                {
                    return false;
                }
            }

            XCoordinate = newXCoordinate;
            YCoordinate = newYCoordinate;

            _chessBoard.UpdateBoard(move);

            return true;
        }
    }
}
