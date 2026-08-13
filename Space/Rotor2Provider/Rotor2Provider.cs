namespace IceFebruary.Space.Rotor2Provider
{
    using IceFebruary.Proxy;

    /// <summary>
    /// Rotor provider returning a static rotor.
    /// </summary>
    public sealed class Rotor2Provider : IRotor2Provider
    {
        private readonly Rotor2 _rotor2;

        /// <summary>
        /// Creates a new rotor provider returning a static rotor.
        /// </summary>
        [FieldProxy(typeof(IRotor2Provider))]
        public Rotor2Provider(Rotor2 rotor2)
        {
            _rotor2 = rotor2;
        }

        /// <summary>
        /// Returns a static rotor.
        /// </summary>
        public bool TryGet(out Rotor2 angle)
        {
            angle = _rotor2;
            return true;
        }
    }
}
