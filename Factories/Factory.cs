namespace IceFebruary.Factories
{
    using IceFebruary;
    using IceFebruary.Space;

    public sealed class Factory<TSettableUp, TConfig> : BaseEntity, IObjectManager where TSettableUp : ISettableUp<TConfig> where TConfig : class
    {
        private readonly IObjectManager _objectManager;
        private readonly TSettableUp _factory;
        public Factory(IObjectManager objectManager, TSettableUp factory)
        {
            _objectManager = objectManager;
            _factory = factory;
        }
        public IGameObject Create(IGameObject prefab, Vector2 position, Rotor2 rotation)
        {
            if (_factory == null ||
                !prefab.Exists() ||
                !_objectManager.Exists())
                return null;

            IGameObject created = _objectManager.Create(prefab, position, rotation);

            if (!created.TryGetRootConfig(out TConfig rootConfig))
                return null;

            _factory.SetUp(rootConfig);

            return created;
        }
    }
}
