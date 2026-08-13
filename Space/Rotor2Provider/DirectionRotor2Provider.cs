namespace IceFebruary.Space.Rotor2Provider
{
    using IceFebruary.Proxy;
    using IceFebruary.Space.Vector2Provider;

    /// <summary>
    /// Rotor provider that calculates rotation in a direction from one point to another.
    /// </summary>
    public sealed class DirectionRotor2Provider : IRotor2Provider
    {
        private readonly IVector2Provider _from;
        private readonly IVector2Provider _to;

        /// <summary>
        /// Creates a new rotor provider that calculates rotation in the direction from one point to another.
        /// </summary>
        [FieldProxy(typeof(IRotor2Provider))]
        public DirectionRotor2Provider(IVector2Provider from, IVector2Provider to)
        {
            _from = from;
            _to = to;
        }

        /// <summary>
        /// Returns rotation in the direction from one point to another.
        /// </summary>
        public bool TryGet(out Rotor2 angle)
        {
            if (_from.TryGetSafety(out Vector2 from) && _to.TryGetSafety(out Vector2 to))
            {
                angle = new(from.DirectionTo(to).Normalized);
                return true;
            }

            angle = Rotor2.Default;
            return false;
        }
    }
}
