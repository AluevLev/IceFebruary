namespace IceFebruary.Shapes
{
    using IceFebruary.Proxy;

    /// <summary>
    /// Circle shape.
    /// </summary>
    public sealed class Circle : IShape
    {
        /// <summary>
        /// Circle radius.
        /// </summary>
        public float Radius { get; private init; }

        /// <summary>
        /// Creates a new circle with a given radius.
        /// </summary>
        [FieldProxy(typeof(IShape))]
        public Circle(float radius)
        {
            Radius = Math.Abs(radius);
        }
    }
}
