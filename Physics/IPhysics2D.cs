namespace IceFebruary.Physics
{
    using IceFebruary.Shapes;
    using IceFebruary.Space;

    /// <summary>
    /// Main interface for controlling physics and overlapping.
    /// Controls the execution of overlapping.
    /// </summary>
    public interface IPhysics2D : IBaseEntity
    {
        /// <summary>
        /// Scans physical objects in a certain area.
        /// </summary>
        int Overlap(IShape shape, Vector2 position, Rotor2 rotor, ContactFilter2D contactFilter2D, Component<ICollider2D>[] result = null);

        /// <summary>
        /// Scans physical objects in a certain area.
        /// </summary>
        int Overlap(IShape shape, Vector2 position, float angle, ContactFilter2D contactFilter2D, Component<ICollider2D>[] result = null);
    }
}
