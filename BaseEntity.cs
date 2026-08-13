namespace IceFebruary
{
    /// <summary>
    /// Basic abstract entity class.
    /// Simplest implementation of the entity interface.
    /// </summary>
    public abstract class BaseEntity : IBaseEntity
    {
        protected bool _enabled = true;

        /// <summary>
        /// True, if the entity is destroyed.
        /// Don't use destroyed entities.
        /// </summary>
        public bool Destroyed { get; protected set; } = false;

        /// <summary>
        /// True, if the entity is enabled.
        /// </summary>
        public virtual bool Enabled
        {
            get => _enabled;
            set => _enabled = value;
        }

        /// <summary>
        /// Destroying an entity.
        /// </summary>
        public virtual void Destroy()
        {
            Destroyed = true;
        }
    }
}
