namespace IceFebruary.Random
{
    using IceFebruary.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Сlass that generates random values.
    /// </summary>
    public sealed class Random
    {
        private const float UintFloatMaxValue = uint.MaxValue;
        private uint _state;

        /// <summary>
        /// State of the random value generator that generates random values.
        /// </summary>
        public uint State
        {
            get => _state;
            set => _state = value;
        }

        /// <summary>
        /// Creates a new class that generates random values.
        /// </summary>
        public Random(uint state)
        {
            _state = state == 0 ? 1 : state;
        }

        /// <summary>
        /// Generates a random integer between two values (minimum including and maximum excluding).
        /// </summary>
        public int BetweenInt(int min, int max)
        {
            FixOrder(ref min, ref max);

            return min + (int)RandomUnum((uint)(max - min));
        }

        /// <summary>
        /// Generates a random float between two values.
        /// </summary>
        public float BetweenFloat(float min, float max)
        {
            FixOrder(ref min, ref max);

            return RandomFloat01() * (max - min) + min;
        }

        /// <summary>
        /// Generates a random boolean.
        /// </summary>
        public bool FiftyFifty => (ChangeState() & 1) == 0;

        /// <summary>
        /// Generates a random float between 0 and 1.
        /// </summary>
        public float Percent => BetweenFloat(0f, 1f);

        /// <summary>
        /// Returns a random element of the collection.
        /// </summary>
        public T InCollection<T>(IReadOnlyCollection<T> collection) => collection.Exists() ? collection.ElementAt(BetweenInt(0, collection.Count)) : default;

        private uint ChangeState()
        {
            _state ^= _state << 13;
            _state ^= _state >> 17;
            _state ^= _state << 5;

            return _state;
        }
        private uint RandomUnum(uint max) => ChangeState() % max;
        private float RandomFloat01() => ChangeState() / UintFloatMaxValue;
        private void FixOrder(ref int min, ref int max)
        {
            if (min > max)
                (min, max) = (max, min);
        }
        private void FixOrder(ref float min, ref float max)
        {
            if (min > max)
                (min, max) = (max, min);
        }
    }
}
