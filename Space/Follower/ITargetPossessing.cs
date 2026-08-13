namespace IceFebruary.Space.Follow
{
    /// <summary>
    /// Defines object capable of tracking, possessing, or following specific spatial target.
    /// </summary>
    public interface ITargetPossessing<T> : IBaseEntity
    {
        /// <summary>
        /// Assigns new active target for tracking logic.
        /// </summary>
        void SetTarget(T target);

        /// <summary>
        /// Clears current target.
        /// </summary>
        void ResetTarget();
    }
}
