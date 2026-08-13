namespace IceFebruary.Space.Vector2Provider
{
    using IceFebruary.Proxy;

    /// <summary>
    /// Vector provider returning the transform position.
    /// </summary>
    public sealed class TransformVector2Provider : IVector2Provider
    {
        private readonly ITransform _transform;

        /// <summary>
        /// Creates a new vector provider returning the transform position.
        /// </summary>
        [FieldProxy(typeof(IVector2Provider))]
        public TransformVector2Provider(ITransform transform)
        {
            _transform = transform;
        }

        /// <summary>
        /// Returns the transform position.
        /// </summary>
        public bool TryGet(out Vector2 point)
        {
            bool success = _transform.Exists();

            point = success ? _transform.Position : default;

            return success;
        }
    }
}
