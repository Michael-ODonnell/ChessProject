using NSubstitute;
using NUnit.Framework;

namespace Gfi.Hiring {
    [TestFixture]
    public class ChessPiece_Tests : IChessPiece_Tests {

        protected override IChessPiece CreatePiece(PieceType type, PieceColor color)
        {
            return new ChessPiece(type, color);
        }
    }
}
