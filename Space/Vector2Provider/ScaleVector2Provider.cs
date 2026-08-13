namespace IceFebruary.Space.Vector2Provider
{
    using IceFebruary.Proxy;

    /// <summary>
    /// Vector provider that calculates a vector multiplied by a specified number.
    /// </summary>
    public sealed class ScaleVector2Provider : IVector2Provider
    {
        private readonly IVector2Provider _vector2;
        private readonly float _scale;

        /// <summary>
        /// Creates a new vector provider that calculates a vector multiplied by a specified number.
        /// </summary>
        [FieldProxy(typeof(IVector2Provider))]
        public ScaleVector2Provider(IVector2Provider pointProvider, float scale)
        {
            _vector2 = pointProvider;
            _scale = scale;
        }

        /// <summary>
        /// Returns a vector multiplied by a specified number.
        /// </summary>
        public bool TryGet(out Vector2 point)
        {
            bool success = _vector2.TryGetSafety(out Vector2 vector2);

            point = success ? vector2 * _scale : default;

            return success;
        }
    }
}
