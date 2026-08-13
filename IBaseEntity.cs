namespace IceFebruary
{
    /// <summary>
    /// An interface that is an implementation of the simplest entity.
    /// </summary>
    public interface IBaseEntity
    {
        /// <summary>
        /// True, if the entity is enabled.
        /// </summary>
        bool Enabled { get; set; }

        /// <summary>
        /// True, if the entity is destroyed.
        /// Don't use destroyed entities.
        /// </summary>
        bool Destroyed { get; }

        /// <summary>
        /// Destroying an entity.
        /// </summary>
        void Destroy();
    }
}