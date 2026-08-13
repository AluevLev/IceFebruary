namespace IceFebruary.Space.Rotor2Provider
{
    using IceFebruary.Proxy;

    /// <summary>
    /// Rotor provider returning the transform rotation.
    /// </summary>
    public sealed class TransformRotor2Provider : IRotor2Provider
    {
        private readonly ITransform _transform;

        /// <summary>
        /// Creates a new rotor provider returning the transform position.
        /// </summary>
        [FieldProxy(typeof(IRotor2Provider))]
        public TransformRotor2Provider(ITransform transform)
        {
            _transform = transform;
        }

        /// <summary>
        /// Returns the transform rotation.
        /// </summary>
        public bool TryGet(out Rotor2 angle)
        {
            bool success = _transform.Exists();

            angle = success ? _transform.Rotation : Rotor2.Default;

            return success;
        }
    }
}
