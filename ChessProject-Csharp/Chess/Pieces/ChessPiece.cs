using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring {
    public class ChessPiece : IChessPiece {

        /// <summary>
        /// Rules governing behaviour of the piece
        /// </summary>
        private List<IRule> m_Rules;

        protected IChessBoard _chessBoard;
        
        public ChessPiece(IChessBoard board, PieceType type, PieceColor color)
        {
            Init(board, type, color, new IRule[0]);
        }

        public ChessPiece(IChessBoard board, PieceType type, PieceColor color, IRule[] rules)
        {
            Init(board, type, color, rules);
        }

        public PieceColor Color { get; private set; }

        public PieceType Type { get; private set; }

        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        private void Init(IChessBoard board, PieceType type, PieceColor color, IRule[] rules)
        {
            _chessBoard = board;
            Type = type;
            Color = color;
            XCoordinate = ChessBoard.OffBoardCoordinate;
            YCoordinate = ChessBoard.OffBoardCoordinate;
            m_Rules = new List<IRule>(rules);
        }

        public virtual bool Move(MovementType type, int newXCoordinate, int newYCoordinate)
        {
            Move move = new Move(this, XCoordinate, YCoordinate, newXCoordinate, newYCoordinate);

            foreach (IRule rule in m_Rules)
            {
                if (!rule.IsMoveValid(_chessBoard, move))
                {
                    return false;
                }
            }

            XCoordinate = newXCoordinate;
            YCoordinate = newYCoordinate;

            return true;
        }

        internal void AddRule(IRule rule)
        {
            m_Rules.Add(rule);
        }
    }
}
