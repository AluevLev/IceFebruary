namespace IceFebruary.Space
{
    using IceFebruary;
    using IceFebruary.Proxy;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Immutable structure of a two-dimensional vector.
    /// </summary>
    public readonly struct Vector2 : System.IEquatable<Vector2>, System.IFormattable
    {
        /// <summary>
        /// Zero vector (0, 0).
        /// </summary>
        public static readonly Vector2 Zero = default;

        /// <summary>
        /// Top right vector (1, 1).
        /// </summary>
        public static readonly Vector2 TopRight = new(1f, 1f);

        /// <summary>
        /// Top left vector (-1, 1).
        /// </summary>
        public static readonly Vector2 TopLeft = new(-1f, 1f);

        /// <summary>
        /// Bottom left vector (-1, -1).
        /// </summary>
        public static readonly Vector2 BottomLeft = new(-1f, -1f);

        /// <summary>
        /// Bottom right vector (1, -1).
        /// </summary>
        public static readonly Vector2 BottomRight = new(1f, -1f);

        /// <summary>
        /// Top vector (0, 1).
        /// </summary>
        public static readonly Vector2 Top = new(0f, 1f);

        /// <summary>
        /// Bottom vector (0, -1).
        /// </summary>
        public static readonly Vector2 Bottom = new(0f, -1f);

        /// <summary>
        /// Right vector (1, 0).
        /// </summary>
        public static readonly Vector2 Right = new(1f, 0f);

        /// <summary>
        /// Left vector (-1, 0).
        /// </summary>
        public static readonly Vector2 Left = new(-1f, 0f);

        /// <summary>
        /// X-coordinate.
        /// </summary>
        public float X { get; private init; }

        /// <summary>
        /// Y-coordinate.
        /// </summary>
        public float Y { get; private init; }

        /// <summary>
        /// Creates a new vector instance.
        /// </summary>
        [FieldProxy, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Square of the vector's length (faster than regular length since it doesn't compute the square root).
        /// </summary>
        public float SqrLength
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => X * X + Y * Y;
        }

        /// <summary>
        /// Vector's length.
        /// </summary>
        public float Length
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Math.Sqrt(SqrLength);
        }

        /// <summary>
        /// Normalized vector (vector with the same direction but length 1).
        /// </summary>
        public Vector2 Normalized
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Normalize(this);
        }

        /// <summary>
        /// Normalized direction from the current vector to the target point.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2 DirectionTo(Vector2 to) => DirectionTo(this, to);



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator +(Vector2 a, Vector2 b) => new(a.X + b.X, a.Y + b.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator -(Vector2 a, Vector2 b) => new(a.X - b.X, a.Y - b.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator *(Vector2 a, Vector2 b) => new(a.X * b.X, a.Y * b.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator -(Vector2 a) => new(-a.X, -a.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator *(Vector2 a, float f) => new(a.X * f, a.Y * f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator *(float f, Vector2 a) => a * f;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator /(Vector2 a, float f) => new(a.X / f, a.Y / f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2 a, Vector2 b) =>
            Math.Abs(a.X - b.X) < Math.Epsilon &&
            Math.Abs(a.Y - b.Y) < Math.Epsilon;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2 a, Vector2 b) => !(a == b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]



        public bool Equals(Vector2 other) => this == other;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is Vector2 other && Equals(other);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, System.IFormatProvider formatProvider) => $"(X: {X}; Y: {Y})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => ToString(null, null);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => System.HashCode.Combine((int)(X * Math.InverseEpsilon), (int)(Y * Math.InverseEpsilon));



        /// <summary>
        /// Dot product of two vectors. Used to determine angles or projections.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Dot(Vector2 a, Vector2 b) => a.X * b.X + a.Y * b.Y;

        /// <summary>
        /// Square of the distance between points (faster than regular distance since it doesn't compute the square root).
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SqrDistance(Vector2 a, Vector2 b) => (a - b).SqrLength;

        /// <summary>
        /// Distance between points.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Distance(Vector2 a, Vector2 b) => (a - b).Length;

        /// <summary>
        /// Normalizes the vector (vector with the same direction but length 1).
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Normalize(Vector2 v)
        {
            float length = v.Length;
            return length < Math.Epsilon ? Right : v / length;
        }

        /// <summary>
        /// Linear interpolation between two vectors.
        /// The value of the coefficient <paramref name="interpolation"/> is automatically clamped between 0 and 1.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Lerp(Vector2 a, Vector2 b, float interpolation) => a + (b - a) * interpolation.Clamp01();

        /// <summary>
        /// Normalized direction from the origin vector to the target point.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 DirectionTo(Vector2 from, Vector2 to) => (to - from).Normalized;
    }
}
