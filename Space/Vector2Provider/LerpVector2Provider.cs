namespace IceFebruary.Space.Vector2Provider
{
    using IceFebruary.Proxy;

    /// <summary>
    /// Vector provider that calculates lerp between vectorsю
    /// </summary>
    public sealed class LerpVector2Provider : IVector2Provider
    {
        private readonly IVector2Provider _first;
        private readonly IVector2Provider _second;
        private readonly float _interpolation;

        /// <summary>
        /// A vector provider that calculates lerp between vectors.
        /// Creates a new vector provider that calculates lerp between vectors.
        /// The value of the coefficient <paramref name="interpolation"/> is automatically clamped between 0 and 1.
        /// </summary>
        [FieldProxy(typeof(IVector2Provider))]
        public LerpVector2Provider(IVector2Provider first, IVector2Provider second, float interpolation)
        {
            _first = first;
            _second = second;
            _interpolation = interpolation;
        }

        /// <summary>
        /// Returns lerp between vectors.
        /// </summary>
        public bool TryGet(out Vector2 point)
        {
            if (_first.TryGetSafety(out Vector2 first) && _second.TryGetSafety(out Vector2 second))
            {
                point = Vector2.Lerp(first, second, _interpolation);
                return true;
            }

            point = default;
            return false;
        }
    }
}
