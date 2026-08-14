namespace IceFebruary.Space.Vector2Provider
{
    using IceFebruary.Proxy;

    /// <summary>
    /// Base interface for dynamic vector evaluation strategies.
    /// Allows computing or retrieving spatial coordinates on demand.
    /// </summary>
    [InterfaceProxy]
    public interface IVector2Provider
    {
        /// <summary>
        /// Attempts to calculate or retrieve current vector coordinates.
        /// </summary>
        bool TryGet(out Vector2 value);
    }
}
