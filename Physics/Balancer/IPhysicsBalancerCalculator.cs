namespace IceFebruary.Physics.Balancer
{
    using IceFebruary.Space;

    /// <summary>
    /// Interface for the physics balancer calculator, which calculates the required angle for the physics balancer.
    /// </summary>
    public interface IPhysicsBalancerCalculator
    {
        /// <summary>
        /// Calculates the required angle for the physics balancer.
        /// </summary>
        Rotor2 CalculateAngle(Rotor2 currentRotation, Rotor2 targetAngle);
    }
}
