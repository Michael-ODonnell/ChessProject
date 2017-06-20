namespace Gfi.Hiring {
    public class GameSettings {

        private const int DefaultBoardWidth = 8;
        private const int DefaultBoardHeight = 8;
        private const int DefaultPawnsPerSide = 7;

        public int MaxPawnsPerSide { get; private set; }

        public int BoardWidth { get; private set; }
        public int BoardHeight { get; private set; }

        private IRuleSet[] _pieceRules;

        /// <summary>
        /// Games settings struct.  Can use named params to configure settings individually
        /// </summary>
        /// <param name="boardWidth">Width of the chess board</param>
        /// <param name="boardHeight">Height of the chess board</param>
        /// <param name="pawnsPerSide">Maximum pawns on board per side</param>
        public GameSettings(int boardWidth = DefaultBoardWidth, int boardHeight = DefaultBoardHeight, int pawnsPerSide = DefaultPawnsPerSide)
        {
            BoardWidth = boardWidth;
            BoardHeight = boardHeight;
            MaxPawnsPerSide = pawnsPerSide;

            _pieceRules = new IRuleSet[(int)PieceType.Count];

            SetRules();
        }

        protected virtual void SetRules()
        {
            _pieceRules[(int)PieceType.Pawn] = new DefaultPawnRules();
        }

        public IRuleSet GetRulesFor(PieceType type)
        {
            return _pieceRules[(int)type];
        }
    }
}
