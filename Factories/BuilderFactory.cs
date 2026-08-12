namespace IceFebruary.Factories
{
    using IceFebruary;
    using IceFebruary.Space;
    using System;

    public sealed class BuilderFactory<TBuilder, TConfig> : BaseEntity where TBuilder : ISettableUp<TConfig> where TConfig : class
    {
        private readonly IObjectManager _objectManager;
        private readonly Func<TBuilder> _builderFactory;
        public BuilderFactory(IObjectManager objectManager, Func<TBuilder> builderFactory)
        {
            _objectManager = objectManager;
            _builderFactory = builderFactory;
        }
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
