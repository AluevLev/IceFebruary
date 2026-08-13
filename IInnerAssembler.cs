namespace IceFebruary
{
    using IceFebruary.Time;

    /// <summary>
    /// Interface that represents the functions of the assembler part.
    /// </summary>
    public interface IInnerAssembler
    {
        /// <summary>
        /// Assemble the game.
        /// </summary>
        void Assemble();

        /// <summary>
        /// Core game time.
        /// </summary>
        ITime Time { get; }
    }
}
