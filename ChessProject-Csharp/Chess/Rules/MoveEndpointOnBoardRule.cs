﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring {
    class MoveEndpointOnBoardRule : IRule {
        public bool IsMoveValid(IChessBoard board, Move move)
        {
            return board.IsLegalBoardPosition(move.EndingX, move.EndingY);
        }
    }
}