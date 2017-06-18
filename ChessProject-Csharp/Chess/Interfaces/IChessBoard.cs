using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring {
    /// <summary>
    /// Interface for a chessboard.  
    /// </summary>
    public interface IChessBoard {

        /// <summary>
        /// Width (number of columns) of the board
        /// </summary>
        int Width {get;}

        /// <summary>
        /// Height (number of rows) of the board
        /// </summary>
        int Height {get;}

        /// <summary>
        /// adds a piece to the board if the square isn't occupied
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        bool AddPiece(IChessPiece piece, int x, int y);

        /// <summary>
        /// checks if the x, y coordinates are on the board
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        bool IsLegalBoardPosition(int x, int y);
        
        /// <summary>
        /// returns true if there is a piece on x, y and assigns it to out var.  out var is null if there is no peice
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="piece"></param>
        /// <returns></returns>
        bool TryGetPieceOn(int x, int y, out IChessPiece piece);

        /// <summary>
        /// Current Turn Id.  0 on ititial board state, 1, during white first move, increments each turn
        /// </summary>
        int CurrentTurn { get; }
    }
}
