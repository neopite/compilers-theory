namespace DiagramDrawer
{
    public interface IAdapter<T, K>
    {
        T Adapt(K value);
    }
}