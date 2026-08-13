namespace IceFebruary
{
    using System.Runtime.CompilerServices;
    using SysMathF = System.MathF;

    /// <summary>
    /// Static class for mathematical operations and constants.
    /// </summary>
    public static class Math
    {
        /// <summary>
        /// Number pi = 3.14159274.
        /// </summary>
        public const float Pi = 3.14159274f;

        /// <summary>
        /// Number epsilon = 0.00001.
        /// </summary>
        public const float Epsilon = 0.00001f;

        /// <summary>
        /// Number inverse epsilon = 1 / 0.00001.
        /// </summary>
        public const float InverseEpsilon = 1f / Epsilon;

        /// <summary>
        /// Constant for converting radian angles to degrees (180 / pi).
        /// </summary>
        public const float Rad2Deg = 180f / Pi;

        /// <summary>
        /// Constant for converting degrees angles to radian (pi / 180).
        /// </summary>
        public const float Deg2Rad = Pi / 180f;

        /// <summary>
        /// Calculates the absolute value of a number.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Abs(float x) => SysMathF.Abs(x);

        /// <summary>
        /// Calculates the sign of a number.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sign(float x) => SysMathF.Sign(x);

        /// <summary>
        /// Calculates the square root of a number.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sqrt(float x) => SysMathF.Sqrt(x);

        /// <summary>
        /// Fast carculates the sine of an angle.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float NimbleSin(float x)
        {
            float rem = x % (2f * Pi);

            if (rem > Pi)
                rem -= 2f * Pi;
            if (rem < -Pi)
                rem += 2f * Pi;

            float absRem = Abs(rem);
            float y = 1.2732395f * rem - 0.4052847f * rem * absRem;
            float absY = Abs(y);

            return 0.225f * (y * absY - y) + y;
        }

        /// <summary>
        /// Fast carculates the cosine of an angle.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float NimbleCos(float x) => NimbleSin(x + Pi * 0.5f);

        /// <summary>
        /// Fast carculates the arctangent.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float NimbleAtan2(float y, float x)
        {
            float absX = Abs(x);
            float absY = Abs(y);

            if (absX < Epsilon && absY < Epsilon)
                return 0f;

            float ratio = absX > absY ? absY / absX : absX / absY;
            float angle = (0.9724f - 0.1919f * ratio * ratio) * ratio;

            if (absY > absX)
                angle = (Pi * 0.5f) - angle;
            if (x < 0f)
                angle = Pi - angle;
            if (y < 0f)
                angle = -angle;

            return angle;
        }

        /// <summary>
        /// Calculates the smallest integer power of two of a number that is greater than the number itself.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetPower2WithReserve(int x)
        {
            if (x < 2)
                return 0;

            int power = 0;
            int temp = x - 1;

            while (temp > 0)
            {
                temp >>= 1;
                power++;
            }

            return power;
        }

        /// <summary>
        /// Keeps the value in range.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Clamp(this int x, int min, int max)
        {
            if (x < min)
                return min;
            if (x > max)
                return max;
            return x;
        }

        /// <summary>
        /// Keeps the value in range.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Clamp(this float x, float min, float max)
        {
            if (x < min)
                return min;
            if (x > max)
                return max;
            return x;
        }

        /// <summary>
        /// Returns the minimum value if the number is less than it.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ClampMin(this int x, int min) => x < min ? min : x;

        /// <summary>
        /// Returns the minimum value if the number is less than it.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ClampMin(this float x, float min) => x < min ? min : x;

        /// <summary>
        /// Returns the maximum value if the number is greater than it.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ClampMax(this int x, int max) => x > max ? max : x;

        /// <summary>
        /// Returns the maximum value if the number is greater than it.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ClampMax(this float x, float max) => x > max ? max : x;

        /// <summary>
        /// Optimizes a number for the array size.
        /// If it is less than 0, it returns 0.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ClampForArray(this int x) => x.ClampMin(0);

        /// <summary>
        /// Returns true if the value is in range.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool InBounds(this int x, int min, int max) => x >= min && x <= max;

        /// <summary>
        /// Returns true if the value is in range.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool InBounds(this float x, float min, float max) => x >= min && x <= max;

        /// <summary>
        /// Returns the result of a lerp of numbers with some interpolation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Lerp(float x, float y, float interpolation) => x + (y - x) * interpolation.Clamp01();

        /// <summary>
        /// Clamping float between 0 and 1.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Clamp01(this float x) => x.Clamp(0f, 1f);

        /// <summary>
        /// Finds the minimum value between 2 numbers.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Min(int x, int y) => x < y ? x : y;

        /// <summary>
        /// Finds the minimum value between 2 numbers.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Min(float x, float y) => x < y ? x : y;

        /// <summary>
        /// Finds the maximum value between 2 numbers.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Max(int x, int y) => x > y ? x : y;

        /// <summary>
        /// Finds the maximum value between 2 numbers.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(float x, float y) => x > y ? x : y;
    }
}
