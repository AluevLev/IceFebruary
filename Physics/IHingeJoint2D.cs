namespace IceFebruary.Physics
{
    using IceFebruary.Proxy;
    using IceFebruary.Space;

    /// <summary>
    /// Interface that represents an implementation of a physical joint.
    /// </summary>
    [InterfaceProxy]
    public interface IHingeJoint2D : IBaseEntity
    {
        /// <summary>
        /// Joint anchor.
        /// </summary>
        Vector2 Anchor { get; set; }

        /// <summary>
        /// Body attached to joint.
        /// </summary>
        IRigidbody2D ConnectedBody { get; set; }
    }
}

