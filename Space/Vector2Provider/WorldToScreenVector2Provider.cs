namespace IceFebruary.Space.Vector2Provider
{
    using IceFebruary;
    using IceFebruary.Proxy;
    using IceFebruary.Render;
    using IceFebruary.Space;

    /// <summary>
    /// Vector provider that maps a vector from the world to a vector in the screen.
    /// </summary>
    public sealed class WorldToScreenVector2Provider : IVector2Provider
    {
        private readonly IVector2Provider _vector2;
        private readonly ICamera _mainCamera;

        /// <summary>
        /// Creates a new vector provider that maps a vector from the world to a vector in the screen.
        /// </summary>
        [FieldProxy(typeof(IVector2Provider))]
        public WorldToScreenVector2Provider(IVector2Provider inputProvider, ICamera camera)
        {
            _vector2 = inputProvider;
            _mainCamera = camera;
        }

        /// <summary>
        /// Returns the vector mapped from the world to the screen.
        /// </summary>
        public bool TryGet(out Vector2 point)
        {
            if (_mainCamera.Exists() && _vector2.TryGetSafety(out Vector2 vector2))
            {
                point = _mainCamera.WorldToScreenPoint(vector2);
                return true;
            }

            point = default;
            return false;
        }
    }
}
