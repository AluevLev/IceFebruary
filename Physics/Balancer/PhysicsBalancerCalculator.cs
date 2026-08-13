namespace IceFebruary.Physics.Balancer
{
    using IceFebruary;
    using IceFebruary.Space;

    /// <summary>
    /// Сlass representing one implementation of a physics balancer calculator that calculates the required angle by interpolating rotors.
    /// </summary>
    public sealed class PhysicsBalancerCalculator : IPhysicsBalancerCalculator
    {
        private readonly float _force;

        /// <summary>
        /// Creates a new physics balancer calculator for physics balancer.
        /// </summary>
        public PhysicsBalancerCalculator(float interpolation)
        {
            _force = interpolation.Clamp01();
        }

        /// <summary>
        /// Returns the result of the lerp of the provided angles.
        /// </summary>
        public Rotor2 CalculateAngle(Rotor2 currentRotation, Rotor2 targetAngle) => Rotor2.Lerp(currentRotation, targetAngle, _force);
    }
}
