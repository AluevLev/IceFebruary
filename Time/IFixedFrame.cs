namespace IceFebruary.Time
{
    /// <summary>
    /// Defines an object that listens to fixed update ticks.
    /// </summary>
    public interface IFixedFrame : IBaseEntity
    {
        /// <summary>
        /// Invoked every fixed update tick step.
        /// </summary>
        void OnFixedFrame();
    }
}
