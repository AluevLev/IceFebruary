namespace IceFebruary.Space.Rotor2Provider
{
    using IceFebruary.Proxy;

    /// <summary>
    /// Rotor provider that converts rotor value through target transform space.
    /// </summary>
    public sealed class SpaceRotor2Provider : IRotor2Provider
    {
        private readonly IRotor2Provider _angleProvider;
        private readonly ITransform _space;

        /// <summary>
        /// Creates a new rotor provider with local source rotor and target transform space context.
        /// </summary>
        [FieldProxy(typeof(IRotor2Provider))]
        public SpaceRotor2Provider(IRotor2Provider angleProvider, ITransform space)
        {
            _space = space;
            _angleProvider = angleProvider;
        }

        /// <summary>
        /// Returns the calculated rotation by transforming rotor through the target transformation space.
        /// </summary>
        public bool TryGet(out Rotor2 angle)
        {
            if (_space.Exists() && _angleProvider.TryGetSafety(out Rotor2 startAngle))
            {
                angle = _space.Rotation.Inverse * startAngle;
                return true;
            }

            angle = Rotor2.Default;
            return false;
        }
    }
}
