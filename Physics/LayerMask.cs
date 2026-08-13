namespace IceFebruary.Physics
{
    using IceFebruary.Proxy;
    using System;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Layer mask for filtering physical checks.
    /// </summary>
    public readonly struct LayerMask : IEquatable<LayerMask>
    {
        /// <summary>
        /// Bitmask value.
        /// </summary>
        public int Mask { get; private init; }

        /// <summary>
        /// Creates a new layer mask with given bitmask.
        /// </summary>
        [FieldProxy]
        public LayerMask(int mask)
        {
            Mask = mask;
        }

        /// <summary>
        /// Default layer mask (all layers incluede).
        /// </summary>
        public static readonly LayerMask Default = new(-1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]



        public static bool operator !=(LayerMask a, LayerMask b) => !(a == b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(LayerMask a, LayerMask b) => a.Mask == b.Mask;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(LayerMask layerMask) => this == layerMask;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is LayerMask other && Equals(other);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(Mask);
    }
}
