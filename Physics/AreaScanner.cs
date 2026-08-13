namespace IceFebruary.Physics
{
    using IceFebruary;
    using IceFebruary.Shapes;
    using IceFebruary.Space;
    using IceFebruary.Space.Rotor2Provider;
    using IceFebruary.Space.Vector2Provider;

    /// <summary>
    /// Scanner of physical objects in a certain area.
    /// </summary>
    public sealed class AreaScanner : BaseEntity, IOverlapper
    {
        /// <summary>
        /// Colliders that are the results of scanning.
        /// </summary>
        public Component<ICollider2D>[] Colliders2D { get; private init; }

        /// <summary>
        /// Actual buffer length for colliders.
        /// </summary>
        public int Colliders2DActualLength { get; private set; }
        private readonly IPhysics2D _physics2D;
        private readonly IShape _shape;
        private readonly IVector2Provider _position;
        private readonly IRotor2Provider _rotation;
        private readonly ContactFilter2D _contactFilter2D;

        /// <summary>
        /// Creates a new scanner of physical objects.
        /// </summary>
        public AreaScanner(IPhysics2D physics2D, IShape shape, IVector2Provider position, IRotor2Provider rotation, ContactFilter2D contactFilter, int collider2DMaxBufferSize)
        {
            _physics2D = physics2D;
            _shape = shape;
            _position = position;
            _rotation = rotation;
            _contactFilter2D = contactFilter;

            Colliders2D = new Component<ICollider2D>[collider2DMaxBufferSize.ClampForArray()];
        }

        /// <summary>
        /// Method for scanning physical objects in a certain area.
        /// </summary>
        public void Overlap()
        {
            if (_position.TryGetSafety(out Vector2 position) && _rotation.TryGetSafety(out Rotor2 rotation))
            {
                Colliders2DActualLength = _physics2D.Overlap(_shape, position, rotation, _contactFilter2D, Colliders2D);
                return;
            }

            Colliders2DActualLength = 0;

            for (int index = 0; index < Colliders2D.Length; index++)
                Colliders2D[index] = default;
        }
    }
}
