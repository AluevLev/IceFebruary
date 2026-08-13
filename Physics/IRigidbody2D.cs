namespace IceFebruary.Physics
{
    using IceFebruary.Proxy;
    using IceFebruary.Space;

    /// <summary>
    /// Interface that is an implementation of a physical body that responds to gravity and external forces.
    /// </summary>
    [InterfaceProxy]
    public interface IRigidbody2D : IBaseEntity
    {
        /// <summary>
        /// Linear velocity of a physical object.
        /// </summary>
        Vector2 LinearVelocity { get; set; }

        /// <summary>
        /// Angular velocity of a physical object.
        /// </summary>
        float AngularVelocity { get; set; }

        /// <summary>
        /// Position of a physical object.
        /// </summary>
        Vector2 Position { get; set; }

        /// <summary>
        /// Rotation of a physical object.
        /// </summary>
        Rotor2 Rotation { get; set; }

        /// <summary>
        /// Imbuing a physical object with external force.
        /// </summary>
        void AddForce(Vector2 force, ForceMode2D forceMode);

        /// <summary>
        /// Imbuing a physical object with external torque.
        /// </summary>
        void AddTorque(float torque, ForceMode2D forceMode);

        /// <summary>
        /// Moves the physical body into position.
        /// </summary>
        void MovePosition(Vector2 position);

        /// <summary>
        /// Rotates the physical body into rotation.
        /// </summary>
        void MoveRotation(Rotor2 rotation);
    }
}
