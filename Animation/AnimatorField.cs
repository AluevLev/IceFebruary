namespace IceFebruary.Animation
{
    public readonly struct AnimatorField<T> where T : struct
    {
        public readonly AnimatorFieldData _animatorFieldData;
        public AnimatorField(AnimatorFieldData animatorFieldData)
        {
            _animatorFieldData = animatorFieldData;
        }
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
