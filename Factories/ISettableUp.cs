namespace IceFebruary.Factories
{
    /// <summary>
    /// Defines an object that can be initialized or set up with a config data structure.
    /// </summary>
    public interface ISettableUp<T>
    {
        /// <summary>
        /// Configures the object using the provided config data.
        /// </summary>
        void SetUp(T config);
    }

    /// <summary>
    /// Defines an object that can be initialized with a config and returns a result upon setup.
    /// </summary>
    public interface ISettableUp<T, TRet>
    {
        /// <summary>
        /// Configures the object using the provided config data and returns a specific result.
        /// </summary>
        TRet SetUp(T config);
    }
}
