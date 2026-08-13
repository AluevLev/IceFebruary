namespace IceFebruary.Collections
{
    using System.Collections.Generic;

    /// <summary>
    /// The high-performance collection for efficiently storing <see cref="IBaseEntity"/> types.
    /// Automatically recycles slots of deleted entities and doubles its capacity on overflow.
    /// </summary>
    public sealed class EntityFastArray<T> where T : class, IBaseEntity
    {
        private readonly Stack<int> _freeIndexes = new();
        private T[] _entities;

        /// <summary>
        /// Raw array containing all registered entities.
        /// </summary>
        public T[] Entities
        {
            get => _entities;
            private set => _entities = value;
        }

        /// <summary>
        /// Current size of the array.
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Creates a new instance of the collection with a specified initial size.
        /// </summary>
        public EntityFastArray(int startLength)
        {
            Length = startLength.ClampForArray();

            Entities = new T[Length];

            for (int index = 0; index < Length; index++)
                _freeIndexes.Push(index);
        }

        /// <summary>
        /// Registers a live entity in array.
        /// Triggers self-cleaning or array resizing if full.
        /// </summary>
        public void Register(T entity)
        {
            if (!entity.Exists())
                return;

            if (_freeIndexes.Count == 0)
                for (int entityIndex = 0; entityIndex < Length; entityIndex++)
                    if (!Entities[entityIndex].Exists())
                        _freeIndexes.Push(entityIndex);

            if (_freeIndexes.Count == 0)
            {
                int length = Length;
                int doubledLength = length << 1;

                System.Array.Resize(ref _entities, doubledLength);

                for (int index = length; index < doubledLength; index++)
                    _freeIndexes.Push(index);

                Length = doubledLength;
            }

            Entities[_freeIndexes.Pop()] = entity;
        }
    }
}
