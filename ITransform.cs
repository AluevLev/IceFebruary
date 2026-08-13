namespace IceFebruary
{
    using IceFebruary.Proxy;
    using IceFebruary.Space;

    /// <summary>
    /// Game object interface that stores the object's position, rotation, and scale.
    /// </summary>
    [InterfaceProxy]
    public interface ITransform : IBaseEntity
    {
        /// <summary>
        /// Position of the game object in the world.
        /// </summary>
        Vector2 Position { get; set; }

        /// <summary>
        /// Rotation of the game object in the world.
        /// </summary>
        Rotor2 Rotation { get; set; }

        /// <summary>
        /// Local position of the game object.
        /// </summary>
        Vector2 LocalPosition { get; set; }

        /// <summary>
        /// Local rotation of the game object.
        /// </summary>
        Rotor2 LocalRotation { get; set; }

        /// <summary>
        /// Local scale of the game object.
        /// </summary>
        Vector2 LocalScale { get; set; }

        /// <summary>
        /// Compute a direction by transforming coordinates in the target transformation space.
        /// </summary>
        Vector2 TransformDirection(Vector2 direction);

        /// <summary>
        /// Compute a point by transforming coordinates in the target transformation space.
        /// </summary>
        Vector2 TransformPoint(Vector2 point);
    }
}
