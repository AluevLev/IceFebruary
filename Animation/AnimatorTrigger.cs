namespace IceFebruary.Animation
{
    using IceFebruary.Proxy;

    /// <summary>
    /// Immutable structure of animator trigger.
    /// </summary>
    public readonly struct AnimatorTrigger
    {
        private readonly AnimatorFieldData _animatorFieldData;

        /// <summary>
        /// Creates a new animator trigger with the given animator field data.
        /// </summary>
        [FieldProxy]
        public AnimatorTrigger(AnimatorFieldData animatorFieldData)
        {
            _animatorFieldData = animatorFieldData;
        }

        /// <summary>
        /// Activate the trigger in animator.
        /// </summary>
        public void Activate()
        {
            IAnimator animator = _animatorFieldData.Animator;
            if (animator.Exists())
                animator.ActivateTrigger(_animatorFieldData.Hash);
        }
    }
}
