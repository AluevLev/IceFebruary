namespace IceFebruary.Random
{
    using System.Collections.Generic;

    /// <summary>
    /// Global static class that generates random values.
    /// </summary>
    public static class GlobalRandom
    {
        private static readonly Random _random = new(1);

        /// <summary>
        /// Generates a random integer between two values (minimum including and maximum excluding).
        /// </summary>
        public static int BetweenInt(int min, int max) => _random.BetweenInt(min, max);

        /// <summary>
        /// Generates a random float between two values.
        /// </summary>
        public static float BetweenFloat(float min, float max) => _random.BetweenFloat(min, max);

        /// <summary>
        /// Generates a random boolean.
        /// </summary>
        public static bool FiftyFifty => _random.FiftyFifty;

        /// <summary>
        /// Generates a random float between 0 and 1.
        /// </summary>
        public static float Percent => _random.Percent;

        /// <summary>
        /// Returns a random element of the collection.
        /// </summary>
        public static T InCollection<T>(IReadOnlyCollection<T> collection) => _random.InCollection(collection);
    }
}
