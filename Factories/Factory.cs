namespace IceFebruary.Factories
{
    using IceFebruary;
    using IceFebruary.Space;

    /// <summary>
    /// Wrapper factory that instantiates game objects via an underlying object manager and automatically initializes them using a specified config setup handler.
    /// </summary>
    public sealed class Factory<TSettableUp, TConfig> : BaseEntity, IObjectManager where TSettableUp : ISettableUp<TConfig> where TConfig : class
    {
        private readonly IObjectManager _objectManager;
        private readonly TSettableUp _factory;

        /// <summary>
        /// Creates a new instance of the factory with a base object manager and a target setup handler.
        /// </summary>
        public Factory(IObjectManager objectManager, TSettableUp factory)
        {
            _objectManager = objectManager;
            _factory = factory;
        }

        /// <summary>
        /// Spawns a game object at a specified position and rotation and extracts its root config.
        /// </summary>
        public IGameObject Create(IGameObject prefab, Vector2 position, Rotor2 rotation)
        {
            if (_factory == null || !prefab.Exists() || !_objectManager.Exists())
                return null;

            IGameObject created = _objectManager.Create(prefab, position, rotation);

            if (!created.TryGetRootConfig(out TConfig rootConfig))
                return null;

            _factory.SetUp(rootConfig);

            return created;
        }
    }
}
