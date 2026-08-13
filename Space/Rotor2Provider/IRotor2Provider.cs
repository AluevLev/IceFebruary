namespace IceFebruary.Space.Rotor2Provider
{
    using IceFebruary.Proxy;

    /// <summary>
    /// Base interface for dynamic rotor evaluation strategies.
    /// Allows computing or retrieving rotors on demand.
    /// </summary>
    [InterfaceProxy]
    public interface IRotor2Provider
    {
        /// <summary>
        /// 
        /// </summary>
        bool TryGet(out Rotor2 value);
    }
}
