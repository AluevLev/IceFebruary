namespace IceFebruary.Animation
{
    /// <summary>
    /// Immutable structure of animator field.
    /// </summary>
    public readonly struct AnimatorField<T> where T : struct
    {
        private readonly AnimatorFieldData _animatorFieldData;

        /// <summary>
        /// Creates a new animator field with the given animator field data.
        /// </summary>
        public AnimatorField(AnimatorFieldData animatorFieldData)
        {
            _animatorFieldData = animatorFieldData;
        }

        /// <summary>
        /// Value of the variable in the animator.
        /// </summary>
        public T Value
        {
            get
            {
                IAnimator animator = _animatorFieldData.Animator;
                return animator.Exists() ? animator.Get<T>(_animatorFieldData.Hash) : default;
            }

            set
            {
                IAnimator animator = _animatorFieldData.Animator;
                if (animator.Exists())
                    animator.Set(_animatorFieldData.Hash, value);
            }
        }
    }
}
