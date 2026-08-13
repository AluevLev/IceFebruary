namespace IceFebruary
{
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Extension class for base entity interface.
    /// </summary>
    public static class BaseEntityExtension
    {
        /// <summary>
        /// Checks whether an entity exists and has not been destroyed.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Exists(this IBaseEntity entity) => !(entity == null || entity.Destroyed);
    }
}
