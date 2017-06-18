using System;
using System.Collections.Generic;

namespace Gfi.Hiring
{
    /// <summary>
    /// Area where the game is played
    /// </summary>
    public class ChessBoard : IChessBoard
    {
        public static readonly int MaxBoardWidth = 8;
        public static readonly int MaxBoardHeight = 8;

        /// <summary>
        /// Coordinates used to indicate when a piece is not on the board.
        /// </summary>
        public const int OffBoardCoordinate = -1;

        /// <summary>
        /// Array of game squares.  Empty squares should contain null
        /// </summary>
        private IChessPiece[,] pieces;

        public int Width {  get { return MaxBoardWidth; } }
        public int Height { get { return MaxBoardHeight; } }

        /// <summary>
        /// Number of turns since game start.
        /// </summary>
        public int CurrentTurn { get; private set; }

        private List<IChessPiece>[,] piecesOnBoard; //int[type, color]
        
        public ChessBoard ()
        {
            pieces = new IChessPiece[MaxBoardWidth, MaxBoardHeight];

            piecesOnBoard = new List<IChessPiece>[6, 2];
            for (int type = 0; type < 6; ++type)
            {
                for (int color = 0; color < 2; ++color)
                {
                    piecesOnBoard[type, color] = new List<IChessPiece>();
                }
            }

            CurrentTurn = 0;
        }

        /// <summary>
        /// Places a piece on the board
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="xCoordinate"></param>
        /// <param name="yCoordinate"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Checks whether a position lies in the board coordinate system.
        /// </summary>
        /// <param name="xCoordinate"></param>
        /// <param name="yCoordinate"></param>
        /// <returns></returns>
        public bool IsLegalBoardPosition(int xCoordinate, int yCoordinate)
        {
            return (-1 < xCoordinate && xCoordinate < Width &&
                -1 < yCoordinate && yCoordinate < Height);
        }

        private void RemoveFromBoard(IChessPiece piece)
        {
            piece.XCoordinate = OffBoardCoordinate;
            piece.YCoordinate = OffBoardCoordinate;
        }
        
        /// <summary>
        /// Tries to fetch the piece at the specified coordinates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="piece"></param>
        /// <returns></returns>
        public bool TryGetPieceOn(int x, int y, out IChessPiece piece)
        {
            if(!IsLegalBoardPosition(x, y))
            {
                piece = null;
                return false;
            }
            piece = pieces[x, y];
            return (piece != null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xStart"></param>
        /// <param name="yStart"></param>
        /// <param name="xEnd"></param>
        /// <param name="yEnd"></param>
        /// <returns></returns>
        public bool IsStraightClearPathBetween(int xStart, int yStart, int xEnd, int yEnd)
        {
            if(!IsLegalBoardPosition(xStart, yStart))
            {
                return false;
            }

            if (!IsLegalBoardPosition(xEnd, yEnd))
            {
                return false;
            }

            int minX = Math.Min(xStart, xEnd);
            int maxX = Math.Max(xStart, xEnd);
            int minY = Math.Min(yStart, yEnd);
            int maxY = Math.Max(yStart, yEnd);

            if (xStart == xEnd)
            {
                return CheckVertical(minY, maxY, xStart);
            }
            if (yStart == yEnd)
            {
                return CheckHorizontal(minX, maxX, yStart);
            }
            if (xStart - xEnd == yStart - yEnd)
            {
                return CheckXEqualsY(minX, minY, maxX, maxY);
            }
            if (xStart - xEnd == yEnd - yStart)
            {
                return CheckXEqualsMinusY(minX, maxY, maxX, minY);
            }

            return false;
        }

        #region Check Clear paths on straight lines
        private bool CheckHorizontal(int left, int right, int y)
        {
            for(int x = left + 1; x < right - 1; ++x)
            {
                if(pieces[x, y] != null)
                {
                    return false;
                }
            }

            return true;
        }
        private bool CheckVertical(int bottom, int top, int x)
        {
            for (int y = bottom + 1; y < top - 1 - 1; ++y)
            {
                if (pieces[x, y] != null)
                {
                    return false;
                }
            }

            return true;
        }
        private bool CheckXEqualsY(int left, int bottom, int right, int top)
        {
            for (int x = left + 1; x < right - 1 - 1; ++x)
            {
                for (int y = bottom + 1; y < top - 1 - 1; ++y)
                {
                    if (pieces[x, y] != null)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        private bool CheckXEqualsMinusY(int left, int top, int right, int bottom)
        {
            for (int x = left + 1; x < right - 1 - 1; ++x)
            {
                for (int y = top - 1; y > bottom + 1; --y)
                {
                    if (pieces[x, y] != null)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Repositions a piece on the board.  Any pieces in the endpoint will be removed from the board
        /// </summary>
        /// <param name="move"></param>
        public void UpdateBoard(Move move)
        {
            if(move.Piece == null)
            {
                return;
            }

            if(!IsLegalBoardPosition(move.StartingX , move.StartingY))
            {
                RemoveFromBoard(move.Piece);
                return;
            }

            if (!IsLegalBoardPosition(move.EndingX, move.EndingY))
            {
                RemoveFromBoard(move.Piece);
                return;
            }

            pieces[move.StartingX, move.StartingY] = null;
            IChessPiece captured = pieces[move.EndingX, move.EndingY];
            pieces[move.EndingX, move.EndingY] = move.Piece;

            if(captured != null)
            {
                RemoveFromBoard(captured);
            }
        }

        #endregion
    }
}
