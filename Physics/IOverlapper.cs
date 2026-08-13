namespace IceFebruary.Physics
{
    using IceFebruary;

    /// <summary>
    /// Interface that is a scanner of physical objects in a certain area.
    /// </summary>
    public interface IOverlapper : IBaseEntity
    {
        /// <summary>
        /// Colliders that are the results of scanning.
        /// </summary>
        Component<ICollider2D>[] Colliders2D { get; }

        /// <summary>
        /// Actual buffer length for colliders.
        /// </summary>
        int Colliders2DActualLength { get; }

        /// <summary>
        /// Method for scanning physical objects in a certain area.
        /// </summary>
        void Overlap();
    }
}
