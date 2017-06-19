namespace Gfi.Hiring {
    public interface IPawn : IChessPiece {
        /// <summary>
        /// Indicates the turn when the piece was first moved
        /// </summary>
        int FirstMovedOn { get; }
    }
}
