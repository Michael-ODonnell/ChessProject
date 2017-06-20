namespace Gfi.Hiring {

    /// <summary>
    /// Composite of all the rules for a piece
    /// </summary>
    public interface IRuleSet : IRule {
        /// <summary>
        /// Returns all the rules in the set
        /// </summary>
        /// <returns></returns>
        IRule[] Rules();
    }
}
