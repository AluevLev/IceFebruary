namespace IceFebruary.Space.Vector2Provider
{
    using IceFebruary.Proxy;

    /// <summary>
    /// Vector provider returning a static vector.
    /// </summary>
    public sealed class Vector2Provider : IVector2Provider
    {
        private readonly Vector2 _vector2;

        /// <summary>
        /// Creates a new vector provider returning a static vector.
        /// </summary>
        [FieldProxy(typeof(IVector2Provider))]
        public Vector2Provider(Vector2 vector2)
        {
            _vector2 = vector2;
        }

        /// <summary>
        /// Returns a static vector.
        /// </summary>
        public bool TryGet(out Vector2 point)
        {
            point = _vector2;
            return true;
        }
    }
}
