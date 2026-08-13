namespace IceFebruary.Render
{
    using IceFebruary.Proxy;
    using IceFebruary.Space;

    /// <summary>
    /// Interface for managing camera.
    /// </summary>
    [InterfaceProxy]
    public interface ICamera : IBaseEntity
    {
        /// <summary>
        /// Translates the position on screen to the world position.
        /// </summary>
        Vector2 ScreenToWorldPoint(Vector2 onScreenPosition);

        /// <summary>
        /// Translates the world position to the position on screen.
        /// </summary>
        Vector2 WorldToScreenPoint(Vector2 inWorldPosition);

        /// <summary>
        /// Camera size.
        /// </summary>
        float Size { get; set; }
    }
}
