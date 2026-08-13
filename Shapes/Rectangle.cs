namespace IceFebruary.Shapes
{
    using IceFebruary.Proxy;
    using IceFebruary.Space;

    /// <summary>
    /// Rectangle shape.
    /// </summary>
    public sealed class Rectangle : IShape
    {
        /// <summary>
        /// Rectangle size.
        /// </summary>
        public Vector2 Size { get; private init; }

        /// <summary>
        /// Creates a new rectangle with a given size.
        /// </summary>
        [FieldProxy(typeof(IShape))]
        public Rectangle(Vector2 size)
        {
            Size = size;
        }
    }
}
