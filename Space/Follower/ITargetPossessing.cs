namespace IceFebruary.Space.Follow
{
    public interface ITargetPossessing<T> : IBaseEntity
    {
        void SetTarget(T target);
        void ResetTarget();
    }
}
