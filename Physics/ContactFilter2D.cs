namespace IceFebruary.Physics
{
    using IceFebruary.Proxy;
    using System;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Immutable structure storing a filter for a physical overlap of objects.
    /// </summary>
    public readonly struct ContactFilter2D : IEquatable<ContactFilter2D>
    {
        /// <summary>
        /// True, if the filter includes trigger scanning.
        /// </summary>
        public bool UseTriggers { get; private init; }

        /// <summary>
        /// A mask with the layers that the filter will include.
        /// </summary>
        public LayerMask LayerMask { get; private init; }

        /// <summary>
        /// Creates a new immutable structure storing a filter for a physical overlap of objects.
        /// </summary>
        [FieldProxy]
        public ContactFilter2D(LayerMask layerMask, bool useTriggers = true)
        {
            UseTriggers = useTriggers;
            LayerMask = layerMask;
        }

        /// <summary>
        /// Default contact filter (with default layer mask and scanning for triggers).
        /// </summary>
        public static readonly ContactFilter2D Default = new(LayerMask.Default, true);



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(ContactFilter2D a, ContactFilter2D b) => !(a == b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(ContactFilter2D a, ContactFilter2D b) =>
            a.UseTriggers == b.UseTriggers &&
            a.LayerMask == b.LayerMask;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ContactFilter2D contactFilter2D) => this == contactFilter2D;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is ContactFilter2D other && Equals(other);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(UseTriggers, LayerMask);
    }
}
