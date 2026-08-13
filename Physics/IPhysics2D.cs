namespace IceFebruary.Physics
{
    using IceFebruary.Shapes;
    using IceFebruary.Space;

    /// <summary>
    /// The main interface for controlling physics and overlapping. Controls the execution of overlapping.
    /// </summary>
    public interface IPhysics2D : IBaseEntity
    {
        /// <summary>
        /// Method for scanning physical objects in a certain area.
        /// </summary>
        int Overlap(IShape shape, Vector2 position, Rotor2 rotor, ContactFilter2D contactFilter2D, Component<ICollider2D>[] result = null);

        /// <summary>
        /// Method for scanning physical objects in a certain area.
        /// </summary>
        int Overlap(IShape shape, Vector2 position, float angle, ContactFilter2D contactFilter2D, Component<ICollider2D>[] result = null);
    }
}
