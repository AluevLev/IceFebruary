namespace IceFebruary.Collections
{
    using System.Collections.Generic;

    /// <summary>
    /// Extensions class for collections.
    /// </summary>
    public static class CollectionsExtensions
    {
        /// <summary>
        /// Checks if the collection is not null and the collection size is greater than 0.
        /// </summary>
        public static bool Exists<T>(this IReadOnlyCollection<T> collection) => collection != null && collection.Count > 0;
    }
}
