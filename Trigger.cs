namespace IceFebruary
{
    using IceFebruary.Time;

    /// <summary>
    /// Class that represents a trigger that can be active for exactly one physical frame.
    /// </summary>
    public sealed class Trigger : BaseEntity, IFixedFrame
    {
        private bool _charged;

        /// <summary>
        /// True, if the trigger is active.
        /// </summary>
        public bool Active { get; private set; }

        /// <summary>
        /// Charge the trigger.
        /// </summary>
        public void Charge() => _charged = true;

        /// <summary>
        /// Physical frame method that calculates trigger activity.
        /// </summary>
        public void OnFixedFrame()
        {
            Active = _charged && Enabled;
            _charged = false;
        }

        /// <summary>
        /// Creates a new trigger that can be active for exactly one physical frame.
        /// </summary>
        public Trigger() { }
    }
}
