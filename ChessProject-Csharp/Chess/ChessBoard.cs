using System;
using System.Collections.Generic;

namespace Gfi.Hiring
{
    public class ChessBoard
    {
        public static readonly int MaxBoardWidth = 8;
        public static readonly int MaxBoardHeight = 8;
        public const int OffBoardCoordinate = -1;
        private IChessPiece[,] pieces;

        private List<IChessPiece>[,] piecesOnBoard; //int[type, color]
        
        public ChessBoard ()
        {
            pieces = new Pawn[MaxBoardWidth+1, MaxBoardHeight+1];

            piecesOnBoard = new List<IChessPiece>[6, 2];
            for (int type = 0; type < 6; ++type)
            {
                for (int color = 0; color < 2; ++color)
                {
                    piecesOnBoard[type, color] = new List<IChessPiece>();
                }
            }
        }

        public void Add(IChessPiece piece, int xCoordinate, int yCoordinate, PieceColor pieceColor)
        {
            if (!IsLegalBoardPosition(xCoordinate, yCoordinate))
            {
                RemoveFromBoard(piece);
                return;
            }
            if (piecesOnBoard[(int)PieceType.Pawn, (int)pieceColor].Count == Pawn.Max)
            {
                RemoveFromBoard(piece);
                return;
            }

            if(pieces[xCoordinate, yCoordinate] == null)
            {
                pieces[xCoordinate, yCoordinate] = piece;
                piece.XCoordinate = xCoordinate;
                piece.YCoordinate = yCoordinate;
                piecesOnBoard[(int)PieceType.Pawn, (int)pieceColor].Add(piece);
            }
            else
            {
                RemoveFromBoard(piece);
            }
        }

        public bool IsLegalBoardPosition(int xCoordinate, int yCoordinate)
        {
            return (-1 < xCoordinate && xCoordinate <= MaxBoardHeight &&
                -1 < yCoordinate && yCoordinate <= MaxBoardWidth);
        }

        private void RemoveFromBoard(IChessPiece pawn)
        {
            pawn.XCoordinate = OffBoardCoordinate;
            pawn.YCoordinate = OffBoardCoordinate;
        }


    }
}
