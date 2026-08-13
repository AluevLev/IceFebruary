namespace IceFebruary.Space
{
    using IceFebruary.Proxy;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Immutable structure of a two-dimensional rotor.
    /// </summary>
    public readonly struct Rotor2 : System.IEquatable<Rotor2>, System.IFormattable
    {
        /// <summary>
        /// Default rotor (1, 0).
        /// </summary>
        public static readonly Rotor2 Default = new(1f, 0f);

        /// <summary>
        /// Rotor scalar.
        /// </summary>
        public float Scalar { get; private init; }

        /// <summary>
        /// Rotor bivector.
        /// </summary>
        public float XY { get; private init; }

        /// <summary>
        /// Creates a new rotor instance using scalar and bivector.
        /// </summary>
        [FieldProxy, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Rotor2(float scalar, float xy)
        {
            Scalar = scalar;
            XY = xy;
        }

        /// <summary>
        /// Creates a new rotor instance from specified rotation angle.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Rotor2(float angle, bool radian)
        {
            float halfAngle = (radian ? angle : angle * Math.Deg2Rad) * 0.5f;

            Scalar = Math.NimbleCos(halfAngle);
            XY = Math.NimbleSin(halfAngle);
        }

        /// <summary>
        /// Creates a new rotor instance that rotates identity direction vector to target vector orientation (vector must be normalized).
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Rotor2(Vector2 v)
        {
            Scalar = Math.Sqrt((1f + v.X) * 0.5f);
            XY = Math.Sign(v.Y) * Math.Sqrt((1f - v.X) * 0.5f);
        }

        /// <summary>
        /// Inverse rotor representing opposite rotation direction.
        /// </summary>
        public readonly Rotor2 Inverse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new(Scalar, -XY);
        }



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rotor2 operator *(Rotor2 a, Rotor2 b) => new(a.Scalar * b.Scalar - a.XY * b.XY, a.Scalar * b.XY + a.XY * b.Scalar);
        public static Vector2 operator *(Rotor2 r, Vector2 v)
        {
            float cos2A = r.Scalar * r.Scalar - r.XY * r.XY;
            float sin2A = 2f * r.Scalar * r.XY;

            return new(
                v.X * cos2A - v.Y * sin2A,
                v.X * sin2A + v.Y * cos2A);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Rotor2 a, Rotor2 b) =>
            Math.Abs(a.Scalar - b.Scalar) < Math.Epsilon &&
            Math.Abs(a.XY - b.XY) < Math.Epsilon;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Rotor2 a, Rotor2 b) => !(a == b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]



        public bool Equals(Rotor2 other) => this == other;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is Rotor2 other && Equals(other);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, System.IFormatProvider formatProvider) => $"(Scalar: {Scalar}; XY: {XY})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => ToString(null, null);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => System.HashCode.Combine((int)(Scalar * Math.InverseEpsilon), (int)(XY * Math.InverseEpsilon));



        /// <summary>
        /// Performs linear interpolation between two rotors.
        /// Value of the coefficient <paramref name="interpolation"/> is automatically clamped between 0 and 1.
        /// </summary>
        public static Rotor2 Lerp(Rotor2 a, Rotor2 b, float interpolation)
        {
            interpolation = interpolation.Clamp01();

            float dot = a.Scalar * b.Scalar + a.XY * b.XY;

            float aScalar = a.Scalar;
            float aXY = a.XY;
            float bScalar = b.Scalar;
            float bXY = b.XY;

            if (dot < 0)
            {
                bScalar = -bScalar;
                bXY = -bXY;
            }

            float resultScalar = Math.Lerp(aScalar, bScalar, interpolation);
            float resultXY = Math.Lerp(aXY, bXY, interpolation);

            float sqrMagnitude = resultScalar * resultScalar + resultXY * resultXY;

            if (sqrMagnitude < Math.Epsilon)
                return Default;

            float invMagnitude = 1f / Math.Sqrt(sqrMagnitude);

            return new(resultScalar * invMagnitude, resultXY * invMagnitude);
        }

        /// <summary>
        /// Converts current rotor rotation back into angle.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float ToAngle(bool radian) => Math.NimbleAtan2(XY, Scalar) * 2f * (radian ? 1f : Math.Rad2Deg);
    }
}