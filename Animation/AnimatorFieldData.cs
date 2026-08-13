namespace IceFebruary.Animation
{
    using IceFebruary.Proxy;

    /// <summary>
    /// The immutable structure for storing information about a variable in an animator.
    /// </summary>
    public readonly struct AnimatorFieldData
    {
        /// <summary>
        /// Animator with the desired variable.
        /// </summary>
        public IAnimator Animator { get; private init; }

        /// <summary>
        /// Variable hash.
        /// </summary>
        public int Hash { get; private init; }

        /// <summary>
        /// Creates a new data instance with the given animator and hash.
        /// </summary>
        [FieldProxy]
        public AnimatorFieldData(IAnimator animator, int hash)
        {
            Animator = animator;
            Hash = hash;
        }
    }
}
