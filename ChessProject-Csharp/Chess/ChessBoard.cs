using System;
using System.Collections.Generic;

namespace Gfi.Hiring
{
    public class ChessBoard
    {
        public static readonly int MaxBoardWidth = 8;
        public static readonly int MaxBoardHeight = 8;
        private Pawn[,] pieces;

        private List<IPiece>[,] piecesOnBoard; //int[type, color]
        
        public ChessBoard ()
        {
            pieces = new Pawn[MaxBoardWidth+1, MaxBoardHeight+1];

            piecesOnBoard = new List<IPiece>[6, 2];
            for (int type = 0; type < 6; ++type)
            {
                for (int color = 0; color < 2; ++color)
                {
                    piecesOnBoard[type, color] = new List<IPiece>();
                }
            }
        }

        public void Add(Pawn pawn, int xCoordinate, int yCoordinate, PieceColor pieceColor)
        {
            if (!IsLegalBoardPosition(xCoordinate, yCoordinate))
            {
                RemoveFromBoard(pawn);
                return;
            }
            if (piecesOnBoard[(int)PieceType.Pawn, (int)pieceColor].Count == Pawn.Max)
            {
                RemoveFromBoard(pawn);
                return;
            }

            if(pieces[xCoordinate, yCoordinate] == null)
            {
                pieces[xCoordinate, yCoordinate] = pawn;
                pawn.XCoordinate = xCoordinate;
                pawn.YCoordinate = yCoordinate;
                piecesOnBoard[(int)PieceType.Pawn, (int)pieceColor].Add(pawn);
            }
            else
            {
                RemoveFromBoard(pawn);
            }
        }

        public bool IsLegalBoardPosition(int xCoordinate, int yCoordinate)
        {
            return (-1 < xCoordinate && xCoordinate <= MaxBoardHeight &&
                -1 < yCoordinate && yCoordinate <= MaxBoardWidth);
        }

        private void RemoveFromBoard(Pawn pawn)
        {
            pawn.XCoordinate = -1;
            pawn.YCoordinate = -1;
        }


    }
}
