namespace IceFebruary.Shapes
{
    /// <summary>
    /// Dot shape.
    /// </summary>
    public sealed class Dot : IShape
    {
        /// <summary>
        /// Dot shape instance.
        /// </summary>
        public static readonly Dot Instance = new();
        private Dot() { }
    }
}
