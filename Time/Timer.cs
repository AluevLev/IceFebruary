namespace IceFebruary.Time
{
    /// <summary>
    /// Сooldown timer class.
    /// </summary>
    public sealed class Timer
    {
        private readonly ITime _time;
        private readonly float _cooldown;
        private float _endTime;

        /// <summary>
        /// Indicates whether the timer is currently ticking and cooldown is active.
        /// </summary>
        public bool InCoolDown => _time.Exists() && _endTime > _time.CurrentTime;

        /// <summary>
        /// Creates a new instance of the timer utility with a base time source and cooldown duration.
        /// </summary>
        public Timer(ITime time, float cooldown)
        {
            _time = time;
            _cooldown = cooldown;
        }

        /// <summary>
        /// Sets the cooldown cycle.
        /// </summary>
        public void SetCooldown() => _endTime = _time.Exists() ? (_time.CurrentTime + _cooldown) : -1f;

        /// <summary>
        /// Forces the timer to reset, making the cooldown cycle finish immediately.
        /// </summary>
        public void ResetCooldown() => _endTime = -1f;
    }
}
