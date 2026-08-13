namespace IceFebruary.Space.Vector2Provider
{
    /// <summary>
    /// Extensions class for vector provider.
    /// </summary>
    public static class Vector2ProviderExtensions
    {
        /// <summary>
        /// Checks for null and attempts to calculate or get the current vector.
        /// </summary>
        public static bool TryGetSafety(this IVector2Provider vector2Provider, out Vector2 value)
        {
            if (vector2Provider != null)
                return vector2Provider.TryGet(out value);
            value = default;
            return false;
        }
    }
}
