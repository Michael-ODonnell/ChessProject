using System;
using System.Collections.Generic;

namespace Gfi.Hiring
{
    public class ChessBoard : IChessBoard
    {
        public static readonly int MaxBoardWidth = 8;
        public static readonly int MaxBoardHeight = 8;
        public const int OffBoardCoordinate = -1;
        private IChessPiece[,] pieces;

        public int Width {  get { return MaxBoardWidth; } }
        public int Height { get { return MaxBoardHeight; } }

        public int CurrentTurn
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsStraightClearPathBetween(int xStart, int yStart, int xEnd, int yEnd)
        {
            throw new NotImplementedException();
        }

        private List<IChessPiece>[,] piecesOnBoard; //int[type, color]
        
        public ChessBoard ()
        {
            pieces = new IChessPiece[MaxBoardWidth+1, MaxBoardHeight+1];

            piecesOnBoard = new List<IChessPiece>[6, 2];
            for (int type = 0; type < 6; ++type)
            {
                for (int color = 0; color < 2; ++color)
                {
                    piecesOnBoard[type, color] = new List<IChessPiece>();
                }
            }
        }

        public bool AddPiece(IChessPiece piece, int xCoordinate, int yCoordinate)
        {
            if (!IsLegalBoardPosition(xCoordinate, yCoordinate))
            {
                RemoveFromBoard(piece);
                return false;
            }
            if (piecesOnBoard[(int)PieceType.Pawn, (int)piece.Color].Count == Pawn.Max)
            {
                RemoveFromBoard(piece);
                return false;
            }

            if(pieces[xCoordinate, yCoordinate] == null)
            {
                pieces[xCoordinate, yCoordinate] = piece;
                piece.XCoordinate = xCoordinate;
                piece.YCoordinate = yCoordinate;
                piecesOnBoard[(int)PieceType.Pawn, (int)piece.Color].Add(piece);
                return true;
            }
            else
            {
                RemoveFromBoard(piece);
                return false;
            }
        }

        public bool IsLegalBoardPosition(int xCoordinate, int yCoordinate)
        {
            return (-1 < xCoordinate && xCoordinate < Width &&
                -1 < yCoordinate && yCoordinate < Height);
        }

        private void RemoveFromBoard(IChessPiece pawn)
        {
            pawn.XCoordinate = OffBoardCoordinate;
            pawn.YCoordinate = OffBoardCoordinate;
        }
        
        public bool TryGetPieceOn(int x, int y, out IChessPiece piece)
        {
            piece = pieces[x, y];
            return (piece != null);
        }
    }
}
