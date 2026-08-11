namespace IceFebruary.Animation
{
    using IceFebruary.Proxy;

    public readonly struct AnimatorTrigger
    {
        private readonly AnimatorFieldData _animatorFieldData;

        [FieldProxy]
        public AnimatorTrigger(AnimatorFieldData animatorFieldData)
        {
            _animatorFieldData = animatorFieldData;
        }
        public void Set()
        {
            IAnimator animator = _animatorFieldData.Animator;
            if (animator.Exists())
                animator.SetTrigger(_animatorFieldData.Hash);
        }
    }
}
