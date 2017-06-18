using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring {
    /// <summary>
    /// Checks movement for pawns.  Includes checks for intial advancement, capture movement and En Passant
    /// </summary>
    class ValidPawnMoveRule : IRule {

        public bool IsMoveValid(IChessBoard board, Move move)
        {
            int forwardDirection = move.Piece.Color == PieceColor.White ? 1 : -1;

            // pawns can only move forwards
            if (((move.EndingY - move.StartingY) * forwardDirection) <= 0)
            {
                return false;
            }

            // pawns can only move forwards two squares at most
            if (((move.EndingY - move.StartingY) * forwardDirection) > 2)
            {
                return false;
            }

            // pawns cannot move horiztally more than one square
            if (move.StartingX - move.EndingX > 1 || move.EndingX - move.StartingX > 1)
            {
                return false;
            }

            // pawns can only move forward two squares from their home rank
            if (move.EndingY - move.StartingY == 2)            // for white
            {
                if (move.Piece.Color == PieceColor.Black) return false;
                if (move.StartingY != 1) return false;
                if (move.StartingX != move.EndingX) return false; // cannot move horizontally during double step
            }
            if (move.StartingY - move.EndingY == 2)            // for black
            {
                if (move.Piece.Color == PieceColor.White) return false;
                if (move.StartingY != 6) return false;
                if (move.StartingX != move.EndingX) return false; // cannot move horizontally during double step
            }

            IChessPiece targetPiece = null;
            bool targetSquareOccupied = board.TryGetPieceOn(move.EndingX, move.EndingY, out targetPiece);

            // pawns cannot move directly forward into an occupied square
            if (move.StartingX - move.EndingX == 0)
            {
                return !targetSquareOccupied;
            }

            // capture move check
            if (move.StartingX - move.EndingX == 1 || move.EndingX - move.StartingX == 1)
            {
                return (targetSquareOccupied && targetPiece.Color != move.Piece.Color) || CheckEnPassant(board, move);
            }

            return false;
        }

        private bool CheckEnPassant(IChessBoard board, Move move)
        {
            // en passant can only apply on racks three from the enemies home
            if (move.Piece.Color == PieceColor.White && move.EndingY != board.Height - 3)
            {
                return false;
            }
            if (move.Piece.Color == PieceColor.Black && move.EndingY != 2)
            {
                return false;
            }

            // get the piece behind the target move point
            int forwardDirection = move.Piece.Color == PieceColor.White ? 1 : -1;
            IChessPiece targetPiece = null;
            bool targetSquareOccupied = board.TryGetPieceOn(move.EndingX, move.EndingY - forwardDirection, out targetPiece);

            if (!targetSquareOccupied)
            {
                return false;
            }
            if (!(targetPiece is IPawn))
            {
                return false;
            }

            // En Passant can only be applied on the next turn after the piece moves.
            IPawn pawn = targetPiece as IPawn;
            return board.CurrentTurn == pawn.FirstMovedOn + 1;
        }
    }
}
