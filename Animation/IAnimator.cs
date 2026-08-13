namespace IceFebruary.Animation
{
    using IceFebruary.Proxy;

    /// <summary>
    /// Interface for managing entity animations via a hash of variables.
    /// </summary>
    [InterfaceProxy]
    public interface IAnimator : IBaseEntity
    {
        /// <summary>
        /// Returns the current value of the variable by its hash.
        /// </summary>
        T Get<T>(int hash) where T : struct;

        /// <summary>
        /// Sets a new value for the animation parameter.
        /// </summary>
        void Set<T>(int hash, T value) where T : struct;

        /// <summary>
        /// Activates an animation trigger by its hash.
        /// </summary>
        void ActivateTrigger(int hash);
    }
}
