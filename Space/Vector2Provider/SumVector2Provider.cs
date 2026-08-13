namespace IceFebruary.Space.Vector2Provider
{
    using IceFebruary.Proxy;

    /// <summary>
    /// Vector provider that sums vectors.
    /// </summary>
    public sealed class SumVector2Provider : IVector2Provider
    {
        private readonly IVector2Provider _first;
        private readonly IVector2Provider _second;

        /// <summary>
        /// Creates a new vector provider that sums vectors.
        /// </summary>
        [FieldProxy(typeof(IVector2Provider))]
        public SumVector2Provider(IVector2Provider first, IVector2Provider second)
        {
            _first = first;
            _second = second;
        }

        /// <summary>
        /// Returns the sum of the vectors.
        /// </summary>
        public bool TryGet(out Vector2 point)
        {
            if (_first.TryGetSafety(out Vector2 first) && _second.TryGetSafety(out Vector2 second))
            {
                point = first + second;
                return true;
            }

            point = default;
            return false;
        }
    }
}
