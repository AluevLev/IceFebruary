namespace IceFebruary
{
    using IceFebruary.Space;

    /// <summary>
    /// Interface that acts as a manager for creating game objects.
    /// </summary>
    public interface IObjectManager : IBaseEntity
    {
        /// <summary>
        /// Create a game object.
        /// </summary>
        IGameObject Create(IGameObject gameObject, Vector2 position, Rotor2 rotation);
    }
}
