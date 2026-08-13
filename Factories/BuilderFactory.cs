namespace IceFebruary.Factories
{
    using IceFebruary;
    using IceFebruary.Space;
    using System;

    /// <summary>
    /// Factory for creating and initializing builders using game object prefabs and root configs.
    /// </summary>
    public sealed class BuilderFactory<TBuilder, TConfig> : BaseEntity where TBuilder : ISettableUp<TConfig> where TConfig : class
    {
        private readonly IObjectManager _objectManager;
        private readonly Func<TBuilder> _builderFactory;

        /// <summary>
        /// Creates a new factory for creating and initializing builders using game object prefabs and root configs.
        /// </summary>
        public BuilderFactory(IObjectManager objectManager, Func<TBuilder> builderFactory)
        {
            _objectManager = objectManager;
            _builderFactory = builderFactory;
        }

        /// <summary>
        /// Spawns a game object at a specified position and rotation, extracts its root config, and returns an initialized builder instance.
        /// </summary>
        public TBuilder Create(IGameObject prefab, Vector2 position, Rotor2 rotation)
        {
            if (_builderFactory == null ||
                !prefab.Exists() ||
                !_objectManager.Exists() ||
                !_objectManager.Create(prefab, position, rotation).TryGetRootConfig(out TConfig rootConfig))
                return default;

            TBuilder builder = _builderFactory.Invoke();

            builder.SetUp(rootConfig);

            return builder;
        }
    }
}
