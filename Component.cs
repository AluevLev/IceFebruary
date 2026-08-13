namespace IceFebruary
{
    /// <summary>
    /// Immutable structure that represents a link between a component and the game object it is attached to.
    /// </summary>
    public readonly struct Component<T> where T : class, IBaseEntity
    {
        /// <summary>
        /// Creates a new structure that represents a link between a component and the game object it is attached to.
        /// </summary>
        public Component(T component, IGameObject gameObject)
        {
            Value = component;
            GameObject = gameObject;
        }

        /// <summary>
        /// Structure component itself.
        /// </summary>
        public T Value { get; private init; }

        /// <summary>
        /// Game object to which the component is called.
        /// </summary>
        public IGameObject GameObject { get; private init; }
    }
}
