namespace IceFebruary
{
    using IceFebruary.Proxy;

    [InterfaceProxy]
    public interface IGameObject : IBaseEntity
    {
        ITransform Transform { get; }
        int Layer { get; set; }
        IBaseEntity MainComponent { get; set; }
        bool TryGetRootConfig<T>(out T rootConfig) where T : class;
    }
}
