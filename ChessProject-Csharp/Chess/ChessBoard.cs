using System;
using System.Collections.Generic;

namespace Gfi.Hiring
{
    /// <summary>
    /// Area where the game is played
    /// </summary>
    public class ChessBoard : IChessBoard
    {
        public static readonly int MaxBoardWidth = 7;
        public static readonly int MaxBoardHeight = 7;
        private readonly int _minBoardXPosition = 0;
        private readonly int _minBoardYPosition = 0;

        /// <summary>
        /// Coordinates used to indicate when a piece is not on the board.
        /// </summary>
        public static readonly int OffBoardCoordinate = -1;
        
        /// <summary>
        /// Game configuration
        /// </summary>
        private GameSettings _settings;

        /// <summary>
        /// Array of game squares.  Empty squares should contain null
        /// </summary>
        private IChessPiece[,] _pieces;

        public int Width {  get { return _settings.BoardWidth; } }
        public int Height { get { return _settings.BoardHeight; } }

        /// <summary>
        /// Number of turns since game start.
        /// </summary>
        public int CurrentTurn { get; private set; }

        private List<IChessPiece>[,] _piecesOnBoard; //int[type, color]
                
        public ChessBoard ()
        {
            InitBoard();
        }

        private void InitBoard()
        {
            // default settings for now
            _settings = new GameSettings();

            _pieces = new IChessPiece[_settings.BoardWidth, _settings.BoardHeight];

            _piecesOnBoard = new List<IChessPiece>[(int)PieceType.Count, (int)PieceColor.Count];
            for (int type = 0; type < (int)PieceType.Count; ++type)
            {
                for (int color = 0; color < (int)PieceColor.Count; ++color)
                {
                    _piecesOnBoard[type, color] = new List<IChessPiece>();
                }
            }

            CurrentTurn = 0;
        }

        /// <summary>
        /// Adds a piece to the board if the square isn't occupied
        /// </summary>
        /// <param name="piece">The piece to add to the board</param>
        /// <param name="x">The x coordinate of the square to place the piece at</param>
        /// <param name="y">The y coordinate of the square to place the piece at</param>
        /// <returns>True if the piece was added</returns>
        public bool Add(IChessPiece piece, int xCoordinate, int yCoordinate, PieceColor color)
        {
            if (!IsLegalBoardPosition(xCoordinate, yCoordinate))
            {
                RemoveFromBoard(piece);
                return false;
            }
            if (_piecesOnBoard[(int)PieceType.Pawn, (int)piece.Color].Count == _settings.MaxPawnsPerSide)
            {
                RemoveFromBoard(piece);
                return false;
            }

            if(_pieces[xCoordinate, yCoordinate] == null)
            {
                _pieces[xCoordinate, yCoordinate] = piece;
                piece.XCoordinate = xCoordinate;
                piece.YCoordinate = yCoordinate;
                _piecesOnBoard[(int)PieceType.Pawn, (int)piece.Color].Add(piece);
                return true;
            }
            else
            {
                RemoveFromBoard(piece);
                return false;
            }
        }

        /// <summary>
        /// Checks if the x, y coordinates are on the board
        /// </summary>
        /// <param name="x">The x coordinate of the square to check for</param>
        /// <param name="y">The y coordinate of the square to check for</param>
        /// <returns>True if the coordinates are a valid square on the board</returns>
        public bool IsLegalBoardPosition(int xCoordinate, int yCoordinate)
        {
            return !(xCoordinate < _minBoardXPosition || xCoordinate > MaxBoardWidth ||
                yCoordinate < _minBoardYPosition || yCoordinate > MaxBoardHeight);
        }

        private void RemoveFromBoard(IChessPiece piece)
        {
            piece.XCoordinate = OffBoardCoordinate;
            piece.YCoordinate = OffBoardCoordinate;
        }

        /// <summary>
        /// Checks if there is a piece on x, y
        /// </summary>
        /// <param name="x">The x coordinate of the square to check</param>
        /// <param name="y">The y coordinate of the square to check</param>
        /// <param name="piece">The piece on the square.  If the square is empty this is set to null</param>
        /// <returns>True if a piece was found on the targeted square</returns>
        public bool TryGetPieceOn(int x, int y, out IChessPiece piece)
        {
            if(!IsLegalBoardPosition(x, y))
            {
                piece = null;
                return false;
            }
            piece = _pieces[x, y];
            return (piece != null);
        }

        /// <summary>
        /// checks if there are no pieces between two points.  The points can be occupied, but no square in a straight line between them can be.
        /// If the line is not of the form x=c, y=c, x=y or x=-y returns false.
        /// </summary>
        /// <param name="xStart">The x coordinate of the square being moved from</param>
        /// <param name="yStart">The y coordinate of the square being moved from</param>
        /// <param name="xEnd">The x coordinate of the square being moved to</param>
        /// <param name="yEnd">The y coordinate of the square being moved to</param>
        /// <returns>True if the path is a straight line with no pieces between the squares</returns>
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
                return CheckVerticalSquaresEmpty(minY+1, maxY-1, xStart);
            }
            if (yStart == yEnd)
            {
                return CheckHorizontalSquaresEmpty(minX+1, maxX-1, yStart);
            }
            if (xStart - xEnd == yStart - yEnd)
            {
                return CheckXEqualsYSquaresAreEmpty(minX+1, minY+1, maxX-1, maxY-1);
            }
            if (xStart - xEnd == yEnd - yStart)
            {
                return CheckXEqualsMinusYSquaresAreEmpty(minX+1, maxY-1, maxX-1, minY+1);
            }

            return false;
        }

        #region Check Clear paths on straight lines
        private bool CheckHorizontalSquaresEmpty(int left, int right, int y)
        {
            for(int x = left; x < right; ++x)
            {
                if(_pieces[x, y] != null)
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckVerticalSquaresEmpty(int bottom, int top, int x)
        {
            for (int y = bottom; y < top - 1; ++y)
            {
                if (_pieces[x, y] != null)
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckXEqualsYSquaresAreEmpty(int left, int bottom, int right, int top)
        {
            for (int x = left; x < right - 1; ++x)
            {
                for (int y = bottom; y < top - 1; ++y)
                {
                    if (_pieces[x, y] != null)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool CheckXEqualsMinusYSquaresAreEmpty(int left, int top, int right, int bottom)
        {
            for (int x = left; x < right - 1; ++x)
            {
                for (int y = top; y > bottom; --y)
                {
                    if (_pieces[x, y] != null)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        #endregion

        public bool IsMoveValid(Move move)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Repositions a piece on the board.  Any pieces in the endpoint will be removed from the board
        /// </summary>
        /// <param name="move">Description of the move</param>
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

            _pieces[move.StartingX, move.StartingY] = null;
            IChessPiece captured = _pieces[move.EndingX, move.EndingY];
            _pieces[move.EndingX, move.EndingY] = move.Piece;

            if(captured != null)
            {
                RemoveFromBoard(captured);
            }
        }
    }
}
