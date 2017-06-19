using System;

namespace Gfi.Hiring {

    /// <summary>
    /// Constructs pieces. Centralises the addition of rules to pieces
    /// </summary>
    internal class PieceFactory {

        private IChessBoard _board;

        /// <summary>
        /// One factory per board.
        /// </summary>
        /// <param name="board"></param>
        public PieceFactory (IChessBoard board)
        {
            _board = board;
        }

        /// <summary>
        /// Create an instance of a type of piece with the associated default ruleset
        /// </summary>
        /// <param name="type">The type of piece to be created</param>
        /// <param name="color">The side the piece will be on</param>
        /// <returns>The created peice</returns>
        public IChessPiece Build(PieceType type, PieceColor color)
        {
            switch (type)
            {
                case PieceType.Pawn:
                    return CreatePawn(color);
                default:
                    throw new ArgumentException("No constructor found for " + type);
            }
        }

        /// <summary>
        /// Creates a default pawn
        /// </summary>
        /// <param name="color">The side the piece will be on</param>
        /// <returns>A new pawn with all the required rules</returns>
        private IChessPiece CreatePawn(PieceColor color)
        {
            IRule[] pawnRules = new IRule[] {
                new EndpointSquareOccupiedRule(),
                new CannotMoveToSameSquareRule(),
                new EndpointSquareOccupiedRule(),
                new CannotMoveThroughPiecesRule(),
                new ValidPawnMoveRule()};
            Pawn pawn = new Pawn(_board, color, pawnRules);

            return pawn;
        }
    }
}
