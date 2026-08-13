namespace IceFebruary.Physics.Balancer
{
    using IceFebruary;
    using IceFebruary.Space;
    using IceFebruary.Space.Follow;
    using IceFebruary.Space.Rotor2Provider;
    using IceFebruary.Time;

    /// <summary>
    /// A physics balancer that stabilizes and maintains a given angle of rotation of a rigidbody.
    /// </summary>
    public sealed class PhysicsBalancer : BaseEntity, ITargetPossessing<IRotor2Provider>, IFixedFrame
    {
        private readonly IRigidbody2D _physicsBody;
        private readonly IPhysicsBalancerCalculator _physicsBalancerCalculator;

        private readonly IRotor2Provider _defaultAngleProvider;
        private IRotor2Provider _targetAngle;

        /// <summary>
        /// Creates a new physical balancer for rigid body.
        /// </summary>
        public PhysicsBalancer(IRigidbody2D physics, IPhysicsBalancerCalculator physicsBalancerCalculator, IRotor2Provider defaultAngleProvider = null)
        {
            _physicsBody = physics;
            _defaultAngleProvider = defaultAngleProvider;
            _physicsBalancerCalculator = physicsBalancerCalculator;

            SetTarget(_defaultAngleProvider);
        }

        /// <summary>
        /// Sets a new target for the physics balancer.
        /// </summary>
        public void SetTarget(IRotor2Provider targetProvider) => _targetAngle = targetProvider;

        /// <summary>
        /// Sets a default target for the physics balancer.
        /// </summary>
        public void ResetTarget() => _targetAngle = _defaultAngleProvider;

        /// <summary>
        /// A physics frame method that calculates and applies rotation to a body.
        /// </summary>
        public void OnFixedFrame()
        {
            if (!Enabled ||
                !_physicsBody.Exists() ||
                _physicsBalancerCalculator == null ||
                !_targetAngle.TryGetSafety(out Rotor2 angle))
                return;

            Rotor2 rotation = _physicsBalancerCalculator.CalculateAngle(_physicsBody.Rotation, angle);

            _physicsBody.MoveRotation(rotation);
        }
    }
}
