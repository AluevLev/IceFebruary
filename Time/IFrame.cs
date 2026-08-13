namespace IceFebruary.Time
{
    /// <summary>
    /// Defines an object that listens to regular frame update ticks.
    /// </summary>
    public interface IFrame : IBaseEntity
    {
        /// <summary>
        /// Invoked every standard frame update step.
        /// </summary>
        void OnFrame(float frameLength);
    }
}
