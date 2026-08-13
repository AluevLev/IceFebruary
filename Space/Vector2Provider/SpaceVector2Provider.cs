namespace IceFebruary.Space.Vector2Provider
{
    using IceFebruary.Proxy;

    /// <summary>
    /// Vector provider that converts vector coordinates through target transform space.
    /// </summary>
    public sealed class SpaceVector2Provider : IVector2Provider
    {
        private readonly IVector2Provider _vector2;
        private readonly ITransform _space;

        /// <summary>
        /// Creates a vector provider with local source vector and target transform space context.
        /// </summary>
        [FieldProxy(typeof(IVector2Provider))]
        public SpaceVector2Provider(IVector2Provider vector2, ITransform space)
        {
            _space = space;
            _vector2 = vector2;
        }

        /// <summary>
        /// Returns the calculated position by transforming vector coordinates through the target transformation space.
        /// </summary>
        public bool TryGet(out Vector2 point)
        {
            if (_space.Exists() && _vector2.TryGetSafety(out Vector2 vector2))
            {
                point = _space.TransformPoint(vector2);
                return true;
            }

            point = default;
            return false;
        }
    }
}
