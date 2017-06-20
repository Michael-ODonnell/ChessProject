using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring {
    internal class UniversalRules : IRuleSet {

        protected List<IRule> _rules;

        public UniversalRules()
        {
            _rules = new List<IRule>();
            _rules.Add(new MoveEndpointOnBoardRule());
            _rules.Add(new EndpointSquareOccupiedRule());
            _rules.Add(new CannotMoveToSameSquareRule());
        }

        public bool IsMoveValid(IChessBoard board, Move move)
        {
            foreach (IRule rule in _rules)
            {
                if (!rule.IsMoveValid(board, move))
                {
                    return false;
                }
            }

            return true;
        }

        public IRule[] Rules()
        {
            return _rules.ToArray();
        }
    }
}
