namespace IceFebruary
{
    using IceFebruary.Proxy;

    /// <summary>
    /// Interface that represents the functions of a regular game object.
    /// </summary>
    [InterfaceProxy]
    public interface IGameObject : IBaseEntity
    {
        /// <summary>
        /// Сomponent that stores the position, rotation, and scale of an object.
        /// </summary>
        ITransform Transform { get; }

        /// <summary>
        /// Physical layer on which the object resides.
        /// </summary>
        int Layer { get; set; }

        /// <summary>
        /// Main component that implements the object.
        /// </summary>
        IBaseEntity MainComponent { get; set; }

        /// <summary>
        /// Attempting to get the root config from an object.
        /// </summary>
        bool TryGetRootConfig<T>(out T rootConfig) where T : class;
    }
}
